# Generate Per-File Dependency Graphs

## Summary

Extend `scripts/analyze-deps.ts` to generate individual SVG dependency graphs for each convertible source file at depth 1 and depth 2.

## Todo List

- [x] Define "convertible files" filter criteria:
  - [x] Exclude `**/*.test.ts` (test files)
  - [x] Exclude `examples/**` (example files)
  - [x] Exclude `**/assets/**` (images, JSON, wasm, etc.)
  - [x] Exclude `testing/**` (testing utilities)
  - [x] Exclude `benchmark/**` (benchmark files)
  - [x] Exclude `index.ts` files (barrel exports)
- [x] Create `scripts/dependency-graphs/` directory
- [x] For each convertible file, generate subgraph data:
  - [x] Depth 1: Direct dependencies and dependents only
  - [x] Depth 2: Dependencies/dependents of dependencies/dependents
- [x] Generate DOT format for each subgraph:
  - [x] Center node highlighted (the file itself)
  - [x] Dependencies in one color
  - [x] Dependents in another color
- [x] Render SVGs using `dot` command:
  - [x] `{name}-depth-1.svg` for each file
  - [x] `{name}-depth-2.svg` for each file
- [x] Update console output to show progress
- [x] Handle files with special characters in names (kebab-case output)

## Notes

**Priority:** Medium (depends on skott migration)

**Labels/Tags:** tooling, c#-conversion, visualization

**Depends on:** Task 002 (skott migration) - COMPLETED

### Naming Convention

Files are named using kebab-case:

- `packages/core/src/lib/RGBA.ts` -> `lib-rgba-depth-1.svg`, `lib-rgba-depth-2.svg`
- `packages/core/src/types.ts` -> `types-depth-1.svg`, `types-depth-2.svg`
- `packages/core/src/lib/KeyHandler.ts` -> `lib-key-handler-depth-1.svg`, `lib-key-handler-depth-2.svg`

### Implementation Details

**Functions added to `scripts/analyze-deps.ts`:**

- `isConvertibleFile(filePath)` - Checks if a file should have conversion tasks generated
- `toKebabName(filePath)` - Converts file path to kebab-case SVG filename
- `generatePerFileDot(centerFile, allFiles, depth)` - Generates DOT format for a file's subgraph
- `generatePerFileGraphs(files)` - Orchestrates per-file SVG generation

**Color coding in SVGs:**

- Light green (`#90EE90`) - Center file (the file being analyzed)
- Light pink (`#FFB6C1`) - Direct dependencies (imports)
- Light blue (`#ADD8E6`) - Direct dependents (imported by)
- Default light blue - Depth 2 nodes

## Results

**Completed 2025-12-13**

Generated output:

- **59 convertible files** identified (out of 110 total)
- **118 SVG files** generated (59 × 2 depths)
- Output directory: `scripts/dependency-graphs/`

Sample files generated:

```
scripts/dependency-graphs/
├── 3d-depth-1.svg (8.8KB)
├── 3d-depth-2.svg (13.7KB)
├── animation-timeline-depth-1.svg (4KB)
├── animation-timeline-depth-2.svg (54.8KB)
├── buffer-depth-1.svg (18KB)
├── buffer-depth-2.svg (115.8KB)
├── lib-rgba-depth-1.svg
├── lib-rgba-depth-2.svg
├── renderer-depth-1.svg
├── renderer-depth-2.svg
├── types-depth-1.svg
├── types-depth-2.svg
└── ... (118 total files)
```

Depth-2 graphs are significantly larger as they include 2nd-level dependencies/dependents.
