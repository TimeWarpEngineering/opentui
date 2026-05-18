#!/usr/bin/env bun
/**
 * Add C# target paths to all conversion task files
 *
 * This script adds a "Target" line to the Overview section of all conversion
 * task files (202-260), specifying where the C# file should be created.
 */

import { join, basename, dirname } from "path"
import { Glob } from "bun"

const ROOT = join(import.meta.dir, "..")
const TODO_DIR = join(ROOT, "kanban/to-do")

/**
 * Convert a source path to a C# target path
 *
 * Rules:
 * 1. Strip `packages/core/src/` prefix
 * 2. Convert filename to kebab-case
 * 3. Preserve directory structure
 * 4. Change `.ts` extension to `.cs`
 *
 * Examples:
 * - packages/core/src/lib/RGBA.ts -> source/timewarp-tui-core/lib/rgba.cs
 * - packages/core/src/renderables/Input.ts -> source/timewarp-tui-core/renderables/input.cs
 * - packages/core/src/3d.ts -> source/timewarp-tui-core/3d.cs
 * - packages/core/src/lib/tree-sitter/client.ts -> source/timewarp-tui-core/lib/tree-sitter/client.cs
 * - packages/core/src/lib/KeyHandler.ts -> source/timewarp-tui-core/lib/key-handler.cs
 */
function sourceToTargetPath(sourcePath: string): string {
  // Strip the prefix
  let path = sourcePath.replace(/^packages\/core\/src\//, "")

  // Get directory and filename separately
  const dir = dirname(path)
  const file = basename(path, ".ts")

  // Convert filename to kebab-case:
  // - ASCIIFont -> ascii-font
  // - RGBA -> rgba
  // - KeyHandler -> key-handler
  // - TextNode -> text-node
  // - parse.keypress -> parse-keypress
  let kebabFile = file
    // Insert hyphen before uppercase letters (except at start or after another uppercase)
    .replace(/([a-z])([A-Z])/g, "$1-$2")
    // Handle sequences like "ASCII" -> keep as is, then handle transition to next word
    .replace(/([A-Z]+)([A-Z][a-z])/g, "$1-$2")
    // Replace dots with hyphens
    .replace(/\./g, "-")
    // Lowercase everything
    .toLowerCase()
    // Clean up multiple hyphens
    .replace(/-+/g, "-")

  // Reconstruct the path
  const targetDir = dir === "." ? "" : dir + "/"
  return `source/timewarp-tui-core/${targetDir}${kebabFile}.cs`
}

/**
 * Extract the source path from a task file content
 */
function extractSourcePath(content: string): string | null {
  const match = content.match(/- \*\*Source\*\*: `([^`]+)`/)
  return match ? match[1] : null
}

/**
 * Add target path to a task file content
 */
function addTargetPath(content: string, targetPath: string): string {
  // Check if Target already exists
  if (content.includes("- **Target**:")) {
    console.log("   (already has Target)")
    return content
  }

  // Insert Target line after Source line
  return content.replace(/- \*\*Source\*\*: `([^`]+)`\n/, `- **Source**: \`$1\`\n- **Target**: \`${targetPath}\`\n`)
}

async function main() {
  console.log("=".repeat(60))
  console.log("  Add C# Target Paths to Conversion Task Files")
  console.log("=".repeat(60))
  console.log()

  // Find all conversion task files (202-260)
  const glob = new Glob("2[0-5][0-9]-convert-*.md")
  const glob260 = new Glob("260-convert-*.md")

  const files: string[] = []
  for await (const file of glob.scan(TODO_DIR)) {
    const num = parseInt(file.split("-")[0])
    if (num >= 202 && num <= 259) {
      files.push(join(TODO_DIR, file))
    }
  }
  for await (const file of glob260.scan(TODO_DIR)) {
    files.push(join(TODO_DIR, file))
  }

  files.sort()
  console.log(`📋 Found ${files.length} conversion task files\n`)

  let updated = 0
  let skipped = 0

  for (const filePath of files) {
    const fileName = basename(filePath)
    process.stdout.write(`Processing ${fileName}...`)

    const content = await Bun.file(filePath).text()
    const sourcePath = extractSourcePath(content)

    if (!sourcePath) {
      console.log(" ❌ No source path found")
      skipped++
      continue
    }

    const targetPath = sourceToTargetPath(sourcePath)
    const newContent = addTargetPath(content, targetPath)

    if (newContent === content) {
      console.log(" (no changes)")
      skipped++
      continue
    }

    await Bun.write(filePath, newContent)
    console.log(` ✅ Added target: ${targetPath}`)
    updated++
  }

  console.log()
  console.log("=".repeat(60))
  console.log("  Summary")
  console.log("=".repeat(60))
  console.log(`  Updated: ${updated}`)
  console.log(`  Skipped: ${skipped}`)
  console.log()
}

main().catch(console.error)
