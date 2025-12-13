# Convert lib/tree-sitter/parser.worker.ts to C#

## Overview

- **Source**: `packages/core/src/lib/tree-sitter/parser.worker.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/tree-sitter/types.ts` → [task](./213-convert-lib-tree-sitter-types.md)
- [ ] `packages/core/src/lib/tree-sitter/download-utils.ts` → [task](./211-convert-lib-tree-sitter-download-utils.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-parser-worker-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-parser-worker-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/tree-sitter/parser.worker.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Parser.worker.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
