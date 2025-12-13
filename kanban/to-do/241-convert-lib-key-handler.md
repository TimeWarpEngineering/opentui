# Convert lib/KeyHandler.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/KeyHandler.ts`
- **Phase**: 3
- **Test Coverage**: ✅ `packages/core/src/lib/KeyHandler.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/parse.keypress.ts` → [task](./234-convert-lib-parse-keypress.md)
- [ ] `packages/core/src/ansi.ts` → [task](./203-convert-ansi.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/types.ts`
- `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-key-handler-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-key-handler-depth-2.svg)

## Tests

### Class: KeyHandler

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `constructor uses process.stdin by default` | `Constructor_Uses_Process.stdin_By_Default` |
| `emits keypress events` | `Emits_Keypress_Events` |
| `handles paste mode` | `Handles_Paste_Mode` |
| `handles paste with multiple parts` | `Handles_Paste_With_Multiple_Parts` |
| `strips ANSI codes in paste mode` | `Strips_Ansi_Codes_In_Paste_Mode` |
| `constructor accepts useKittyKeyboard parameter` | `Constructor_Accepts_Usekittykeyboard_Parameter` |
| `destroy method cleans up properly` | `Destroy_Method_Cleans_Up_Properly` |
| `handles Buffer input` | `Handles_Buffer_Input` |
| `event inheritance from EventEmitter` | `Event_Inheritance_From_Eventemitter` |
| `preventDefault stops propagation` | `Preventdefault_Stops_Propagation` |

### Class: InternalKeyHandler

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `onInternal handlers run after regular handlers` | `Oninternal_Handlers_Run_After_Regular_Handlers` |
| `preventDefault prevents internal handlers from running` | `Preventdefault_Prevents_Internal_Handlers_From_Running` |
| `multiple internal handlers can be registered` | `Multiple_Internal_Handlers_Can_Be_Registered` |
| `offInternal removes specific handlers` | `Offinternal_Removes_Specific_Handlers` |
| `emit returns true when there are listeners` | `Emit_Returns_True_When_There_Are_Listeners` |
| `paste events work with priority system` | `Paste_Events_Work_With_Priority_System` |
| `paste preventDefault prevents internal handlers` | `Paste_Preventdefault_Prevents_Internal_Handlers` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/KeyHandler.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "KeyHandler.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
