#!/usr/bin/env bun
/**
 * Dependency Graph Analysis for C# Conversion Planning
 *
 * This script analyzes the TypeScript codebase in packages/core/src to:
 * - Build a dependency graph
 * - Perform topological sort (leaves → root order for conversion)
 * - Map test files to source files
 * - Rank examples by complexity
 * - Detect circular dependencies
 * - Generate visual SVG and markdown report
 */

// @ts-ignore - madge has no type definitions
import madge from "madge"
import { Graph, alg } from "@dagrejs/graphlib"
import { join, basename, dirname, relative } from "path"

const ROOT = join(import.meta.dir, "..")
const CORE_SRC = join(ROOT, "packages/core/src")
const OUTPUT_DIR = join(ROOT, "scripts")

type DependencyGraph = Record<string, string[]>

interface FileInfo {
  path: string
  relativePath: string
  dependencies: string[]
  dependents: string[]
  depth: number
  hasTest: boolean
  testFile?: string
}

interface AnalysisResult {
  files: Map<string, FileInfo>
  conversionOrder: string[]
  circularDeps: string[][]
  testCoverage: { covered: string[]; missing: string[] }
  examples: { path: string; depCount: number }[]
}

async function findTestFile(sourceFile: string): Promise<string | undefined> {
  const dir = dirname(sourceFile)
  const base = basename(sourceFile, ".ts")

  // Check for co-located test file
  const colocatedTest = join(dir, `${base}.test.ts`)
  if (await Bun.file(colocatedTest).exists()) {
    return colocatedTest
  }

  // Check in tests/ subdirectory
  const testsDir = join(dir, "tests", `${base}.test.ts`)
  if (await Bun.file(testsDir).exists()) {
    return testsDir
  }

  // Check in __tests__ subdirectory
  const underscoreTestsDir = join(dir, "__tests__", `${base}.test.ts`)
  if (await Bun.file(underscoreTestsDir).exists()) {
    return underscoreTestsDir
  }

  return undefined
}

async function analyzeExamples(): Promise<{ path: string; depCount: number }[]> {
  const examplesDir = join(CORE_SRC, "examples")
  const glob = new Bun.Glob("*.ts")
  const examples: { path: string; depCount: number }[] = []

  for await (const file of glob.scan({ cwd: examplesDir, absolute: true })) {
    const content = await Bun.file(file).text()
    // Count import statements as a rough complexity metric
    const imports = content.match(/^import\s+/gm) || []
    examples.push({
      path: relative(ROOT, file),
      depCount: imports.length,
    })
  }

  return examples.sort((a, b) => a.depCount - b.depCount)
}

