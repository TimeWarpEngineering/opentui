# Convert testing.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/testing.ts`
- **Target**: `source/timewarp-tui-core/testing.cs`
- **Phase**: 21
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/testing/test-renderer.ts` _(not convertible)_
- [ ] `packages/core/src/testing/mock-keys.ts` _(not convertible)_
- [ ] `packages/core/src/testing/mock-mouse.ts` _(not convertible)_
- [ ] `packages/core/src/testing/spy.ts` _(not convertible)_

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/testing-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/testing-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test testing.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Testing.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
