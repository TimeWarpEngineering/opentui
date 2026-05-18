# Convert lib/queue.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/queue.ts`
- **Target**: `source/timewarp-tui-core/lib/queue.cs`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/lib/tree-sitter/client.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-queue-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-queue-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/queue.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Queue.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
