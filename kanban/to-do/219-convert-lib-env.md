# Convert lib/env.ts to C#

## Overview

- **Source**: `packages/core/src/lib/env.ts`
- **Phase**: 1
- **Test Coverage**: ✅ `packages/core/src/lib/env.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/lib/singleton.ts` → [task](./210-convert-lib-singleton.md)

## Dependents (blocked until this is done)

- `packages/core/src/renderer.ts`
- `packages/core/src/lib/tree-sitter/client.ts`
- `packages/core/src/lib/data-paths.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/console.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/lib-env-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/lib-env-depth-2.svg)

## Tests

### Class: EnvRegistry

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should register and access string env vars` | `Should_Register_And_Access_String_Env_Vars` |
| `should handle boolean env vars with various true values` | `Should_Handle_Boolean_Env_Vars_With_Various_True_Values` |
| `should handle boolean env vars with various false values` | `Should_Handle_Boolean_Env_Vars_With_Various_False_Values` |
| `should handle number env vars` | `Should_Handle_Number_Env_Vars` |
| `should throw error for invalid number` | `Should_Throw_Error_For_Invalid_Number` |
| `should use default values when env var not set` | `Should_Use_Default_Values_When_Env_Var_Not_Set` |
| `should throw error for required env var not set` | `Should_Throw_Error_For_Required_Env_Var_Not_Set` |
| `should throw error for unregistered env var` | `Should_Throw_Error_For_Unregistered_Env_Var` |
| `should support proxy enumeration` | `Should_Support_Proxy_Enumeration` |
| `should support 'in' operator` | `Should_Support_In_Operator` |
| `should allow re-registering identical configuration` | `Should_Allow_Re-registering_Identical_Configuration` |
| `should throw when re-registering with different type` | `Should_Throw_When_Re-registering_With_Different_Type` |
| `should throw when re-registering with different default` | `Should_Throw_When_Re-registering_With_Different_Default` |
| `should throw when re-registering with different description` | `Should_Throw_When_Re-registering_With_Different_Description` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/lib/env.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "EnvRegistry.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
