# Convert Renderable.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/Renderable.ts`
- **Target**: `source/timewarp-tui-core/renderable.cs`
- **Phase**: 17
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/lib/KeyHandler.ts` → [task](./241-convert-lib-key-handler.md)
- [ ] `packages/core/src/lib/parse.mouse.ts` → [task](./206-convert-lib-parse-mouse.md)
- [ ] `packages/core/src/lib/selection.ts` → [task](./251-convert-lib-selection.md)
- [ ] `packages/core/src/lib/yoga.options.ts` → [task](./216-convert-lib-yoga-options.md)
- [ ] `packages/core/src/renderables/composition/vnode.ts` → [task](./226-convert-renderables-composition-vnode.md)
- [ ] `packages/core/src/renderer.ts` → [task](./258-convert-renderer.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/lib/renderable.validations.ts` → [task](./222-convert-lib-renderable-validations.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/renderables/Text.ts`
- `packages/core/src/types.ts`
- `packages/core/src/utils.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/Box.ts`
- `packages/core/src/lib/renderable.validations.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/composition/vnode.ts`
- `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderable-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderable-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test Renderable.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Renderable.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
