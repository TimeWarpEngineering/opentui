# Convert lib/parse.keypress-kitty.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/parse.keypress-kitty.ts`
- **Phase**: 1
- **Test Coverage**: ✅ `packages/core/src/lib/parse.keypress-kitty.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/parse.keypress.ts` → [task](./234-convert-lib-parse-keypress.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/parse.keypress.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-parse-keypress-kitty-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-parse-keypress-kitty-depth-2.svg)

## Tests

### Class: ParseKeypress

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `Kitty keyboard protocol disabled by default` | `Kitty_Keyboard_Protocol_Disabled_By_Default` |
| `Kitty keyboard basic key` | `Kitty_Keyboard_Basic_Key` |
| `Kitty keyboard shift+a` | `Kitty_Keyboard_Shift+a` |
| `Kitty keyboard ctrl+a` | `Kitty_Keyboard_Ctrl+a` |
| `Kitty keyboard alt+a` | `Kitty_Keyboard_Alt+a` |
| `Kitty keyboard function key` | `Kitty_Keyboard_Function_Key` |
| `Kitty keyboard arrow key` | `Kitty_Keyboard_Arrow_Key` |
| `Kitty keyboard shift+space` | `Kitty_Keyboard_Shift+space` |
| `Kitty keyboard event types` | `Kitty_Keyboard_Event_Types` |
| `Kitty keyboard with text` | `Kitty_Keyboard_With_Text` |
| `Kitty keyboard ctrl+shift+a` | `Kitty_Keyboard_Ctrl+shift+a` |
| `Kitty keyboard alt+shift+a` | `Kitty_Keyboard_Alt+shift+a` |
| `Kitty keyboard super+a` | `Kitty_Keyboard_Super+a` |
| `Kitty keyboard hyper+a` | `Kitty_Keyboard_Hyper+a` |
| `Kitty keyboard with shifted codepoint` | `Kitty_Keyboard_With_Shifted_Codepoint` |
| `Kitty keyboard with base layout codepoint` | `Kitty_Keyboard_With_Base_Layout_Codepoint` |
| `Kitty keyboard different layout (QWERTY A key on AZERTY)` | `Kitty_Keyboard_Different_Layout_(qwerty_A_Key_On_Azerty)` |
| `Kitty keyboard caps lock` | `Kitty_Keyboard_Caps_Lock` |
| `Kitty keyboard num lock` | `Kitty_Keyboard_Num_Lock` |
| `Kitty keyboard unicode character` | `Kitty_Keyboard_Unicode_Character` |
| `Kitty keyboard emoji` | `Kitty_Keyboard_Emoji` |
| `Kitty keyboard invalid codepoint` | `Kitty_Keyboard_Invalid_Codepoint` |
| `Kitty keyboard keypad keys` | `Kitty_Keyboard_Keypad_Keys` |
| `Kitty keyboard media keys` | `Kitty_Keyboard_Media_Keys` |
| `Kitty keyboard modifier keys` | `Kitty_Keyboard_Modifier_Keys` |
| `Kitty keyboard function keys with event types` | `Kitty_Keyboard_Function_Keys_With_Event_Types` |
| `Kitty keyboard arrow keys with event types` | `Kitty_Keyboard_Arrow_Keys_With_Event_Types` |
| `Kitty keyboard invalid event types` | `Kitty_Keyboard_Invalid_Event_Types` |
| `Kitty progressive enhancement fallback` | `Kitty_Progressive_Enhancement_Fallback` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/parse.keypress-kitty.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ParseKeypress.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
