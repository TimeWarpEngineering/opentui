# Convert lib/renderable.validations.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/renderable.validations.ts`
- **Phase**: 1
- **Test Coverage**: ✅ `packages/core/src/lib/renderable.validations.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/lib/yoga.options.ts` → [task](./216-convert-lib-yoga-options.md)

## Dependents (blocked until this is done)

- `packages/core/src/Renderable.ts`
- `packages/core/src/renderables/Box.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-renderable-validations-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-renderable-validations-depth-2.svg)

## Tests

### Class: UtilityFunctions

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `validateOptions` | `Validateoptions` |
| `isValidPercentage` | `Isvalidpercentage` |
| `isMarginType` | `Ismargintype` |
| `isPaddingType` | `Ispaddingtype` |
| `isPositionType` | `Ispositiontype` |
| `isDimensionType` | `Isdimensiontype` |
| `isFlexBasisType` | `Isflexbasistype` |
| `isSizeType` | `Issizetype` |
| `isPositionTypeType` | `Ispositiontypetype` |
| `isOverflowType` | `Isoverflowtype` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/renderable.validations.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "UtilityFunctions.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
