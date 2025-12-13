# Implement Dependency Graph Analysis for C# Conversion

## Summary

Create a tool to build and visualize the dependency graph of `packages/core/src` to plan the C# conversion order.

## Todo List

- [x] Install prerequisites:
  - [x] `sudo apt install graphviz` (for SVG generation) - user already installed `dot`
  - [x] `bun add -d madge @dagrejs/graphlib`
- [x] Create `scripts/analyze-deps.ts` that:
  - [x] Parses all TypeScript files in `packages/core/src`
  - [x] Excludes `3d/**` and `zig/**` directories
  - [x] Builds dependency graph using madge
  - [x] Performs topological sort using graphlib (leaves → root order)
  - [x] Maps test files to source files (e.g., `KeyHandler.ts` → `KeyHandler.test.ts`)
  - [x] Ranks examples by complexity (fewest internal deps first)
  - [x] Detects circular dependencies
- [x] Generate outputs:
  - [x] `scripts/dependency-graph.svg` - Visual graph with color-coded nodes
  - [x] `scripts/conversion-order.md` - Markdown report with:
    - [x] Conversion phases (grouped by dependency depth)
    - [x] Test coverage mapping
    - [x] Missing test coverage list
    - [x] Examples ranked by complexity
    - [x] Circular dependency warnings (if any)
- [x] Add script to root `package.json`:
  ```json
  "analyze-deps": "bun scripts/analyze-deps.ts"
  ```

## Notes

**Priority:** High (blocks C# conversion planning)

**Labels/Tags:** tooling, c#-conversion, documentation

This task is foundational for planning the TypeScript to C# conversion. The dependency graph will reveal:

- Which files have no dependencies (convert first)
- Which files are most depended upon (critical path items)
- Circular dependencies that need refactoring before conversion
- Test coverage gaps that should be addressed

The topological sort ensures we convert files in an order where dependencies are always converted before the files that depend on them.

### Implementation Notes

- Used `madge` library for dependency analysis with TypeScript support
- Used `@dagrejs/graphlib` for topological sorting via `alg.topsort()`
- Excluded `.test.ts` and `.d.ts` files from dependency graph
- Test file detection checks: co-located, `tests/`, and `__tests__/` directories
- Graphviz `dot` command used by madge for SVG generation

## Results

**Initial Analysis (2025-12-13):**

- Total files analyzed: 128
- Files with tests: 19
- Files missing tests: 104
- Circular dependencies: 53 (needs refactoring)
- Examples analyzed: 39

**Generated Outputs:**

- `scripts/dependency-graph.svg` (296KB) - Visual dependency graph
- `scripts/conversion-order.md` (65KB) - Full markdown report with phases

**Key Findings:**

- Phase 0 (34 files): No dependencies - convert first
- Many circular dependencies exist in `lib/`, `renderables/`, and `examples/` that will need refactoring
- Low test coverage (15%) should be improved during conversion
