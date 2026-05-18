# Convert console.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/console.ts`
- **Target**: `source/timewarp-tui-core/console.cs`
- **Phase**: 2
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/index.ts` _(not convertible)_
- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/lib/output.capture.ts` → [task](./205-convert-lib-output-capture.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/lib/singleton.ts` → [task](./210-convert-lib-singleton.md)
- [ ] `packages/core/src/lib/env.ts` → [task](./219-convert-lib-env.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/console-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/console-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test console.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Console.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