async function analyze(): Promise<AnalysisResult> {
  console.log("🔍 Analyzing dependencies in packages/core/src...")
  console.log("   Excluding: 3d/**, zig/**\n")

  // Use madge to build dependency graph
  const res = await madge(CORE_SRC, {
    fileExtensions: ["ts"],
    excludeRegExp: [/^3d\//, /^zig\//, /\.test\.ts$/, /\.d\.ts$/],
    tsConfig: join(ROOT, "packages/core/tsconfig.json"),
  })

  const graph: DependencyGraph = res.obj()
  const circular: string[][] = res.circular()

  // Build our own graph for topological sort
  const g = new Graph({ directed: true })

  // Add all nodes
  for (const file of Object.keys(graph)) {
    g.setNode(file)
  }

  // Add edges (dependency → dependent)
  for (const [file, deps] of Object.entries(graph)) {
    for (const dep of deps) {
      if (g.hasNode(dep)) {
        g.setEdge(dep, file)
      }
    }
  }

  // Perform topological sort (leaves first = files with no dependencies)
  let conversionOrder: string[] = []
  try {
    conversionOrder = alg.topsort(g)
  } catch (e) {
    console.warn("⚠️  Graph has cycles, using partial ordering")
    // Fall back to sorting by dependency count
    conversionOrder = Object.entries(graph)
      .sort((a, b) => a[1].length - b[1].length)
      .map(([file]) => file)
  }

  // Build file info map
  const files = new Map<string, FileInfo>()

  // Calculate depth for each file (max distance from a leaf)
  const depths = new Map<string, number>()
  function calculateDepth(file: string, visited = new Set<string>()): number {
    if (depths.has(file)) return depths.get(file)!
    if (visited.has(file)) return 0 // Cycle detected

    visited.add(file)
    const deps = graph[file] || []
    const maxDepDep = deps.length === 0 ? 0 : Math.max(...deps.map((d) => calculateDepth(d, visited) + 1))
    depths.set(file, maxDepDep)
    return maxDepDep
  }

  for (const file of Object.keys(graph)) {
    calculateDepth(file)
  }

  // Build dependents map (reverse of dependencies)
  const dependents = new Map<string, string[]>()
  for (const [file, deps] of Object.entries(graph)) {
    for (const dep of deps) {
      if (!dependents.has(dep)) dependents.set(dep, [])
      dependents.get(dep)!.push(file)
    }
  }

  // Populate file info
  for (const file of Object.keys(graph)) {
    const fullPath = join(CORE_SRC, file)
    const testFile = await findTestFile(fullPath)

    files.set(file, {
      path: fullPath,
      relativePath: file,
      dependencies: graph[file] || [],
      dependents: dependents.get(file) || [],
      depth: depths.get(file) || 0,
      hasTest: !!testFile,
      testFile: testFile ? relative(ROOT, testFile) : undefined,
    })
  }

  // Analyze test coverage
  const covered: string[] = []
  const missing: string[] = []
  for (const [file, info] of files) {
    // Skip index files and type-only files
    if (file === "index.ts" || file.endsWith("/index.ts")) continue
    if (info.hasTest) {
      covered.push(file)
    } else {
      missing.push(file)
    }
  }

  // Analyze examples
  const examples = await analyzeExamples()

  return {
    files,
    conversionOrder,
    circularDeps: circular,
    testCoverage: { covered, missing },
    examples,
  }
}

function generateMarkdownReport(result: AnalysisResult): string {
  const { files, conversionOrder, circularDeps, testCoverage, examples } = result

  // Group files by depth (conversion phases)
  const phases = new Map<number, string[]>()
  for (const file of conversionOrder) {
    const info = files.get(file)
    if (!info) continue
    const depth = info.depth
    if (!phases.has(depth)) phases.set(depth, [])
    phases.get(depth)!.push(file)
  }

  let md = `# C# Conversion Order - Dependency Analysis

Generated: ${new Date().toISOString()}

## Overview

- **Total Files**: ${files.size}
- **Files with Tests**: ${testCoverage.covered.length}
- **Files Missing Tests**: ${testCoverage.missing.length}
- **Circular Dependencies**: ${circularDeps.length > 0 ? circularDeps.length : "None ✅"}
- **Examples**: ${examples.length}

---

## Conversion Phases

Files are grouped by dependency depth. **Convert Phase 0 first** (no dependencies), then Phase 1, etc.

`

  const sortedPhases = [...phases.entries()].sort((a, b) => a[0] - b[0])
  for (const [depth, phaseFiles] of sortedPhases) {
    md += `### Phase ${depth} (${phaseFiles.length} files)\n\n`
    md += `| File | Dependencies | Dependents | Has Test |\n`
    md += `|------|--------------|------------|----------|\n`

    for (const file of phaseFiles) {
      const info = files.get(file)!
      const hasTest = info.hasTest ? "✅" : "❌"
      md += `| \`${file}\` | ${info.dependencies.length} | ${info.dependents.length} | ${hasTest} |\n`
    }
    md += "\n"
  }

  md += `---

## Test Coverage

### ✅ Files with Tests (${testCoverage.covered.length})

| Source File | Test File |
|-------------|-----------|
`
  for (const file of testCoverage.covered) {
    const info = files.get(file)!
    md += `| \`${file}\` | \`${info.testFile}\` |\n`
  }

  md += `
### ❌ Files Missing Tests (${testCoverage.missing.length})

`
  for (const file of testCoverage.missing) {
    md += `- \`${file}\`\n`
  }

  md += `
---

## Examples by Complexity

Examples ranked from simplest (fewest imports) to most complex:

| Example | Import Count |
|---------|--------------|
`
  for (const ex of examples) {
    md += `| \`${ex.path}\` | ${ex.depCount} |\n`
  }

  if (circularDeps.length > 0) {
    md += `
---

## ⚠️ Circular Dependencies

These cycles must be resolved before conversion:

`
    for (const cycle of circularDeps) {
      md += `- ${cycle.map((f) => `\`${f}\``).join(" → ")} → \`${cycle[0]}\`\n`
    }
  }

  md += `
---

## Detailed File Information

<details>
<summary>Click to expand full dependency details</summary>

`
  for (const file of conversionOrder) {
    const info = files.get(file)!
    md += `### \`${file}\`

- **Depth**: ${info.depth}
- **Dependencies** (${info.dependencies.length}): ${info.dependencies.length > 0 ? info.dependencies.map((d) => `\`${d}\``).join(", ") : "None"}
- **Dependents** (${info.dependents.length}): ${info.dependents.length > 0 ? info.dependents.map((d) => `\`${d}\``).join(", ") : "None"}
- **Test**: ${info.hasTest ? `✅ \`${info.testFile}\`` : "❌ Missing"}

`
  }

  md += `</details>\n`

  return md
}

async function generateSvg(): Promise<void> {
  console.log("📊 Generating SVG dependency graph...")

  const res = await madge(CORE_SRC, {
    fileExtensions: ["ts"],
    excludeRegExp: [/^3d\//, /^zig\//, /\.test\.ts$/, /\.d\.ts$/],
    tsConfig: join(ROOT, "packages/core/tsconfig.json"),
  })

  const svgPath = join(OUTPUT_DIR, "dependency-graph.svg")

  try {
    await res.image(svgPath)
    console.log(`   ✅ Generated: ${relative(ROOT, svgPath)}`)
  } catch (e) {
    console.error(`   ❌ Failed to generate SVG: ${e}`)
    console.log("   💡 Make sure graphviz is installed: sudo apt install graphviz")
  }
}

async function main() {
  console.log("=".repeat(60))
  console.log("  OpenTUI Dependency Analysis for C# Conversion")
  console.log("=".repeat(60))
  console.log()

  const result = await analyze()

  // Generate markdown report
  const mdPath = join(OUTPUT_DIR, "conversion-order.md")
  const mdContent = generateMarkdownReport(result)
  await Bun.write(mdPath, mdContent)
  console.log(`📝 Generated: ${relative(ROOT, mdPath)}`)

  // Generate SVG
  await generateSvg()

  console.log()
  console.log("=".repeat(60))
  console.log("  Summary")
  console.log("=".repeat(60))
  console.log(`  Total files:          ${result.files.size}`)
  console.log(`  Test coverage:        ${result.testCoverage.covered.length}/${result.files.size}`)
  console.log(`  Circular dependencies: ${result.circularDeps.length}`)
  console.log(`  Examples analyzed:    ${result.examples.length}`)
  console.log()

  if (result.circularDeps.length > 0) {
    console.log("⚠️  Circular dependencies detected! See report for details.")
  }
}

main().catch(console.error)
