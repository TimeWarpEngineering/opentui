# Convert lib/tree-sitter/client.ts to C#

## Overview

- **Source**: `packages/core/src/lib/tree-sitter/client.ts`
- **Phase**: 2
- **Test Coverage**: ✅ `packages/core/src/lib/tree-sitter/client.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/debounce.ts` → [task](./204-convert-lib-debounce.md)
- [ ] `packages/core/src/lib/queue.ts` → [task](./207-convert-lib-queue.md)
- [ ] `packages/core/src/lib/tree-sitter/types.ts` → [task](./213-convert-lib-tree-sitter-types.md)
- [ ] `packages/core/src/lib/tree-sitter/default-parsers.ts` → [task](./223-convert-lib-tree-sitter-default-parsers.md)
- [ ] `packages/core/src/lib/env.ts` → [task](./219-convert-lib-env.md)

## Dependents (blocked until this is done)

- `packages/core/src/lib/tree-sitter-styled-text.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-tree-sitter-client-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-tree-sitter-client-depth-2.svg)

## Tests

### Class: TreeSitterClient

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should initialize successfully` | `Should_Initialize_Successfully` |
| `should preload parsers for supported filetypes` | `Should_Preload_Parsers_For_Supported_Filetypes` |
| `should return false for unsupported filetypes` | `Should_Return_False_For_Unsupported_Filetypes` |
| `should create buffer with supported filetype` | `Should_Create_Buffer_With_Supported_Filetype` |
| `should create buffer without parser for unsupported filetype` | `Should_Create_Buffer_Without_Parser_For_Unsupported_Filetype` |
| `should emit highlights:response event when buffer is updated` | `Should_Emit_Highlights:response_Event_When_Buffer_Is_Updated` |
| `should handle buffer removal` | `Should_Handle_Buffer_Removal` |
| `should handle multiple buffers` | `Should_Handle_Multiple_Buffers` |
| `should handle buffer reset` | `Should_Handle_Buffer_Reset` |
| `should emit error events for invalid operations` | `Should_Emit_Error_Events_For_Invalid_Operations` |
| `should prevent duplicate buffer creation` | `Should_Prevent_Duplicate_Buffer_Creation` |
| `should handle performance metrics` | `Should_Handle_Performance_Metrics` |
| `should handle concurrent buffer operations` | `Should_Handle_Concurrent_Buffer_Operations` |
| `should clean up resources on destroy` | `Should_Clean_Up_Resources_On_Destroy` |
| `should perform one-shot highlighting` | `Should_Perform_One-shot_Highlighting` |
| `should handle one-shot highlighting for unsupported filetype` | `Should_Handle_One-shot_Highlighting_For_Unsupported_Filetype` |
| `should perform multiple one-shot highlights independently` | `Should_Perform_Multiple_One-shot_Highlights_Independently` |
| `should support local file paths for parser configuration` | `Should_Support_Local_File_Paths_For_Parser_Configuration` |
| `should handle concurrent highlightOnce calls efficiently (no duplicate parser loading)` | `Should_Handle_Concurrent_Highlightonce_Calls_Efficiently_(no_Duplicate_Parser_Loading)` |
| `should handle initialization timeout` | `Should_Handle_Initialization_Timeout` |
| `should handle operations before initialization` | `Should_Handle_Operations_Before_Initialization` |
| `should handle worker errors gracefully` | `Should_Handle_Worker_Errors_Gracefully` |
| `should handle data path changes with reactive getTreeSitterClient` | `Should_Handle_Data_Path_Changes_With_Reactive_Gettreesitterclient` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/tree-sitter/client.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "TreeSitterClient.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
