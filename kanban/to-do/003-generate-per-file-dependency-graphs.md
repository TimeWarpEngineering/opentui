# Generate Per-File Dependency Graphs

## Summary

Extend `scripts/analyze-deps.ts` to generate individual SVG dependency graphs for each convertible source file at depth 1 and depth 2.

## Todo List

- [ ] Define "convertible files" filter criteria:
  - [ ] Exclude `**/*.test.ts` (test files)
  - [ ] Exclude `examples/**` (example files)
  - [ ] Exclude `**/assets/**` (images, JSON, wasm, etc.)
  - [ ] Exclude `testing/**` (testing utilities)
  - [ ] Exclude `benchmark/**` (benchmark files)
  - [ ] Exclude `index.ts` files (barrel exports)
- [ ] Create `scripts/dependency-graphs/` directory
- [ ] For each convertible file, generate subgraph data:
  - [ ] Depth 1: Direct dependencies and dependents only
  - [ ] Depth 2: Dependencies/dependents of dependencies/dependents
- [ ] Generate DOT format for each subgraph:
  - [ ] Center node highlighted (the file itself)
  - [ ] Dependencies in one color
  - [ ] Dependents in another color
- [ ] Render SVGs using `dot` command:
  - [ ] `{name}-depth-1.svg` for each file
  - [ ] `{name}-depth-2.svg` for each file
- [ ] Update console output to show progress
- [ ] Handle files with special characters in names (kebab-case output)

## Notes

**Priority:** Medium (depends on skott migration)

**Labels/Tags:** tooling, c#-conversion, visualization

**Depends on:** Task 002 (skott migration)

### Naming Convention

Files will be named using kebab-case:

- `packages/core/src/lib/RGBA.ts` -> `lib-rgba-depth-1.svg`, `lib-rgba-depth-2.svg`
- `packages/core/src/types.ts` -> `types-depth-1.svg`, `types-depth-2.svg`
- `packages/core/src/lib/KeyHandler.ts` -> `lib-key-handler-depth-1.svg`, `lib-key-handler-depth-2.svg`

### Expected Output

```
scripts/dependency-graphs/
├── lib-rgba-depth-1.svg
├── lib-rgba-depth-2.svg
├── types-depth-1.svg
├── types-depth-2.svg
├── renderer-depth-1.svg
├── renderer-depth-2.svg
└── ... (~50 file pairs)
```

## Results

{Added after completion}
