# Convert zig.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/zig.ts`
- **Target**: `source/timewarp-tui-core/zig.cs`
- **Phase**: 2
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/env.ts` → [task](./219-convert-lib-env.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/buffer.ts`
- `packages/core/src/text-buffer.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/zig-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/zig-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test zig.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Zig.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
