#!/usr/bin/env bun
/**
 * Dependency Graph Analysis for C# Conversion Planning
 *
 * This script analyzes the TypeScript codebase in packages/core/src to:
 * - Build a dependency graph using skott
 * - Perform topological sort (leaves → root order for conversion)
 * - Map test files to source files
 * - Rank examples by complexity
 * - Detect circular dependencies
 * - Generate visual SVG and markdown report
 */

import skott from "skott"
import { Graph, alg } from "@dagrejs/graphlib"
import { join, basename, dirname, relative } from "path"

const ROOT = join(import.meta.dir, "..")
const CORE_SRC = join(ROOT, "packages/core/src")
const OUTPUT_DIR = join(ROOT, "scripts")
const GRAPHS_DIR = join(OUTPUT_DIR, "dependency-graphs")

interface FileInfo {
  path: string
  relativePath: string
  dependencies: string[]
  dependents: string[]
  depth: number
  hasTest: boolean
  testFile?: string
  isConvertible: boolean
}

/**
 * Check if a file is "convertible" (should have a conversion task generated)
 * Excludes: test files, examples, assets, testing utilities, benchmarks, index files
 */
function isConvertibleFile(filePath: string): boolean {
  // Exclude test files
  if (filePath.includes(".test.ts")) return false

  // Exclude examples
  if (filePath.includes("/examples/")) return false

  // Exclude assets (images, JSON, wasm, etc.)
  if (filePath.includes("/assets/")) return false

  // Exclude testing utilities
  if (filePath.includes("/testing/")) return false

  // Exclude benchmarks
  if (filePath.includes("/benchmark/")) return false

  // Exclude index/barrel files
  if (filePath.endsWith("/index.ts") || filePath === "index.ts") return false

  // Exclude 3d and zig directories (already excluded by skott, but be safe)
  if (filePath.includes("/3d/") || filePath.includes("/zig/")) return false

  return true
}

/**
 * Convert a file path to a kebab-case name for SVG files
 * e.g., "packages/core/src/lib/RGBA.ts" -> "lib-rgba"
 * e.g., "packages/core/src/types.ts" -> "types"
 * e.g., "packages/core/src/lib/KeyHandler.ts" -> "lib-key-handler"
 */
