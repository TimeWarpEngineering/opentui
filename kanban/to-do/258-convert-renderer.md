# Convert renderer.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderer.ts`
- **Target**: `source/timewarp-tui-core/renderer.cs`
- **Phase**: 18
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/ansi.ts` → [task](./203-convert-ansi.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/zig.ts` → [task](./239-convert-zig.md)
- [ ] `packages/core/src/console.ts` → [task](./232-convert-console.md)
- [ ] `packages/core/src/lib/parse.mouse.ts` → [task](./206-convert-lib-parse-mouse.md)
- [ ] `packages/core/src/lib/selection.ts` → [task](./251-convert-lib-selection.md)
- [ ] `packages/core/src/lib/singleton.ts` → [task](./210-convert-lib-singleton.md)
- [ ] `packages/core/src/lib/objects-in-viewport.ts` → [task](./220-convert-lib-objects-in-viewport.md)
- [ ] `packages/core/src/lib/KeyHandler.ts` → [task](./241-convert-lib-key-handler.md)
- [ ] `packages/core/src/lib/env.ts` → [task](./219-convert-lib-env.md)
- [ ] `packages/core/src/lib/tree-sitter/index.ts` _(not convertible)_

## Dependents (blocked until this is done)

- `packages/core/src/animation/Timeline.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/renderables/ScrollBox.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderer-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderer-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test renderer.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Renderer.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
