# Convert lib/word-jumps.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/lib/word-jumps.ts`
- **Phase**: 0
- **Test Coverage**: ✅ `packages/core/src/lib/word-jumps.test.ts`

## Dependencies (convert these first)

_None - this file has no dependencies_

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-word-jumps-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-word-jumps-depth-2.svg)

## Tests

### Class: WordJumping

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `jumps to end of current word` | `Jumps_To_End_Of_Current_Word` |
| `skips spaces to next word end` | `Skips_Spaces_To_Next_Word_End` |
| `handles punctuation` | `Handles_Punctuation` |
| `handles multiple punctuation` | `Handles_Multiple_Punctuation` |
| `crosses newlines` | `Crosses_Newlines` |
| `handles multiple newlines` | `Handles_Multiple_Newlines` |
| `handles camelCase words` | `Handles_Camelcase_Words` |
| `handles snake_case words` | `Handles_Snake_case_Words` |
| `handles end of text` | `Handles_End_Of_Text` |
| `handles complex text with newlines and punctuation` | `Handles_Complex_Text_With_Newlines_And_Punctuation` |
| `jumps to start of current word` | `Jumps_To_Start_Of_Current_Word` |
| `skips spaces to previous word start` | `Skips_Spaces_To_Previous_Word_Start` |
| `handles punctuation` | `Handles_Punctuation` |
| `handles multiple punctuation` | `Handles_Multiple_Punctuation` |
| `crosses newlines` | `Crosses_Newlines` |
| `handles multiple newlines` | `Handles_Multiple_Newlines` |
| `handles camelCase words` | `Handles_Camelcase_Words` |
| `handles snake_case words` | `Handles_Snake_case_Words` |
| `handles beginning of text` | `Handles_Beginning_Of_Text` |
| `handles complex text with newlines and punctuation` | `Handles_Complex_Text_With_Newlines_And_Punctuation` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/word-jumps.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "WordJumping.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
