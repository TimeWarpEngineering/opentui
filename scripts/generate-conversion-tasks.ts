#!/usr/bin/env bun
/**
 * Generate Conversion Task Files for C# Migration
 *
 * This script generates kanban task files for each convertible TypeScript file,
 * plus a master checklist to track overall C# conversion progress.
 *
 * Features:
 * - Parses test files to extract test structure (3 patterns)
 * - Converts test names to C# naming convention (Pascal_Snake_Case)
 * - Generates individual task files with test mappings
 * - Generates master checklist grouped by phase
 */

import { join, basename, dirname, relative } from "path"
import skott from "skott"
import { Graph } from "@dagrejs/graphlib"

const ROOT = join(import.meta.dir, "..")
const CORE_SRC = join(ROOT, "packages/core/src")
const KANBAN_DIR = join(ROOT, "kanban")
const TODO_DIR = join(KANBAN_DIR, "to-do")

// ============================================================================
// Types
// ============================================================================

interface TestClass {
  className: string
  tests: Array<{ tsName: string; csName: string }>
}

interface TestStructure {
  pattern: "nested-describe" | "flat-test-prefix" | "describe-test"
  classes: TestClass[]
  outputType: "folder" | "single-file"
}

interface FileInfo {
  path: string
  relativePath: string
  dependencies: string[]
  dependents: string[]
  depth: number
  hasTest: boolean
  testFile?: string
  isConvertible: boolean
  testStructure?: TestStructure
}

// ============================================================================
// Test Name Conversion
// ============================================================================

/**
 * Convert a test name to Pascal_Snake_Case
 * e.g., "should initialize properly" → "Should_Initialize_Properly"
 * e.g., "handles modifier keys correctly" → "Handles_Modifier_Keys_Correctly"
 * e.g., "should support 'in' operator" → "Should_Support_In_Operator"
 */
