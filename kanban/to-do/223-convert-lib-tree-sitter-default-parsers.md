# Convert lib/tree-sitter/default-parsers.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/tree-sitter/default-parsers.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/tree-sitter/types.ts` → [task](./213-convert-lib-tree-sitter-types.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/tree-sitter/client.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-default-parsers-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-default-parsers-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/tree-sitter/default-parsers.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "DefaultParsers.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
