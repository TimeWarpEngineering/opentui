# Convert renderables/composition/VRenderable.ts to C#

## Overview

- **Source**: `packages/core/src/renderables/composition/VRenderable.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-composition-vrenderable-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-composition-vrenderable-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test renderables/composition/VRenderable.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "VRenderable.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
