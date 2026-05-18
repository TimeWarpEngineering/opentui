# Convert renderables/TextNode.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/TextNode.ts`
- **Target**: `source/timewarp-tui-core/renderables/text-node.cs`
- **Phase**: 1
- **Test Coverage**: ✅ `packages/core/src/renderables/TextNode.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/renderables/index.ts` _(not convertible)_
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/lib/styled-text.ts` → [task](./254-convert-lib-styled-text.md)
- [ ] `packages/core/src/text-buffer.ts` → [task](./255-convert-text-buffer.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/composition/constructs.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-text-node-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-text-node-depth-2.svg)

## Tests

### Class: ConstructorAndOptions

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should create TextNode with default options` | `Should_Create_Textnode_With_Default_Options` |
| `should create TextNode with custom options` | `Should_Create_Textnode_With_Custom_Options` |
| `should parse color strings in constructor` | `Should_Parse_Color_Strings_In_Constructor` |
| `should handle undefined colors` | `Should_Handle_Undefined_Colors` |

### Class: TypeGuard

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should identify TextNodeRenderable instances` | `Should_Identify_Textnoderenderable_Instances` |

### Class: AddMethod

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should add string child using add` | `Should_Add_String_Child_Using_Add` |
| `should add TextNode child using add` | `Should_Add_Textnode_Child_Using_Add` |
| `should add multiple children sequentially` | `Should_Add_Multiple_Children_Sequentially` |
| `should add child at specific index using add method` | `Should_Add_Child_At_Specific_Index_Using_Add_Method` |
| `should add string at specific index using add method` | `Should_Add_String_At_Specific_Index_Using_Add_Method` |
| `should reject non-TextNode children in add method` | `Should_Reject_Non-textnode_Children_In_Add_Method` |
| `should add StyledText child using add method` | `Should_Add_Styledtext_Child_Using_Add_Method` |
| `should add StyledText child at specific index using add method` | `Should_Add_Styledtext_Child_At_Specific_Index_Using_Add_Method` |

### Class: InsertBeforeAndRemoveMethods

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should insert child before anchor node` | `Should_Insert_Child_Before_Anchor_Node` |
| `should throw error when anchor node not found in insertBefore` | `Should_Throw_Error_When_Anchor_Node_Not_Found_In_Insertbefore` |
| `should insert StyledText before anchor node` | `Should_Insert_Styledtext_Before_Anchor_Node` |
| `should remove child from node` | `Should_Remove_Child_From_Node` |
| `should throw error when child not found in remove` | `Should_Throw_Error_When_Child_Not_Found_In_Remove` |

### Class: ClearMethod

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should clear all children and change log` | `Should_Clear_All_Children_And_Change_Log` |

### Class: StyleInheritanceAndMerging

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should merge styles with parent styles` | `Should_Merge_Styles_With_Parent_Styles` |
| `should inherit undefined styles from parent` | `Should_Inherit_Undefined_Styles_From_Parent` |
| `should inherit nothing when parent has no styling` | `Should_Inherit_Nothing_When_Parent_Has_No_Styling` |
| `should combine attributes using bitwise OR` | `Should_Combine_Attributes_Using_Bitwise_Or` |

### Class: GatherWithInheritedStyleMethod

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should gather chunks with inherited styles` | `Should_Gather_Chunks_With_Inherited_Styles` |
| `should recursively gather from child TextNodes` | `Should_Recursively_Gather_From_Child_Textnodes` |
| `should inherit nothing when parent has no default styling` | `Should_Inherit_Nothing_When_Parent_Has_No_Default_Styling` |
| `should allow children to override parent styles independently` | `Should_Allow_Children_To_Override_Parent_Styles_Independently` |
| `should support multi-level inheritance (grandparent -> parent -> child)` | `Should_Support_Multi-level_Inheritance_(grandparent_->_Parent_->_Child)` |
| `should support partial style overrides in children` | `Should_Support_Partial_Style_Overrides_In_Children` |

### Class: StaticFactoryMethods

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should create TextNode from string using fromString` | `Should_Create_Textnode_From_String_Using_Fromstring` |
| `should create TextNode from nodes using fromNodes` | `Should_Create_Textnode_From_Nodes_Using_Fromnodes` |

### Class: UtilityMethods

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should convert to chunks using toChunks` | `Should_Convert_To_Chunks_Using_Tochunks` |
| `should get children using getChildren` | `Should_Get_Children_Using_Getchildren` |
| `should get children count` | `Should_Get_Children_Count` |
| `should find renderable by id` | `Should_Find_Renderable_By_Id` |

### Class: StyledTextIntegration

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should work with template literal styled text` | `Should_Work_With_Template_Literal_Styled_Text` |
| `should preserve styles when converting StyledText to TextNodes` | `Should_Preserve_Styles_When_Converting_Styledtext_To_Textnodes` |
| `should handle empty StyledText` | `Should_Handle_Empty_Styledtext` |
| `should handle StyledText with empty text chunks` | `Should_Handle_Styledtext_With_Empty_Text_Chunks` |

### Class: EdgeCasesAndErrorHandling

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle empty strings` | `Should_Handle_Empty_Strings` |
| `should handle nested empty TextNodes` | `Should_Handle_Nested_Empty_Textnodes` |
| `should handle multiple operations in sequence` | `Should_Handle_Multiple_Operations_In_Sequence` |
| `should efficiently calculate positions for large trees` | `Should_Efficiently_Calculate_Positions_For_Large_Trees` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/renderables/TextNode.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ConstructorAndOptions.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
