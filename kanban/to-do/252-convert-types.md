# Convert types.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/types.ts`
- **Target**: `source/timewarp-tui-core/types.cs`
- **Phase**: 12
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/lib/selection.ts` → [task](./251-convert-lib-selection.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/lib/KeyHandler.ts` → [task](./241-convert-lib-key-handler.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/buffer.ts`
- `packages/core/src/text-buffer.ts`
- `packages/core/src/renderables/Text.ts`
- `packages/core/src/utils.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/composition/vnode.ts`
- `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/lib/objects-in-viewport.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/types-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/types-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test types.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Types.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
