# Convert lib/syntax-style.ts to C#

## Overview

- **Source**: `packages/core/src/lib/syntax-style.ts`
- **Phase**: 2
- **Test Coverage**: ✅ `packages/core/src/lib/syntax-style.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/utils.ts` → [task](./231-convert-utils.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/hast-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/renderables/Code.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-syntax-style-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-syntax-style-depth-2.svg)

## Tests

### Class: SyntaxStyle

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should merge single style correctly` | `Should_Merge_Single_Style_Correctly` |
| `should merge multiple styles with later styles taking precedence` | `Should_Merge_Multiple_Styles_With_Later_Styles_Taking_Precedence` |
| `should handle dot-delimited style names with fallback to base name` | `Should_Handle_Dot-delimited_Style_Names_With_Fallback_To_Base_Name` |
| `should return no styling for non-existent base names` | `Should_Return_No_Styling_For_Non-existent_Base_Names` |
| `should prefer exact matches over fallback matches` | `Should_Prefer_Exact_Matches_Over_Fallback_Matches` |
| `should handle multiple dot-delimited names in single merge` | `Should_Handle_Multiple_Dot-delimited_Names_In_Single_Merge` |
| `should cache merged styles for performance` | `Should_Cache_Merged_Styles_For_Performance` |
| `should clear cache correctly` | `Should_Clear_Cache_Correctly` |
| `should handle all style attributes correctly` | `Should_Handle_All_Style_Attributes_Correctly` |
| `should handle empty style names gracefully` | `Should_Handle_Empty_Style_Names_Gracefully` |
| `should handle dot-delimited names with multiple dots` | `Should_Handle_Dot-delimited_Names_With_Multiple_Dots` |
| `should handle style named 'constructor' correctly` | `Should_Handle_Style_Named_Constructor_Correctly` |
| `should not return prototype properties when style is not defined` | `Should_Not_Return_Prototype_Properties_When_Style_Is_Not_Defined` |
| `should convert theme definition to flat styles` | `Should_Convert_Theme_Definition_To_Flat_Styles` |
| `should handle background colors in theme conversion` | `Should_Handle_Background_Colors_In_Theme_Conversion` |
| `should create SyntaxStyle from theme using fromTheme` | `Should_Create_Syntaxstyle_From_Theme_Using_Fromtheme` |
| `should work with the provided theme example` | `Should_Work_With_The_Provided_Theme_Example` |
| `should handle fallback for dot-delimited scopes in theme` | `Should_Handle_Fallback_For_Dot-delimited_Scopes_In_Theme` |
| `should handle different color input formats` | `Should_Handle_Different_Color_Input_Formats` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/syntax-style.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "SyntaxStyle.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
