# Convert lib/RGBA.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/RGBA.ts`
- **Target**: `source/timewarp-tui-core/lib/rgba.cs`
- **Phase**: 0
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/text-buffer.ts`
- `packages/core/src/lib/styled-text.ts`
- `packages/core/src/renderables/Text.ts`
- `packages/core/src/types.ts`
- `packages/core/src/lib/border.ts`
- `packages/core/src/lib/ascii.font.ts`
- `packages/core/src/lib/syntax-style.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`
- `packages/core/src/console.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-rgba-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-rgba-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/RGBA.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "RGBA.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
