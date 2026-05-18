# Convert renderables/Input.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/Input.ts`
- **Target**: `source/timewarp-tui-core/renderables/input.cs`
- **Phase**: 4
- **Test Coverage**: ✅ `packages/core/src/renderables/Input.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/buffer.ts` → [task](./256-convert-buffer.md)
- [ ] `packages/core/src/lib/KeyHandler.ts` → [task](./241-convert-lib-key-handler.md)
- [ ] `packages/core/src/lib/RGBA.ts` → [task](./208-convert-lib-rgba.md)
- [ ] `packages/core/src/Renderable.ts` → [task](./257-convert-renderable.md)
- [ ] `packages/core/src/types.ts` → [task](./252-convert-types.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-input-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-input-depth-2.svg)

## Tests

### Class: Initialization

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should initialize properly with default options` | `Should_Initialize_Properly_With_Default_Options` |
| `should initialize with custom options` | `Should_Initialize_With_Custom_Options` |

### Class: FocusManagement

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle focus and blur correctly` | `Should_Handle_Focus_And_Blur_Correctly` |
| `should emit change event on blur if value changed` | `Should_Emit_Change_Event_On_Blur_If_Value_Changed` |
| `should not emit change event on blur if value unchanged` | `Should_Not_Emit_Change_Event_On_Blur_If_Value_Unchanged` |

### Class: SingleInputKeyHandling

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle text input when focused` | `Should_Handle_Text_Input_When_Focused` |
| `should not handle key events when not focused` | `Should_Not_Handle_Key_Events_When_Not_Focused` |
| `should handle backspace correctly` | `Should_Handle_Backspace_Correctly` |
| `should handle delete correctly` | `Should_Handle_Delete_Correctly` |
| `should handle arrow keys for cursor movement` | `Should_Handle_Arrow_Keys_For_Cursor_Movement` |
| `should handle enter key` | `Should_Handle_Enter_Key` |
| `should respect maxLength` | `Should_Respect_Maxlength` |
| `should handle cursor position with text insertion` | `Should_Handle_Cursor_Position_With_Text_Insertion` |
| `should handle onPaste option` | `Should_Handle_Onpaste_Option` |

### Class: MultipleInputFocusManagement

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should allow only one input to be focused at a time` | `Should_Allow_Only_One_Input_To_Be_Focused_At_A_Time` |
| `should only handle key events for focused input` | `Should_Only_Handle_Key_Events_For_Focused_Input` |
| `should handle focus switching with blur events` | `Should_Handle_Focus_Switching_With_Blur_Events` |
| `should handle rapid focus switching` | `Should_Handle_Rapid_Focus_Switching` |
| `should prevent multiple inputs from being focused simultaneously` | `Should_Prevent_Multiple_Inputs_From_Being_Focused_Simultaneously` |

### Class: InputValueManagement

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle value setting programmatically` | `Should_Handle_Value_Setting_Programmatically` |
| `should handle value changes with cursor position preservation` | `Should_Handle_Value_Changes_With_Cursor_Position_Preservation` |
| `should handle empty value setting` | `Should_Handle_Empty_Value_Setting` |
| `should emit input events when value changes programmatically` | `Should_Emit_Input_Events_When_Value_Changes_Programmatically` |

### Class: InputProperties

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle maxLength changes` | `Should_Handle_Maxlength_Changes` |
| `should handle placeholder changes` | `Should_Handle_Placeholder_Changes` |
| `should handle color property changes` | `Should_Handle_Color_Property_Changes` |

### Class: GlobalKeyEventPrevention

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should not handle key events when preventDefault is called by global handler` | `Should_Not_Handle_Key_Events_When_Preventdefault_Is_Called_By_Global_Handler` |
| `should handle multiple global handlers with preventDefault` | `Should_Handle_Multiple_Global_Handlers_With_Preventdefault` |
| `should respect preventDefault from global handler registered AFTER input focus` | `Should_Respect_Preventdefault_From_Global_Handler_Registered_After_Input_Focus` |
| `should handle dynamic preventDefault conditions` | `Should_Handle_Dynamic_Preventdefault_Conditions` |

### Class: EdgeCases

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle non-printable characters` | `Should_Handle_Non-printable_Characters` |
| `should handle cursor movement at boundaries` | `Should_Handle_Cursor_Movement_At_Boundaries` |
| `should handle backspace at start of input` | `Should_Handle_Backspace_At_Start_Of_Input` |
| `should handle delete at end of input` | `Should_Handle_Delete_At_End_Of_Input` |
| `should handle empty input operations` | `Should_Handle_Empty_Input_Operations` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/renderables/Input.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Initialization.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
