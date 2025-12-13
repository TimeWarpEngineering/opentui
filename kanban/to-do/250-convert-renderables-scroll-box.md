# Convert renderables/ScrollBox.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/ScrollBox.ts`
- **Phase**: 8
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/index.ts` _(not convertible)_
- [ ] `packages/core/src/lib/objects-in-viewport.ts` → [task](./220-convert-lib-objects-in-viewport.md)
- [ ] `packages/core/src/lib/scroll-acceleration.ts` → [task](./209-convert-lib-scroll-acceleration.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/renderer.ts` → [task](./258-convert-renderer.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/renderables/Box.ts` → [task](./248-convert-renderables-box.md)
- [ ] `packages/core/src/renderables/composition/vnode.ts` → [task](./226-convert-renderables-composition-vnode.md)
- [ ] `packages/core/src/renderables/ScrollBar.ts` → [task](./249-convert-renderables-scroll-bar.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-scroll-box-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-scroll-box-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test renderables/ScrollBox.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ScrollBox.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
