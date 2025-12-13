# Convert renderables/Text.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/Text.ts`
- **Phase**: 13
- **Test Coverage**: ✅ `packages/core/src/renderables/Text.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)
- [ ] `packages/core/src/renderables/TextNode.ts` → [task](./230-convert-renderables-text-node.md)
- [ ] `packages/core/src/renderables/TextBufferRenderable.ts` → [task](./243-convert-renderables-text-buffer-renderable.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/styled-text.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-text-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-text-depth-2.svg)

## Tests

### Class: NativeGetSelectedText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should use native implementation` | `Should_Use_Native_Implementation` |
| `should handle graphemes correctly` | `Should_Handle_Graphemes_Correctly` |

### Class: Initialization

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should initialize properly` | `Should_Initialize_Properly` |

### Class: BasicSelectionFlow

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle selection from start to end` | `Should_Handle_Selection_From_Start_To_End` |
| `should handle selection with newline characters` | `Should_Handle_Selection_With_Newline_Characters` |
| `should handle selection spanning multiple lines completely` | `Should_Handle_Selection_Spanning_Multiple_Lines_Completely` |
| `should handle selection including multiple line breaks` | `Should_Handle_Selection_Including_Multiple_Line_Breaks` |
| `should handle selection that includes line breaks at boundaries` | `Should_Handle_Selection_That_Includes_Line_Breaks_At_Boundaries` |
| `should handle reverse selection (end before start)` | `Should_Handle_Reverse_Selection_(end_Before_Start)` |

### Class: SelectionEdgeCases

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle empty text` | `Should_Handle_Empty_Text` |
| `should handle single character selection` | `Should_Handle_Single_Character_Selection` |
| `should handle zero-width selection` | `Should_Handle_Zero-width_Selection` |
| `should handle selection beyond text bounds` | `Should_Handle_Selection_Beyond_Text_Bounds` |

### Class: SelectionWithStyledText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle styled text selection` | `Should_Handle_Styled_Text_Selection` |
| `should handle selection with different text colors` | `Should_Handle_Selection_With_Different_Text_Colors` |

### Class: SelectionStateManagement

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should clear selection when selection is cleared` | `Should_Clear_Selection_When_Selection_Is_Cleared` |
| `should handle multiple selection changes` | `Should_Handle_Multiple_Selection_Changes` |

### Class: ShouldStartSelection

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should return false for non-selectable text` | `Should_Return_False_For_Non-selectable_Text` |
| `should return true for selectable text within bounds` | `Should_Return_True_For_Selectable_Text_Within_Bounds` |
| `should handle shouldStartSelection with multi-line text` | `Should_Handle_Shouldstartselection_With_Multi-line_Text` |

### Class: SelectionWithCustomDimensions

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle selection in constrained width` | `Should_Handle_Selection_In_Constrained_Width` |

### Class: CrossRenderableSelectionInNestedBoxes

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle selection across multiple nested text renderables in boxes` | `Should_Handle_Selection_Across_Multiple_Nested_Text_Renderables_In_Boxes` |
| `should automatically update selection when text content changes within covered area` | `Should_Automatically_Update_Selection_When_Text_Content_Changes_Within_Covered_Area` |
| `should automatically update selection when text node content changes with clear and add` | `Should_Automatically_Update_Selection_When_Text_Node_Content_Changes_With_Clear_And_Add` |
| `should handle selection that starts above box and ends below/right of box` | `Should_Handle_Selection_That_Starts_Above_Box_And_Ends_Below/right_Of_Box` |