function toKebabName(filePath: string): string {
  // Remove the packages/core/src/ prefix
  let name = filePath.replace(/^packages\/core\/src\//, "")

  // Remove .ts extension
  name = name.replace(/\.tsx?$/, "")

  // Convert path separators to dashes
  name = name.replace(/\//g, "-")

  // Convert camelCase and PascalCase to kebab-case
  name = name.replace(/([a-z])([A-Z])/g, "$1-$2").toLowerCase()

  // Replace dots with dashes (e.g., parse.keypress -> parse-keypress)
  name = name.replace(/\./g, "-")

  // Clean up multiple dashes
  name = name.replace(/-+/g, "-")

  return name
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
  console.log("   Excluding: 3d/**, zig/**, *.test.ts, *.d.ts\n")

  // Use skott to build dependency graph
  const { getStructure, useGraph } = await skott({
    cwd: CORE_SRC,
    entrypoint: undefined, // Analyze all files
    ignorePatterns: ["3d/**/*", "zig/**/*", "**/*.test.ts", "**/*.d.ts"],
    fileExtensions: [".ts", ".tsx"],
    tsConfigPath: join(ROOT, "packages/core/tsconfig.json"),
    dependencyTracking: {
      builtin: false,
      thirdParty: false,
      typeOnly: true,
    },
  })

  const { graph: skottGraph, files: skottFiles } = getStructure()
  const { findCircularDependencies } = useGraph()

  // Convert skott graph to our format
  const graph: Record<string, string[]> = {}
  for (const [filePath, node] of Object.entries(skottGraph)) {
    graph[filePath] = node.adjacentTo
  }

  // Get circular dependencies from skott
  const circular = findCircularDependencies()

  // Build our own graph for topological sort using graphlib
  const g = new Graph({ directed: true })

  // Add all nodes
  for (const file of skottFiles) {
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
    // skott returns paths relative to cwd, which is CORE_SRC, but prefixed with full path
    // Normalize to get the actual full path
    const fullPath = file.startsWith("packages/") ? join(ROOT, file) : join(CORE_SRC, file)
    const testFile = await findTestFile(fullPath)

    files.set(file, {
      path: fullPath,
      relativePath: file,
      dependencies: graph[file] || [],
      dependents: dependents.get(file) || [],
      depth: depths.get(file) || 0,
      hasTest: !!testFile,
      testFile: testFile ? relative(ROOT, testFile) : undefined,
      isConvertible: isConvertibleFile(file),
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

function generateDotGraph(graph: Record<string, string[]>): string {
  let dot = `digraph Dependencies {\n`
  dot += `  rankdir=LR;\n`
  dot += `  node [shape=box, style=filled, fillcolor=lightblue];\n`
  dot += `  edge [color=gray];\n\n`

  // Add all edges
  for (const [file, deps] of Object.entries(graph)) {
    const fromNode = file.replace(/[/.]/g, "_")
    for (const dep of deps) {
      const toNode = dep.replace(/[/.]/g, "_")
      dot += `  "${fromNode}" -> "${toNode}";\n`
    }
  }

  // Add labels for nodes
  dot += `\n`
  for (const file of Object.keys(graph)) {
    const nodeId = file.replace(/[/.]/g, "_")
    const label = file.length > 30 ? "..." + file.slice(-27) : file
    dot += `  "${nodeId}" [label="${label}"];\n`
  }

  dot += `}\n`
  return dot
}

async function generateSvg(graph: Record<string, string[]>): Promise<void> {
  console.log("📊 Generating SVG dependency graph...")

  const dotContent = generateDotGraph(graph)
  const dotPath = join(OUTPUT_DIR, "dependency-graph.dot")
  const svgPath = join(OUTPUT_DIR, "dependency-graph.svg")

  // Write DOT file
  await Bun.write(dotPath, dotContent)

  // Generate SVG using dot command
  try {
    const proc = Bun.spawn(["dot", "-Tsvg", "-o", svgPath, dotPath], {
      stdout: "pipe",
      stderr: "pipe",
    })

    const exitCode = await proc.exited

    if (exitCode === 0) {
      console.log(`   ✅ Generated: ${relative(ROOT, svgPath)}`)
      // Clean up DOT file
      ;(await Bun.file(dotPath).exists()) && (await Bun.$`rm ${dotPath}`.quiet())
    } else {
      const stderr = await new Response(proc.stderr).text()
      console.error(`   ❌ Failed to generate SVG: ${stderr}`)
      console.log("   💡 Make sure graphviz is installed: sudo apt install graphviz")
    }
  } catch (e) {
    console.error(`   ❌ Failed to generate SVG: ${e}`)
    console.log("   💡 Make sure graphviz is installed: sudo apt install graphviz")
  }
}

/**
 * Generate a DOT graph for a single file showing its dependencies and dependents
 * @param centerFile - The file to center the graph on
 * @param allFiles - Map of all files with their info
 * @param depth - How many levels of deps/dependents to include (1 or 2)
 */
function generatePerFileDot(centerFile: string, allFiles: Map<string, FileInfo>, depth: 1 | 2): string {
  const centerInfo = allFiles.get(centerFile)
  if (!centerInfo) return ""

  const nodesToInclude = new Set<string>([centerFile])
  const edges: Array<{ from: string; to: string; type: "dep" | "dependent" }> = []

  // Collect depth 1 dependencies and dependents
  for (const dep of centerInfo.dependencies) {
    nodesToInclude.add(dep)
    edges.push({ from: centerFile, to: dep, type: "dep" })
  }
  for (const dependent of centerInfo.dependents) {
    nodesToInclude.add(dependent)
    edges.push({ from: dependent, to: centerFile, type: "dependent" })
  }

  // Collect depth 2 if requested
  if (depth === 2) {
    // Dependencies of dependencies
    for (const dep of centerInfo.dependencies) {
      const depInfo = allFiles.get(dep)
      if (depInfo) {
        for (const dep2 of depInfo.dependencies) {
          nodesToInclude.add(dep2)
          edges.push({ from: dep, to: dep2, type: "dep" })
        }
      }
    }
    // Dependents of dependents
    for (const dependent of centerInfo.dependents) {
      const depInfo = allFiles.get(dependent)
      if (depInfo) {
        for (const dep2 of depInfo.dependents) {
          nodesToInclude.add(dep2)
          edges.push({ from: dep2, to: dependent, type: "dependent" })
        }
      }
    }
  }

  // Build DOT content
  let dot = `digraph PerFileDeps {\n`
  dot += `  rankdir=LR;\n`
  dot += `  node [shape=box, style=filled];\n`
  dot += `  edge [color=gray];\n\n`

  // Add nodes with colors
  for (const node of nodesToInclude) {
    const nodeId = node.replace(/[/.]/g, "_")
    const shortLabel = node.replace(/^packages\/core\/src\//, "")
    const label = shortLabel.length > 35 ? "..." + shortLabel.slice(-32) : shortLabel

    let fillColor = "lightblue" // default for depth 2 nodes
    if (node === centerFile) {
      fillColor = "#90EE90" // light green for center
    } else if (centerInfo.dependencies.includes(node)) {
      fillColor = "#FFB6C1" // light pink for direct dependencies
    } else if (centerInfo.dependents.includes(node)) {
      fillColor = "#ADD8E6" // light blue for direct dependents
    }

    dot += `  "${nodeId}" [label="${label}", fillcolor="${fillColor}"];\n`
  }

  dot += `\n`

  // Add edges
  for (const edge of edges) {
    const fromNode = edge.from.replace(/[/.]/g, "_")
    const toNode = edge.to.replace(/[/.]/g, "_")
    dot += `  "${fromNode}" -> "${toNode}";\n`
  }

  dot += `}\n`
  return dot
}

/**
 * Generate per-file SVG graphs for all convertible files
 */
async function generatePerFileGraphs(files: Map<string, FileInfo>): Promise<number> {
  // Create output directory
  await Bun.$`mkdir -p ${GRAPHS_DIR}`.quiet()

  const convertibleFiles = [...files.entries()].filter(([_, info]) => info.isConvertible)
  console.log(`\n📊 Generating per-file dependency graphs for ${convertibleFiles.length} convertible files...`)

  let generated = 0

  for (const [filePath, _info] of convertibleFiles) {
    const kebabName = toKebabName(filePath)

    // Generate depth 1 graph
    const dot1 = generatePerFileDot(filePath, files, 1)
    const dot1Path = join(GRAPHS_DIR, `${kebabName}-depth-1.dot`)
    const svg1Path = join(GRAPHS_DIR, `${kebabName}-depth-1.svg`)

    await Bun.write(dot1Path, dot1)
    const proc1 = Bun.spawn(["dot", "-Tsvg", "-o", svg1Path, dot1Path], {
      stdout: "pipe",
      stderr: "pipe",
    })
    await proc1.exited
    await Bun.$`rm ${dot1Path}`.quiet()

    // Generate depth 2 graph
    const dot2 = generatePerFileDot(filePath, files, 2)
    const dot2Path = join(GRAPHS_DIR, `${kebabName}-depth-2.dot`)
    const svg2Path = join(GRAPHS_DIR, `${kebabName}-depth-2.svg`)

    await Bun.write(dot2Path, dot2)
    const proc2 = Bun.spawn(["dot", "-Tsvg", "-o", svg2Path, dot2Path], {
      stdout: "pipe",
      stderr: "pipe",
    })
    await proc2.exited
    await Bun.$`rm ${dot2Path}`.quiet()

    generated++

    // Progress indicator
    if (generated % 10 === 0 || generated === convertibleFiles.length) {
      process.stdout.write(`\r   Generated ${generated}/${convertibleFiles.length} file pairs...`)
    }
  }

  console.log(`\n   ✅ Generated ${generated * 2} SVG files in scripts/dependency-graphs/`)
  return generated
}

async function main() {
  console.log("=".repeat(60))
  console.log("  OpenTUI Dependency Analysis for C# Conversion")
  console.log("  Powered by skott")
  console.log("=".repeat(60))
  console.log()

  const result = await analyze()

  // Build graph object for SVG generation
  const graph: Record<string, string[]> = {}
  for (const [file, info] of result.files) {
    graph[file] = info.dependencies
  }

  // Generate markdown report
  const mdPath = join(OUTPUT_DIR, "conversion-order.md")
  const mdContent = generateMarkdownReport(result)
  await Bun.write(mdPath, mdContent)
  console.log(`📝 Generated: ${relative(ROOT, mdPath)}`)

  // Generate SVG
  await generateSvg(graph)

  // Generate per-file graphs
  const convertibleCount = await generatePerFileGraphs(result.files)

  console.log()
  console.log("=".repeat(60))
  console.log("  Summary")
  console.log("=".repeat(60))
  console.log(`  Total files:           ${result.files.size}`)
  console.log(`  Convertible files:     ${convertibleCount}`)
  console.log(`  Test coverage:         ${result.testCoverage.covered.length}/${result.files.size}`)
  console.log(`  Circular dependencies: ${result.circularDeps.length}`)
  console.log(`  Examples analyzed:     ${result.examples.length}`)
  console.log(`  Per-file SVGs:         ${convertibleCount * 2}`)
  console.log()

  if (result.circularDeps.length > 0) {
    console.log("⚠️  Circular dependencies detected! See report for details.")
  }
}

main().catch(console.error)
