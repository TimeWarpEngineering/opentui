# Convert lib/tree-sitter/types.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/tree-sitter/types.ts`
- **Target**: `source/timewarp-tui-core/lib/tree-sitter/types.cs`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/lib/tree-sitter/client.ts`
- `packages/core/src/lib/tree-sitter/default-parsers.ts`
- `packages/core/src/lib/tree-sitter/parser.worker.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-types-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-types-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/tree-sitter/types.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Types.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
