# Convert lib/validate-dir-name.ts to C#

## Overview

- **Source**: `packages/core/src/lib/validate-dir-name.ts`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/lib/data-paths.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-validate-dir-name-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-validate-dir-name-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/validate-dir-name.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ValidateDirName.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
