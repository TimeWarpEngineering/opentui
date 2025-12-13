# Migrate Dependency Analysis from madge to skott

## Summary

Replace madge with skott for dependency analysis to enable per-file subgraph generation and better TypeScript support.

## Todo List

- [x] Install skott and @skottorg/static-file-plugin
- [x] Remove madge dependency (keep @dagrejs/graphlib for topological sort)
- [x] Update `scripts/analyze-deps.ts` to use skott API:
  - [x] Use `skott()` to build the dependency graph
  - [x] Use `useGraph()` for circular dependency detection
  - [x] Use `getStructure()` for graph data
  - [x] Keep topological sort logic using graphlib
- [x] Verify overall dependency-graph.svg generates correctly
- [x] Verify conversion-order.md generates correctly
- [x] Test with `bun run analyze-deps`

## Notes

**Priority:** High (blocks per-file graph generation)

**Labels/Tags:** tooling, c#-conversion, refactoring

### Why skott over madge?

| Feature                       | madge   | skott                                |
| ----------------------------- | ------- | ------------------------------------ |
| Per-file subgraph extraction  | No      | Yes via `collectFilesDependencies()` |
| Graph traversal API           | Limited | Full BFS/DFS                         |
| TypeScript path aliases       | Basic   | Full support                         |
| Unused file detection         | No      | Yes                                  |
| Start traversal from any node | No      | Yes                                  |

### Dependencies

- `skott` - Main dependency analysis library
- `@skottorg/static-file-plugin` - For SVG/PNG generation (installed but not yet used - using DOT directly)
- Keep `@dagrejs/graphlib` - For topological sort

### Implementation Notes

- skott returns paths prefixed with full path from cwd (e.g., `packages/core/src/lib/env.ts`)
- Generated DOT format manually and rendered with `dot` command instead of using static-file-plugin
- Kept the same markdown report format for compatibility

## Results

**Migration completed successfully (2025-12-13)**

Analysis output:

- Total files: 110 (vs 128 with madge - cleaner filtering)
- Test coverage: 19/110 files have tests
- Circular dependencies: 117 detected
- Examples analyzed: 39

Generated files:

- `scripts/dependency-graph.svg` (266KB)
- `scripts/conversion-order.md` (116KB)

Next step: Task 003 - Generate per-file dependency graphs using skott's `collectFilesDependencies()` and `collectFilesDependingOn()` APIs.
