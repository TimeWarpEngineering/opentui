# Convert lib/parse.keypress.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/parse.keypress.ts`
- **Phase**: 2
- **Test Coverage**: ✅ `packages/core/src/lib/parse.keypress.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/parse.keypress-kitty.ts` → [task](./221-convert-lib-parse-keypress-kitty.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/KeyHandler.ts`
- `packages/core/src/lib/parse.keypress-kitty.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-parse-keypress-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-parse-keypress-depth-2.svg)

## Tests

### Class: ParseKeypress

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `basic letters` | `Basic_Letters` |
| `numbers` | `Numbers` |
| `special keys` | `Special_Keys` |
| `ctrl+letter combinations` | `Ctrl+letter_Combinations` |
| `meta+character combinations` | `Meta+character_Combinations` |
| `function keys` | `Function_Keys` |
| `arrow keys` | `Arrow_Keys` |
| `navigation keys` | `Navigation_Keys` |
| `modifier combinations` | `Modifier_Combinations` |
| `delete key` | `Delete_Key` |
| `Buffer input` | `Buffer_Input` |
| `high byte buffer handling` | `High_Byte_Buffer_Handling` |
| `empty input` | `Empty_Input` |
| `special characters` | `Special_Characters` |
| `meta space and escape combinations` | `Meta_Space_And_Escape_Combinations` |
| `rxvt style arrow keys with modifiers` | `Rxvt_Style_Arrow_Keys_With_Modifiers` |
| `ctrl modifier keys` | `Ctrl_Modifier_Keys` |
| `modifier bit calculations and meta/alt relationship` | `Modifier_Bit_Calculations_And_Meta/alt_Relationship` |
| `modifier combinations with function keys` | `Modifier_Combinations_With_Function_Keys` |
| `regular parsing always defaults to press event type` | `Regular_Parsing_Always_Defaults_To_Press_Event_Type` |
| `ctrl+option+letter combinations` | `Ctrl+option+letter_Combinations` |

### Class: Tests

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `nonAlphanumericKeys export` | `Nonalphanumerickeys_Export` |
| `ParsedKey type structure` | `Parsedkey_Type_Structure` |
| `KeyEventType type validation` | `Keyeventtype_Type_Validation` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/parse.keypress.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "ParseKeypress.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
