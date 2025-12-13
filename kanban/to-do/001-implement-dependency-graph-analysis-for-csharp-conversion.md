# Implement Dependency Graph Analysis for C# Conversion

## Summary

Create a tool to build and visualize the dependency graph of `packages/core/src` to plan the C# conversion order.

## Todo List

- [ ] Install prerequisites:
  - [ ] `sudo apt install graphviz` (for SVG generation)
  - [ ] `bun add -d madge @dagrejs/graphlib`
- [ ] Create `scripts/analyze-deps.ts` that:
  - [ ] Parses all TypeScript files in `packages/core/src`
  - [ ] Excludes `3d/**` and `zig/**` directories
  - [ ] Builds dependency graph using madge
  - [ ] Performs topological sort using graphlib (leaves → root order)
  - [ ] Maps test files to source files (e.g., `KeyHandler.ts` → `KeyHandler.test.ts`)
  - [ ] Ranks examples by complexity (fewest internal deps first)
  - [ ] Detects circular dependencies
- [ ] Generate outputs:
  - [ ] `scripts/dependency-graph.svg` - Visual graph with color-coded nodes
  - [ ] `scripts/conversion-order.md` - Markdown report with:
    - [ ] Conversion phases (grouped by dependency depth)
    - [ ] Test coverage mapping
    - [ ] Missing test coverage list
    - [ ] Examples ranked by complexity
    - [ ] Circular dependency warnings (if any)
- [ ] Add script to root `package.json`:
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

## Results

{Added after completion}
