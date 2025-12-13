# Convert buffer.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/buffer.ts`
- **Phase**: 16
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/index.ts` _(not convertible)_
- [ ] `packages/core/src/zig.ts` → [task](./239-convert-zig.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/post/filters.ts`
- `packages/core/src/lib/ascii.font.ts`
- `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`
- `packages/core/src/console.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/buffer-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/buffer-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test buffer.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Buffer.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
