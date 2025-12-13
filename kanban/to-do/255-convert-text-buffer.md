# Convert text-buffer.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/text-buffer.ts`
- **Phase**: 15
- **Test Coverage**: ✅ `packages/core/src/text-buffer.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/zig.ts` → [task](./239-convert-zig.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

- `packages/core/src/buffer.ts`
- `packages/core/src/lib/styled-text.ts`
- `packages/core/src/renderables/Text.ts`
- `packages/core/src/lib/hast-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/renderables/TextNode.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/text-buffer-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/text-buffer-depth-2.svg)

## Tests

### Class: LineInfoGetter

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return line info for empty buffer` | `Should_Return_Line_Info_For_Empty_Buffer` |
| `should return single line info for simple text without newlines` | `Should_Return_Single_Line_Info_For_Simple_Text_Without_Newlines` |
| `should handle single newline correctly` | `Should_Handle_Single_Newline_Correctly` |
| `should handle multiple lines separated by newlines` | `Should_Handle_Multiple_Lines_Separated_By_Newlines` |
| `should handle text ending with newline` | `Should_Handle_Text_Ending_With_Newline` |
| `should handle consecutive newlines` | `Should_Handle_Consecutive_Newlines` |
| `should handle text starting with newline` | `Should_Handle_Text_Starting_With_Newline` |
| `should handle only newlines` | `Should_Handle_Only_Newlines` |
| `should cache lineInfo result and return same reference` | `Should_Cache_Lineinfo_Result_And_Return_Same_Reference` |
| `should reset cache when setting new styled text` | `Should_Reset_Cache_When_Setting_New_Styled_Text` |
| `should handle wide characters (Unicode)` | `Should_Handle_Wide_Characters_(unicode)` |
| `should handle empty lines between content` | `Should_Handle_Empty_Lines_Between_Content` |
| `should handle very long lines` | `Should_Handle_Very_Long_Lines` |
| `should handle lines with different widths` | `Should_Handle_Lines_With_Different_Widths` |
| `should handle styled text with colors and attributes` | `Should_Handle_Styled_Text_With_Colors_And_Attributes` |
| `should handle buffer with only whitespace` | `Should_Handle_Buffer_With_Only_Whitespace` |
| `should handle single character lines` | `Should_Handle_Single_Character_Lines` |
| `should handle mixed content with special characters` | `Should_Handle_Mixed_Content_With_Special_Characters` |
| `should handle lineInfo after buffer resize operations` | `Should_Handle_Lineinfo_After_Buffer_Resize_Operations` |

### Class: LineInfoEdgeCases

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle extremely long single line` | `Should_Handle_Extremely_Long_Single_Line` |
| `should handle thousands of lines` | `Should_Handle_Thousands_Of_Lines` |
| `should handle alternating empty and content lines` | `Should_Handle_Alternating_Empty_And_Content_Lines` |
| `should handle lineInfo with complex Unicode combining characters` | `Should_Handle_Lineinfo_With_Complex_Unicode_Combining_Characters` |
| `should handle lineInfo after setting default styles` | `Should_Handle_Lineinfo_After_Setting_Default_Styles` |
| `should handle lineInfo consistency after resetDefaults` | `Should_Handle_Lineinfo_Consistency_After_Resetdefaults` |

### Class: LineInfoGetterWithUnicodeWidthMethod

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return line info for empty buffer` | `Should_Return_Line_Info_For_Empty_Buffer` |
| `should return single line info for simple text without newlines` | `Should_Return_Single_Line_Info_For_Simple_Text_Without_Newlines` |
| `should handle wide characters (Unicode)` | `Should_Handle_Wide_Characters_(unicode)` |
| `should handle lineInfo with complex Unicode combining characters` | `Should_Handle_Lineinfo_With_Complex_Unicode_Combining_Characters` |
| `should handle mixed content with special characters` | `Should_Handle_Mixed_Content_With_Special_Characters` |
| `should handle styled text with colors and attributes` | `Should_Handle_Styled_Text_With_Colors_And_Attributes` |

### Class: GetSelectedText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return empty string when no selection` | `Should_Return_Empty_String_When_No_Selection` |
| `should return selected text for simple selection` | `Should_Return_Selected_Text_For_Simple_Selection` |
| `should return selected text with newlines` | `Should_Return_Selected_Text_With_Newlines` |
| `should handle Unicode characters in selection` | `Should_Handle_Unicode_Characters_In_Selection` |
| `should handle selection at start of text` | `Should_Handle_Selection_At_Start_Of_Text` |
| `should handle single character selection` | `Should_Handle_Single_Character_Selection` |
| `should handle selection that spans styled text` | `Should_Handle_Selection_That_Spans_Styled_Text` |
| `should handle selection reset` | `Should_Handle_Selection_Reset` |

### Class: GetPlainText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return empty string for empty buffer` | `Should_Return_Empty_String_For_Empty_Buffer` |
| `should return plain text without styling` | `Should_Return_Plain_Text_Without_Styling` |
| `should handle text with newlines` | `Should_Handle_Text_With_Newlines` |
| `should handle Unicode characters correctly` | `Should_Handle_Unicode_Characters_Correctly` |
| `should handle styled text with colors and attributes` | `Should_Handle_Styled_Text_With_Colors_And_Attributes` |
| `should handle text with only newlines` | `Should_Handle_Text_With_Only_Newlines` |
| `should handle empty lines between content` | `Should_Handle_Empty_Lines_Between_Content` |
| `should handle very long text` | `Should_Handle_Very_Long_Text` |
| `should handle text with special characters` | `Should_Handle_Text_With_Special_Characters` |
| `should handle buffer with only whitespace` | `Should_Handle_Buffer_With_Only_Whitespace` |

### Class: ChunkGroupMethods

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should properly insert chunk group at specified position` | `Should_Properly_Insert_Chunk_Group_At_Specified_Position` |
| `should insert chunk group at the end when index equals current count` | `Should_Insert_Chunk_Group_At_The_End_When_Index_Equals_Current_Count` |
| `should handle inserting empty text` | `Should_Handle_Inserting_Empty_Text` |
| `should insert chunk group at end when index is far beyond current count` | `Should_Insert_Chunk_Group_At_End_When_Index_Is_Far_Beyond_Current_Count` |
| `should work correctly with getSelectedText` | `Should_Work_Correctly_With_Getselectedtext` |
| `should insert chunk at the beginning of empty buffer` | `Should_Insert_Chunk_At_The_Beginning_Of_Empty_Buffer` |
| `should handle inserting multiple chunks` | `Should_Handle_Inserting_Multiple_Chunks` |
| `should remove chunk from buffer` | `Should_Remove_Chunk_From_Buffer` |
| `should handle removing chunk that doesn` | `Should_Handle_Removing_Chunk_That_Doesn` |
| `should replace chunk content` | `Should_Replace_Chunk_Content` |
| `should handle replacing chunk that doesn` | `Should_Handle_Replacing_Chunk_That_Doesn` |

### Class: InsertChunkGroup

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should insert chunk at the beginning of empty buffer` | `Should_Insert_Chunk_At_The_Beginning_Of_Empty_Buffer` |
| `should handle inserting multiple chunks` | `Should_Handle_Inserting_Multiple_Chunks` |

### Class: RemoveChunkGroup

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should remove chunk from buffer` | `Should_Remove_Chunk_From_Buffer` |
| `should handle removing chunk that doesn` | `Should_Handle_Removing_Chunk_That_Doesn` |

### Class: ReplaceChunkGroup

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should replace chunk content` | `Should_Replace_Chunk_Content` |
| `should handle replacing chunk that doesn` | `Should_Handle_Replacing_Chunk_That_Doesn` |

### Class: LineInfoWithTextWrapping

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return virtual line info when text wrapping is enabled` | `Should_Return_Virtual_Line_Info_When_Text_Wrapping_Is_Enabled` |
| `should return correct lineInfo for word wrapping` | `Should_Return_Correct_Lineinfo_For_Word_Wrapping` |
| `should return correct lineInfo for char wrapping` | `Should_Return_Correct_Lineinfo_For_Char_Wrapping` |
| `should update lineInfo when wrap width changes` | `Should_Update_Lineinfo_When_Wrap_Width_Changes` |
| `should return original lineInfo when wrap is disabled` | `Should_Return_Original_Lineinfo_When_Wrap_Is_Disabled` |

### Class: LengthProperty

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return correct length for simple text` | `Should_Return_Correct_Length_For_Simple_Text` |
| `should return 0 for empty buffer` | `Should_Return_0_For_Empty_Buffer` |
| `should return 0 when only adding empty chunks` | `Should_Return_0_When_Only_Adding_Empty_Chunks` |
| `should handle text with newlines correctly` | `Should_Handle_Text_With_Newlines_Correctly` |
| `should handle Unicode characters correctly` | `Should_Handle_Unicode_Characters_Correctly` |
| `should update length after insertChunkGroup` | `Should_Update_Length_After_Insertchunkgroup` |
| `should handle mixed content with empty chunks` | `Should_Handle_Mixed_Content_With_Empty_Chunks` |
| `should handle only whitespace characters` | `Should_Handle_Only_Whitespace_Characters` |
| `should handle consecutive empty chunks correctly` | `Should_Handle_Consecutive_Empty_Chunks_Correctly` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/text-buffer.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "LineInfoGetter.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
