# Convert lib/parse.mouse.ts to C#

## Overview

- **Source**: `packages/core/src/lib/parse.mouse.ts`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-parse-mouse-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-parse-mouse-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/parse.mouse.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Parse.mouse.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
