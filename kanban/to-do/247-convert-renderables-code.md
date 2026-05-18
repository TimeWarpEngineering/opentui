# Convert renderables/Code.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/Code.ts`
- **Target**: `source/timewarp-tui-core/renderables/code.cs`
- **Phase**: 5
- **Test Coverage**: ✅ `packages/core/src/renderables/Code.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/lib/syntax-style.ts` → [task](./235-convert-lib-syntax-style.md)
- [ ] `packages/core/src/lib/tree-sitter/index.ts` _(not convertible)_
- [ ] `packages/core/src/renderables/TextBufferRenderable.ts` → [task](./243-convert-renderables-text-buffer-renderable.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-code-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-code-depth-2.svg)

## Tests

### Class: CodeRenderable

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `basic construction` | `Basic_Construction` |
| `content updates` | `Content_Updates` |
| `filetype updates` | `Filetype_Updates` |
| `re-highlighting when content changes during active highlighting` | `Re-highlighting_When_Content_Changes_During_Active_Highlighting` |
| `multiple content changes during highlighting` | `Multiple_Content_Changes_During_Highlighting` |
| `fallback when no filetype provided` | `Fallback_When_No_Filetype_Provided` |
| `fallback when highlighting throws error` | `Fallback_When_Highlighting_Throws_Error` |
| `early return when content is empty` | `Early_Return_When_Content_Is_Empty` |
| `empty content does not trigger highlighting` | `Empty_Content_Does_Not_Trigger_Highlighting` |
| `text renders immediately before highlighting completes` | `Text_Renders_Immediately_Before_Highlighting_Completes` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/renderables/Code.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "CodeRenderable.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
