# Convert lib/selection.ts to C#

## Overview

- **Source**: `packages/core/src/lib/selection.ts`
- **Phase**: 11
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/index.ts` _(not convertible)_
- [ ] `packages/core/src/lib/ascii.font.ts` → [task](./217-convert-lib-ascii-font.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/types.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-selection-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-selection-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/selection.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Selection.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
