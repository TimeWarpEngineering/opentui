# Convert lib/ascii.font.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/ascii.font.ts`
- **Target**: `source/timewarp-tui-core/lib/ascii-font.cs`
- **Phase**: 1
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/selection.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/Select.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-ascii-font-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-ascii-font-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/ascii.font.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Ascii.font.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
