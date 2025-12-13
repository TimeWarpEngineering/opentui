# Convert renderables/TextBufferRenderable.ts to C#

## Overview

- **Source**: `packages/core/src/renderables/TextBufferRenderable.ts`
- **Phase**: 3
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/lib/selection.ts` → [task](./251-convert-lib-selection.md)
- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/zig.ts` → [task](./239-convert-zig.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/Code.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-text-buffer-renderable-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-text-buffer-renderable-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test renderables/TextBufferRenderable.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "TextBufferRenderable.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
