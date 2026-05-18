# Convert lib/data-paths.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/data-paths.ts`
- **Target**: `source/timewarp-tui-core/lib/data-paths.cs`
- **Phase**: 2
- **Test Coverage**: ✅ `packages/core/src/lib/data-paths.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/singleton.ts` → [task](./210-convert-lib-singleton.md)
- [ ] `packages/core/src/lib/env.ts` → [task](./219-convert-lib-env.md)
- [ ] `packages/core/src/lib/validate-dir-name.ts` → [task](./214-convert-lib-validate-dir-name.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-data-paths-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-data-paths-depth-2.svg)

## Tests

### Class: Tests

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `DataPathsManager validates appName` | `Datapathsmanager_Validates_Appname` |
| `DataPathsManager constructor uses valid default appName` | `Datapathsmanager_Constructor_Uses_Valid_Default_Appname` |
| `DataPathsManager emits paths:changed event when appName changes` | `Datapathsmanager_Emits_Paths:changed_Event_When_Appname_Changes` |
| `DataPathsManager does not emit event when appName is set to same value` | `Datapathsmanager_Does_Not_Emit_Event_When_Appname_Is_Set_To_Same_Value` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/data-paths.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Tests.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
