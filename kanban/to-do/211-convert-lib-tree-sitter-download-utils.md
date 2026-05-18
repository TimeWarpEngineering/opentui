# Convert lib/tree-sitter/download-utils.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/tree-sitter/download-utils.ts`
- **Target**: `source/timewarp-tui-core/lib/tree-sitter/download-utils.cs`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/lib/tree-sitter/parser.worker.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-download-utils-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-download-utils-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/tree-sitter/download-utils.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "DownloadUtils.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
