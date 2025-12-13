# Convert ansi.ts to C#

## Overview

- **Source**: `packages/core/src/ansi.ts`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/lib/KeyHandler.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/ansi-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/ansi-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test ansi.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Ansi.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
