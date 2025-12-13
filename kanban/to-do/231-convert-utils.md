# Convert utils.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/utils.ts`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/styled-text.ts`
- `packages/core/src/lib/syntax-style.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/utils-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/utils-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test utils.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Utils.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