function toPascalSnakeCase(testName: string): string {
  // Remove quotes and other non-word characters that aren't spaces
  const cleaned = testName.replace(/['"]/g, "")

  return cleaned
    .split(/\s+/)
    .filter((word) => word.length > 0)
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
    .join("_")
}

/**
 * Convert a class/describe name to PascalCase
 * e.g., "env registry" → "EnvRegistry"
 * e.g., "Focus Management" → "FocusManagement"
 */
function toPascalCase(name: string): string {
  return name
    .split(/[\s-_]+/)
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
    .join("")
}

/**
 * Convert a file path to a kebab-case name
 * e.g., "packages/core/src/lib/RGBA.ts" -> "lib-rgba"
 */
function toKebabName(filePath: string): string {
  let name = filePath.replace(/^packages\/core\/src\//, "")
  name = name.replace(/\.tsx?$/, "")
  name = name.replace(/\//g, "-")
  name = name.replace(/([a-z])([A-Z])/g, "$1-$2").toLowerCase()
  name = name.replace(/\./g, "-")
  name = name.replace(/-+/g, "-")
  return name
}

// ============================================================================
// Test File Parsing
// ============================================================================

interface ParsedDescribe {
  name: string
  tests: string[]
  nestedDescribes: ParsedDescribe[]
}

/**
 * Parse a test file to extract its structure
 */
async function parseTestFile(testFilePath: string): Promise<TestStructure | undefined> {
  const fullPath = testFilePath.startsWith("/") ? testFilePath : join(ROOT, testFilePath)

  if (!(await Bun.file(fullPath).exists())) {
    return undefined
  }

  const content = await Bun.file(fullPath).text()

  // Try to detect the pattern
  const hasDescribe = /\bdescribe\s*\(/.test(content)
  const hasIt = /\bit\s*\(/.test(content)
  const hasTopLevelTest = /^test\s*\(/m.test(content) || /\n\s*test\s*\(/m.test(content)

  // Pattern 1: Nested describe/it (describe with nested describes containing it blocks)
  if (hasDescribe && hasIt) {
    const structure = parseNestedDescribe(content)
    if (structure && structure.nestedDescribes.length > 0) {
      return {
        pattern: "nested-describe",
        outputType: "folder",
        classes: structure.nestedDescribes.map((inner) => ({
          className: toPascalCase(inner.name),
          tests: inner.tests.map((t) => ({
            tsName: t,
            csName: toPascalSnakeCase(t),
          })),
        })),
      }
    }
  }

  // Pattern 3: describe with test blocks (single describe, uses test() not it())
  if (hasDescribe && !hasIt && hasTopLevelTest) {
    const structure = parseDescribeWithTests(content)
    if (structure) {
      return {
        pattern: "describe-test",
        outputType: "single-file",
        classes: [
          {
            className: toPascalCase(structure.name),
            tests: structure.tests.map((t) => ({
              tsName: t,
              csName: toPascalSnakeCase(t),
            })),
          },
        ],
      }
    }
  }

  // Pattern 2: Flat test with prefix
  if (hasTopLevelTest && !hasDescribe) {
    const classes = parseFlatTestsWithPrefix(content)
    if (classes.length > 0) {
      return {
        pattern: "flat-test-prefix",
        outputType: classes.length > 1 ? "single-file" : "single-file",
        classes,
      }
    }
  }

  // Fallback: try to extract any tests we can find
  const fallbackTests = extractAllTests(content)
  if (fallbackTests.length > 0) {
    const fileName = basename(testFilePath, ".test.ts")
    return {
      pattern: "flat-test-prefix",
      outputType: "single-file",
      classes: [
        {
          className: toPascalCase(fileName),
          tests: fallbackTests.map((t) => ({
            tsName: t,
            csName: toPascalSnakeCase(t),
          })),
        },
      ],
    }
  }

  return undefined
}

/**
 * Parse nested describe blocks (Pattern 1)
 */
function parseNestedDescribe(content: string): ParsedDescribe | undefined {
  // Find the outer describe
  const outerMatch = content.match(/describe\s*\(\s*["'`]([^"'`]+)["'`]\s*,/)
  if (!outerMatch) return undefined

  const outerName = outerMatch[1]
  const nestedDescribes: ParsedDescribe[] = []

  // Find all nested describe blocks
  // We need to match describe blocks that are inside the outer one
  const describeRegex = /describe\s*\(\s*["'`]([^"'`]+)["'`]\s*,\s*\(\s*\)\s*=>\s*\{/g
  let match: RegExpExecArray | null

  // Skip the first match (outer describe)
  describeRegex.exec(content)

  while ((match = describeRegex.exec(content)) !== null) {
    const describeName = match[1]

    // Find tests within this describe block
    // Look for it() calls after this describe until the next describe or end
    const startPos = match.index + match[0].length
    const tests: string[] = []

    // Find all it() calls
    const itRegex = /\bit\s*\(\s*["'`]([^"'`]+)["'`]/g
    itRegex.lastIndex = startPos

    // Find the approximate end of this describe block
    let braceCount = 1
    let endPos = startPos
    for (let i = startPos; i < content.length && braceCount > 0; i++) {
      if (content[i] === "{") braceCount++
      if (content[i] === "}") braceCount--
      endPos = i
    }

    let itMatch: RegExpExecArray | null
    while ((itMatch = itRegex.exec(content)) !== null) {
      if (itMatch.index > endPos) break
      tests.push(itMatch[1])
    }

    if (tests.length > 0) {
      nestedDescribes.push({
        name: describeName,
        tests,
        nestedDescribes: [],
      })
    }
  }

  return {
    name: outerName,
    tests: [],
    nestedDescribes,
  }
}

/**
 * Extract string content from a quoted string, handling nested quotes
 * Supports: "string", 'string', `string`
 */
function extractQuotedString(content: string, startIndex: number): { value: string; endIndex: number } | null {
  const quote = content[startIndex]
  if (quote !== '"' && quote !== "'" && quote !== "`") return null

  let value = ""
  let i = startIndex + 1
  while (i < content.length) {
    const char = content[i]
    if (char === quote) {
      return { value, endIndex: i }
    }
    if (char === "\\" && i + 1 < content.length) {
      // Handle escape sequences
      value += content[i + 1]
      i += 2
      continue
    }
    value += char
    i++
  }
  return null
}

/**
 * Parse describe with test blocks (Pattern 3)
 */
function parseDescribeWithTests(content: string): ParsedDescribe | undefined {
  const describeMatch = content.match(/describe\s*\(\s*["'`]([^"'`]+)["'`]/)
  if (!describeMatch) return undefined

  const tests: string[] = []

  // Find all test() calls and extract their names more carefully
  const testStartRegex = /\btest\s*\(\s*(["'`])/g
  let testMatch: RegExpExecArray | null

  while ((testMatch = testStartRegex.exec(content)) !== null) {
    const quoteStart = testMatch.index + testMatch[0].length - 1
    const extracted = extractQuotedString(content, quoteStart)
    if (extracted) {
      tests.push(extracted.value)
    }
  }

  return {
    name: describeMatch[1],
    tests,
    nestedDescribes: [],
  }
}

/**
 * Parse flat tests with prefix (Pattern 2)
 * e.g., "KeyHandler - emits events" → class KeyHandler, test "emits events"
 */
function parseFlatTestsWithPrefix(content: string): TestClass[] {
  const classMap = new Map<string, string[]>()

  // Find all test() calls and extract their names
  const testStartRegex = /\btest\s*\(\s*(["'`])/g
  let testMatch: RegExpExecArray | null

  while ((testMatch = testStartRegex.exec(content)) !== null) {
    const quoteStart = testMatch.index + testMatch[0].length - 1
    const extracted = extractQuotedString(content, quoteStart)
    if (!extracted) continue

    const testName = extracted.value

    // Check for prefix pattern "ClassName - test description"
    const prefixMatch = testName.match(/^([A-Za-z][A-Za-z0-9]*)\s*-\s*(.+)$/)

    if (prefixMatch) {
      const className = prefixMatch[1]
      const testDesc = prefixMatch[2]

      if (!classMap.has(className)) {
        classMap.set(className, [])
      }
      classMap.get(className)!.push(testDesc)
    } else {
      // No prefix, use "Tests" as default class name
      if (!classMap.has("Tests")) {
        classMap.set("Tests", [])
      }
      classMap.get("Tests")!.push(testName)
    }
  }

  return Array.from(classMap.entries()).map(([className, tests]) => ({
    className: toPascalCase(className),
    tests: tests.map((t) => ({
      tsName: t,
      csName: toPascalSnakeCase(t),
    })),
  }))
}

/**
 * Extract all tests as fallback
 */
function extractAllTests(content: string): string[] {
  const tests: string[] = []

  // Find all test() and it() calls
  const testStartRegex = /\b(?:test|it)\s*\(\s*(["'`])/g
  let testMatch: RegExpExecArray | null

  while ((testMatch = testStartRegex.exec(content)) !== null) {
    const quoteStart = testMatch.index + testMatch[0].length - 1
    const extracted = extractQuotedString(content, quoteStart)
    if (extracted) {
      tests.push(extracted.value)
    }
  }

  return tests
}

// ============================================================================
// File Analysis (reused from analyze-deps.ts)
// ============================================================================

function isConvertibleFile(filePath: string): boolean {
  if (filePath.includes(".test.ts")) return false
  if (filePath.includes("/examples/")) return false
  if (filePath.includes("/assets/")) return false
  if (filePath.includes("/testing/")) return false
  if (filePath.includes("/benchmark/")) return false
  if (filePath.endsWith("/index.ts") || filePath === "index.ts") return false
  if (filePath.includes("/3d/") || filePath.includes("/zig/")) return false
  return true
}

async function findTestFile(sourceFile: string): Promise<string | undefined> {
  const dir = dirname(sourceFile)
  const base = basename(sourceFile, ".ts")

  const colocatedTest = join(dir, `${base}.test.ts`)
  if (await Bun.file(colocatedTest).exists()) {
    return colocatedTest
  }

  const testsDir = join(dir, "tests", `${base}.test.ts`)
  if (await Bun.file(testsDir).exists()) {
    return testsDir
  }

  const underscoreTestsDir = join(dir, "__tests__", `${base}.test.ts`)
  if (await Bun.file(underscoreTestsDir).exists()) {
    return underscoreTestsDir
  }

  return undefined
}

async function analyzeFiles(): Promise<Map<string, FileInfo>> {
  console.log("🔍 Analyzing dependencies...")

  const { getStructure } = await skott({
    cwd: CORE_SRC,
    entrypoint: undefined,
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

  const graph: Record<string, string[]> = {}
  for (const [filePath, node] of Object.entries(skottGraph)) {
    graph[filePath] = node.adjacentTo
  }

  // Build graphlib graph for topological sort
  const g = new Graph({ directed: true })
  for (const file of skottFiles) {
    g.setNode(file)
  }
  for (const [file, deps] of Object.entries(graph)) {
    for (const dep of deps) {
      if (g.hasNode(dep)) {
        g.setEdge(dep, file)
      }
    }
  }

  // Calculate depths
  const depths = new Map<string, number>()
  function calculateDepth(file: string, visited = new Set<string>()): number {
    if (depths.has(file)) return depths.get(file)!
    if (visited.has(file)) return 0
    visited.add(file)
    const deps = graph[file] || []
    const maxDepDep = deps.length === 0 ? 0 : Math.max(...deps.map((d) => calculateDepth(d, visited) + 1))
    depths.set(file, maxDepDep)
    return maxDepDep
  }

  for (const file of Object.keys(graph)) {
    calculateDepth(file)
  }

  // Build dependents map
  const dependents = new Map<string, string[]>()
  for (const [file, deps] of Object.entries(graph)) {
    for (const dep of deps) {
      if (!dependents.has(dep)) dependents.set(dep, [])
      dependents.get(dep)!.push(file)
    }
  }

  // Build file info
  const files = new Map<string, FileInfo>()

  for (const file of Object.keys(graph)) {
    const fullPath = file.startsWith("packages/") ? join(ROOT, file) : join(CORE_SRC, file)
    const testFile = await findTestFile(fullPath)

    let testStructure: TestStructure | undefined
    if (testFile) {
      testStructure = await parseTestFile(testFile)
    }

    files.set(file, {
      path: fullPath,
      relativePath: file,
      dependencies: graph[file] || [],
      dependents: dependents.get(file) || [],
      depth: depths.get(file) || 0,
      hasTest: !!testFile,
      testFile: testFile ? relative(ROOT, testFile) : undefined,
      isConvertible: isConvertibleFile(file),
      testStructure,
    })
  }

  return files
}

// ============================================================================
// Task File Generation
// ============================================================================

function generateTaskFile(
  file: string,
  info: FileInfo,
  _taskNumber: number,
  allFiles: Map<string, FileInfo>,
  taskNumberMap: Map<string, number>,
): string {
  const kebabName = toKebabName(file)
  const displayName = file.replace(/^packages\/core\/src\//, "")

  let md = `# Convert ${displayName} to C#

## Overview

- **Repo**: \`${ROOT}\`
- **Source**: \`${file}\`
- **Phase**: ${info.depth}
- **Test Coverage**: ${info.hasTest ? `✅ \`${info.testFile}\`` : "❌ No tests"}

## Dependencies (convert these first)

`

  if (info.dependencies.length === 0) {
    md += "_None - this file has no dependencies_\n"
  } else {
    for (const dep of info.dependencies) {
      const depInfo = allFiles.get(dep)
      if (depInfo?.isConvertible) {
        const depTaskNum = taskNumberMap.get(dep)
        const depKebab = toKebabName(dep)
        md += `- [ ] \`${dep}\` → [task](./${depTaskNum}-convert-${depKebab}.md)\n`
      } else {
        md += `- [ ] \`${dep}\` _(not convertible)_\n`
      }
    }
  }

  md += `
## Dependents (blocked until this is done)

`

  const convertibleDependents = info.dependents.filter((d) => allFiles.get(d)?.isConvertible)
  if (convertibleDependents.length === 0) {
    md += "_None - no files depend on this_\n"
  } else {
    for (const dep of convertibleDependents) {
      md += `- \`${dep}\`\n`
    }
  }

  md += `
## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/${kebabName}-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/${kebabName}-depth-2.svg)

## Tests

`

  if (info.testStructure && info.testStructure.classes.length > 0) {
    for (const testClass of info.testStructure.classes) {
      md += `### Class: ${testClass.className}

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
`
      for (const test of testClass.tests) {
        md += `| \`${test.tsName}\` | \`${test.csName}\` |\n`
      }
      md += "\n"
    }
  } else if (info.hasTest) {
    md += "_Test file exists but structure could not be parsed_\n\n"
  } else {
    md += "_No tests to convert_\n\n"
  }

  md += `## Test Execution

\`\`\`bash
# Run TypeScript tests
cd packages/core && bun test ${info.testFile || displayName.replace(".ts", ".test.ts")}

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
`

  if (info.testStructure && info.testStructure.classes.length > 0) {
    const firstClass = info.testStructure.classes[0]
    md += `dotnet fixie --tests "${firstClass.className}.*"\n`
  } else {
    md += `dotnet fixie --tests "${toPascalCase(basename(displayName, ".ts"))}.*"\n`
  }

  md += `\`\`\`

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
`

  return md
}

function generateMasterChecklist(files: Map<string, FileInfo>, taskNumberMap: Map<string, number>): string {
  // Group by phase
  const phases = new Map<number, string[]>()
  let totalConvertible = 0

  for (const [file, info] of files) {
    if (!info.isConvertible) continue
    totalConvertible++

    const depth = info.depth
    if (!phases.has(depth)) phases.set(depth, [])
    phases.get(depth)!.push(file)
  }

  // Sort phases
  const sortedPhases = [...phases.entries()].sort((a, b) => a[0] - b[0])

  let md = `# C# Conversion Checklist

## Progress

- **Total files**: ${totalConvertible}
- **Completed**: 0
- **Remaining**: ${totalConvertible}

---

`

  for (const [depth, phaseFiles] of sortedPhases) {
    md += `## Phase ${depth} (${phaseFiles.length} files)

`
    // Sort files within phase alphabetically
    phaseFiles.sort()

    for (const file of phaseFiles) {
      const info = files.get(file)!
      const taskNum = taskNumberMap.get(file)!
      const kebabName = toKebabName(file)
      const testIcon = info.hasTest ? "✅" : "⚠️"

      md += `- [ ] ${testIcon} [${file}](./${taskNum}-convert-${kebabName}.md)\n`
    }
    md += "\n"
  }

  md += `---

## Legend

- ✅ Has test coverage
- ⚠️ Missing test coverage

## Notes

- Convert files in phase order (Phase 0 first, then Phase 1, etc.)
- Within a phase, files can be converted in any order
- Check off each file as you complete the conversion
`

  return md
}

// ============================================================================
// Main
// ============================================================================

async function main() {
  console.log("=".repeat(60))
  console.log("  Generate Conversion Task Files")
  console.log("=".repeat(60))
  console.log()

  // Analyze files
  const files = await analyzeFiles()

  // Filter to convertible files only
  const convertibleFiles = [...files.entries()]
    .filter(([_, info]) => info.isConvertible)
    .sort((a, b) => {
      // Sort by depth first, then alphabetically
      if (a[1].depth !== b[1].depth) return a[1].depth - b[1].depth
      return a[0].localeCompare(b[0])
    })

  console.log(`\n📋 Found ${convertibleFiles.length} convertible files`)

  // Create task number mapping (starting at 202, 201 is the checklist)
  const taskNumberMap = new Map<string, number>()
  let taskNum = 202

  for (const [file, _] of convertibleFiles) {
    taskNumberMap.set(file, taskNum++)
  }

  // Create to-do directory
  await Bun.$`mkdir -p ${TODO_DIR}`.quiet()

  // Generate individual task files
  console.log("\n📝 Generating task files...")
  let generated = 0

  for (const [file, info] of convertibleFiles) {
    const num = taskNumberMap.get(file)!
    const kebabName = toKebabName(file)
    const fileName = `${num}-convert-${kebabName}.md`
    const filePath = join(TODO_DIR, fileName)

    const content = generateTaskFile(file, info, num, files, taskNumberMap)
    await Bun.write(filePath, content)

    generated++
    if (generated % 10 === 0 || generated === convertibleFiles.length) {
      process.stdout.write(`\r   Generated ${generated}/${convertibleFiles.length} task files...`)
    }
  }

  console.log(`\n   ✅ Generated ${generated} task files`)

  // Generate master checklist
  console.log("\n📋 Generating master checklist...")
  const checklistContent = generateMasterChecklist(files, taskNumberMap)
  const checklistPath = join(TODO_DIR, "201-conversion-checklist.md")
  await Bun.write(checklistPath, checklistContent)
  console.log(`   ✅ Generated ${relative(ROOT, checklistPath)}`)

  // Summary
  console.log()
  console.log("=".repeat(60))
  console.log("  Summary")
  console.log("=".repeat(60))

  const withTests = convertibleFiles.filter(([_, info]) => info.hasTest).length
  const withParsedTests = convertibleFiles.filter(([_, info]) => info.testStructure).length

  console.log(`  Total task files:      ${generated}`)
  console.log(`  Files with tests:      ${withTests}`)
  console.log(`  Tests parsed:          ${withParsedTests}`)
  console.log(`  Output directory:      kanban/to-do/`)
  console.log()
}

main().catch(console.error)