### Class: TextNodeIntegrationWithGetPlainText

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should render correct plain text after adding TextNodes` | `Should_Render_Correct_Plain_Text_After_Adding_Textnodes` |
| `should render correct plain text after inserting TextNodes` | `Should_Render_Correct_Plain_Text_After_Inserting_Textnodes` |
| `should render correct plain text after removing TextNodes` | `Should_Render_Correct_Plain_Text_After_Removing_Textnodes` |
| `should handle simple add and remove operations` | `Should_Handle_Simple_Add_And_Remove_Operations` |
| `should render correct plain text after clearing all TextNodes` | `Should_Render_Correct_Plain_Text_After_Clearing_All_Textnodes` |
| `should handle nested TextNode structures correctly` | `Should_Handle_Nested_Textnode_Structures_Correctly` |
| `should handle mixed string and TextNode content` | `Should_Handle_Mixed_String_And_Textnode_Content` |
| `should handle TextNode operations with inherited styles` | `Should_Handle_Textnode_Operations_With_Inherited_Styles` |
| `should handle empty TextNodes correctly` | `Should_Handle_Empty_Textnodes_Correctly` |
| `should handle complex TextNode operations sequence` | `Should_Handle_Complex_Textnode_Operations_Sequence` |
| `should inherit fg/bg colors from TextRenderable to TextNode children` | `Should_Inherit_Fg/bg_Colors_From_Textrenderable_To_Textnode_Children` |
| `should allow TextNode children to override parent TextRenderable colors` | `Should_Allow_Textnode_Children_To_Override_Parent_Textrenderable_Colors` |
| `should inherit TextRenderable colors through nested TextNode hierarchies` | `Should_Inherit_Textrenderable_Colors_Through_Nested_Textnode_Hierarchies` |
| `should handle TextRenderable color changes affecting existing TextNode children` | `Should_Handle_Textrenderable_Color_Changes_Affecting_Existing_Textnode_Children` |
| `should handle TextNode commands with multiple operations per render` | `Should_Handle_Textnode_Commands_With_Multiple_Operations_Per_Render` |

### Class: StyledTextIntegration

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should render StyledText content correctly` | `Should_Render_Styledtext_Content_Correctly` |
| `should handle selection with StyledText content` | `Should_Handle_Selection_With_Styledtext_Content` |
| `should handle empty StyledText` | `Should_Handle_Empty_Styledtext` |
| `should handle StyledText with multiple chunks` | `Should_Handle_Styledtext_With_Multiple_Chunks` |
| `should handle StyledText with TextNodeRenderable children` | `Should_Handle_Styledtext_With_Textnoderenderable_Children` |

### Class: TextContentSnapshots

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should render basic text content correctly` | `Should_Render_Basic_Text_Content_Correctly` |
| `should render multiline text content correctly` | `Should_Render_Multiline_Text_Content_Correctly` |
| `should render text with graphemes/emojis correctly` | `Should_Render_Text_With_Graphemes/emojis_Correctly` |
| `should render TextNode text composition correctly` | `Should_Render_Textnode_Text_Composition_Correctly` |
| `should render text positioning correctly` | `Should_Render_Text_Positioning_Correctly` |
| `should render empty buffer correctly` | `Should_Render_Empty_Buffer_Correctly` |
| `should render text with character wrapping correctly` | `Should_Render_Text_With_Character_Wrapping_Correctly` |
| `should render wrapped text with different content` | `Should_Render_Wrapped_Text_With_Different_Content` |
| `should render wrapped text with emojis and graphemes` | `Should_Render_Wrapped_Text_With_Emojis_And_Graphemes` |
| `should render wrapped multiline text correctly` | `Should_Render_Wrapped_Multiline_Text_Correctly` |

### Class: TextNodeDimensionUpdates

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should update dimensions and reposition subsequent elements when text nodes expand` | `Should_Update_Dimensions_And_Reposition_Subsequent_Elements_When_Text_Nodes_Expand` |
| `should handle multiple text node updates with complex layout changes` | `Should_Handle_Multiple_Text_Node_Updates_With_Complex_Layout_Changes` |

### Class: WordWrapping

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should default to word wrap mode` | `Should_Default_To_Word_Wrap_Mode` |
| `should wrap at word boundaries when using word mode` | `Should_Wrap_At_Word_Boundaries_When_Using_Word_Mode` |
| `should wrap at character boundaries when using char mode` | `Should_Wrap_At_Character_Boundaries_When_Using_Char_Mode` |
| `should handle word wrapping with punctuation` | `Should_Handle_Word_Wrapping_With_Punctuation` |
| `should handle word wrapping with hyphens and dashes` | `Should_Handle_Word_Wrapping_With_Hyphens_And_Dashes` |
| `should dynamically change wrap mode` | `Should_Dynamically_Change_Wrap_Mode` |
| `should handle long words that exceed wrap width in word mode` | `Should_Handle_Long_Words_That_Exceed_Wrap_Width_In_Word_Mode` |
| `should preserve empty lines with word wrapping` | `Should_Preserve_Empty_Lines_With_Word_Wrapping` |
| `should handle word wrapping with single character words` | `Should_Handle_Word_Wrapping_With_Single_Character_Words` |
| `should compare char vs word wrapping with same content` | `Should_Compare_Char_Vs_Word_Wrapping_With_Same_Content` |
| `should correctly wrap text when updating content via text.content` | `Should_Correctly_Wrap_Text_When_Updating_Content_Via_Text.content` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/renderables/Text.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "NativeGetSelectedText.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
