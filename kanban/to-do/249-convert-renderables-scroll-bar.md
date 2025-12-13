# Convert renderables/ScrollBar.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/ScrollBar.ts`
- **Phase**: 7
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/lib/index.ts` _(not convertible)_
- [ ] `packages/core/src/lib/KeyHandler.ts` → [task](./241-convert-lib-key-handler.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/renderables/Box.ts` → [task](./248-convert-renderables-box.md)
- [ ] `packages/core/src/renderables/Slider.ts` → [task](./229-convert-renderables-slider.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderables/ScrollBox.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-scroll-bar-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-scroll-bar-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test renderables/ScrollBar.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ScrollBar.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
