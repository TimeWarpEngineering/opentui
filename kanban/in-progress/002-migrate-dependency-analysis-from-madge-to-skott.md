# Migrate Dependency Analysis from madge to skott

## Summary

Replace madge with skott for dependency analysis to enable per-file subgraph generation and better TypeScript support.

## Todo List

- [ ] Install skott and @skottorg/static-file-plugin
- [ ] Remove madge dependency (keep @dagrejs/graphlib for topological sort)
- [ ] Update `scripts/analyze-deps.ts` to use skott API:
  - [ ] Use `skott()` to build the dependency graph
  - [ ] Use `useGraph()` for circular dependency detection
  - [ ] Use `getStructure()` for graph data
  - [ ] Keep topological sort logic using graphlib
- [ ] Verify overall dependency-graph.svg generates correctly
- [ ] Verify conversion-order.md generates correctly
- [ ] Test with `bun run analyze-deps`

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
- `@skottorg/static-file-plugin` - For SVG/PNG generation
- Keep `@dagrejs/graphlib` - For topological sort

## Results

{Added after completion}
