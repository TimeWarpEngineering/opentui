# Convert post/filters.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/post/filters.ts`
- **Target**: `source/timewarp-tui-core/post/filters.cs`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/post-filters-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/post-filters-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test post/filters.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Filters.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
