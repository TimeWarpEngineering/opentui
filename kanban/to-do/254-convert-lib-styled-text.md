# Convert lib/styled-text.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/styled-text.ts`
- **Phase**: 14
- **Test Coverage**: ❌ No tests

## Dependencies (convert these first)

- [ ] `packages/core/src/renderables/Text.ts` → [task](./253-convert-renderables-text.md)
- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/utils.ts` → [task](./231-convert-utils.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)

## Dependents (blocked until this is done)

- `packages/core/src/text-buffer.ts`
- `packages/core/src/renderables/Text.ts`
- `packages/core/src/lib/hast-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/TextNode.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-styled-text-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-styled-text-depth-2.svg)

## Tests

_No tests to convert_

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test lib/styled-text.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "StyledText.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
