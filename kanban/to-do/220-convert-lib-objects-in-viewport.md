# Convert lib/objects-in-viewport.ts to C#

## Overview

- **Source**: `packages/core/src/lib/objects-in-viewport.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/renderables/ScrollBox.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-objects-in-viewport-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-objects-in-viewport-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/objects-in-viewport.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ObjectsInViewport.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
