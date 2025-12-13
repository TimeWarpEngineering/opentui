# Convert lib/border.ts to C#

## Overview

- **Source**: `packages/core/src/lib/border.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-border-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-border-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/border.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Border.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
