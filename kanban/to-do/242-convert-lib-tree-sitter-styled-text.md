# Convert lib/tree-sitter-styled-text.ts to C#

## Overview

- **Source**: `packages/core/src/lib/tree-sitter-styled-text.ts`
- **Phase**: 3
- **Test Coverage**: ✅ `packages/core/src/lib/tree-sitter-styled-text.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/lib/syntax-style.ts` → [task](./235-convert-lib-syntax-style.md)
- [ ] `packages/core/src/lib/tree-sitter/client.ts` → [task](./236-convert-lib-tree-sitter-client.md)
- [ ] `packages/core/src/lib/tree-sitter/types.ts` → [task](./213-convert-lib-tree-sitter-types.md)
- [ ] `packages/core/src/utils.ts` → [task](./231-convert-utils.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-styled-text-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-styled-text-depth-2.svg)

## Tests

### Class: TreeSitterStyledText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should convert JavaScript code to styled text` | `Should_Convert_Javascript_Code_To_Styled_Text` |
| `should convert TypeScript code to styled text` | `Should_Convert_Typescript_Code_To_Styled_Text` |
| `should handle unsupported filetype gracefully` | `Should_Handle_Unsupported_Filetype_Gracefully` |
| `should handle empty content` | `Should_Handle_Empty_Content` |
| `should handle multiline content correctly` | `Should_Handle_Multiline_Content_Correctly` |
| `should preserve original text content` | `Should_Preserve_Original_Text_Content` |
| `should apply different styles to different syntax elements` | `Should_Apply_Different_Styles_To_Different_Syntax_Elements` |
| `should handle template literals correctly without duplication` | `Should_Handle_Template_Literals_Correctly_Without_Duplication` |
| `should handle complex template literals with multiple expressions` | `Should_Handle_Complex_Template_Literals_With_Multiple_Expressions` |
| `should correctly highlight template literal with embedded expressions` | `Should_Correctly_Highlight_Template_Literal_With_Embedded_Expressions` |
| `should work with real tree-sitter output containing dot-delimited groups` | `Should_Work_With_Real_Tree-sitter_Output_Containing_Dot-delimited_Groups` |
| `should resolve styles correctly for dot-delimited groups and multiple overlapping groups` | `Should_Resolve_Styles_Correctly_For_Dot-delimited_Groups_And_Multiple_Overlapping_Groups` |
| `should handle constructor group correctly` | `Should_Handle_Constructor_Group_Correctly` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/tree-sitter-styled-text.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "TreeSitterStyledText.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
