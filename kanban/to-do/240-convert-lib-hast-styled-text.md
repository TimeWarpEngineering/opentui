# Convert lib/hast-styled-text.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/hast-styled-text.ts`
- **Phase**: 3
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/lib/syntax-style.ts` → [task](./235-convert-lib-syntax-style.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-hast-styled-text-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-hast-styled-text-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/hast-styled-text.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "HastStyledText.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
