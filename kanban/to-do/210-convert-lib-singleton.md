# Convert lib/singleton.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/singleton.ts`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/lib/env.ts`
- `packages/core/src/lib/data-paths.ts`
- `packages/core/src/console.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-singleton-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-singleton-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/singleton.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Singleton.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
