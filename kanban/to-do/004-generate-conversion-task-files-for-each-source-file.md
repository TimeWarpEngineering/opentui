# Generate Conversion Task Files for Each Source File

## Summary

Auto-generate individual kanban task files for each convertible TypeScript file, plus a master checklist to track overall C# conversion progress. Each task will include test mappings with TypeScript test names and their C# equivalents.

## Todo List

- [ ] Parse test files to extract test structure:
  - [ ] Handle nested `describe`/`it` pattern (e.g., Input.test.ts)
  - [ ] Handle flat `test` pattern with prefix (e.g., KeyHandler.test.ts)
  - [ ] Handle `describe` with `test` blocks (e.g., env.test.ts)
- [ ] Convert test names to C# naming convention (Pascal_Snake_Case)
- [ ] Create conversion task template with test mappings
- [ ] For each convertible file (in topological/phase order):
  - [ ] Generate `kanban/to-do/convert-{kebab-name}.md` with:
    - [ ] Source file path
    - [ ] Phase number (dependency depth)
    - [ ] Test coverage status and test file path
    - [ ] Dependencies list with links to their task files
    - [ ] Dependents list (what's blocked by this file)
    - [ ] Links to depth-1 and depth-2 SVG files
    - [ ] Test name mapping table (TypeScript → C#)
    - [ ] Test execution commands
- [ ] Generate `kanban/to-do/005-conversion-checklist.md` master checklist:
  - [ ] Group files by phase (Phase 0, Phase 1, etc.)
  - [ ] Each file links to its conversion task
  - [ ] Checkbox format for tracking progress
- [ ] Update `scripts/analyze-deps.ts` to run task generation
- [ ] Add `--generate-tasks` flag to control task generation (optional)

## Notes

**Priority:** Medium (depends on per-file graph generation)

**Labels/Tags:** tooling, c#-conversion, automation

**Depends on:** Task 003 (per-file graphs) - COMPLETED

### C# File Naming Convention

TypeScript test files map to C# with kebab-case:

- `KeyHandler.test.ts` → `keyhandler-tests.cs`
- `Input.test.ts` → `input-tests.cs`
- `parse.keypress.test.ts` → `parse-keypress-tests.cs`

### Test Structure Patterns Found

**Pattern 1: Nested `describe`/`it`** (ideal case - e.g., Input.test.ts):

```typescript
describe("InputRenderable", () => {
  describe("Initialization", () => {
    it("should initialize properly with default options", () => { ... })
  })
})
```

Maps to:

```
Namespace: InputRenderable
Class: Initialization
Method: Should_Initialize_Properly_With_Default_Options
```

**Pattern 2: Flat `test` with prefix** (e.g., KeyHandler.test.ts):

```typescript
test("KeyHandler - emits keypress events", () => { ... })
test("InternalKeyHandler - onInternal handlers run after regular handlers", () => { ... })
```

Maps to (grouped by prefix):

```
Class: KeyHandler
Method: Emits_Keypress_Events

Class: InternalKeyHandler
Method: OnInternal_Handlers_Run_After_Regular_Handlers
```

**Pattern 3: `describe` with `test` blocks** (e.g., env.test.ts):

```typescript
describe("env registry", () => {
  test("should register and access string env vars", () => { ... })
})
```

Maps to:

```
Class: Env_Registry
Method: Should_Register_And_Access_String_Env_Vars
```

### C# Test Naming Convention

- Mirror the TypeScript test name exactly
- Convert to Pascal_Snake_Case (capitalize first letter of each word, use underscores)
- Strip redundant class name prefixes when present (e.g., `"KeyHandler - "`)

Examples:

- `"should initialize properly with default options"` → `Should_Initialize_Properly_With_Default_Options`
- `"handles modifier keys correctly"` → `Handles_Modifier_Keys_Correctly`
- `"KeyHandler - emits keypress events"` → `Emits_Keypress_Events` (prefix stripped)
- `"Verify mouse scroll event reception"` → `Verify_Mouse_Scroll_Event_Reception`

### Task Template (Updated)

Each generated task file will follow this structure:

````markdown
# Convert {file} to C#

## Overview

- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: ✅/❌ `{test-file-path}`

## Dependencies (convert these first)

- [ ] `dep1.ts` → [task](./convert-dep1.md)
- [ ] `dep2.ts` → [task](./convert-dep2.md)

## Dependents (blocked until this is done)

- `dependent1.ts`
- `dependent2.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/{name}-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/{name}-depth-2.svg)

## Tests

### Class: {ClassName}

| TypeScript Test Name                              | C# Test Name                                      |
| ------------------------------------------------- | ------------------------------------------------- |
| `should initialize properly with default options` | `Should_Initialize_Properly_With_Default_Options` |
| `handles modifier keys correctly`                 | `Handles_Modifier_Keys_Correctly`                 |

## Test Execution

```bash
cd test/timewarp-tui-core-tests
dotnet fixie --tests "{ClassName}.Should_Initialize_Properly_With_Default_Options"
dotnet fixie --tests "{ClassName}.Handles_Modifier_Keys_Correctly"
```
````

## Implementation Notes

{Space for manual notes during conversion}

## Results

{Added after completion}

````

### Example: Nested Describe (Input.test.ts)

```markdown
## Tests

### Namespace: InputRenderable

#### Class: Initialization

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should initialize properly with default options` | `Should_Initialize_Properly_With_Default_Options` |
| `should initialize with custom options` | `Should_Initialize_With_Custom_Options` |

#### Class: Focus_Management

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle focus and blur correctly` | `Should_Handle_Focus_And_Blur_Correctly` |
| `should emit change event on blur if value changed` | `Should_Emit_Change_Event_On_Blur_If_Value_Changed` |

## Test Execution

```bash
cd test/timewarp-tui-core-tests
# Initialization tests
dotnet fixie --tests "InputRenderable.Initialization.Should_Initialize_Properly_With_Default_Options"
dotnet fixie --tests "InputRenderable.Initialization.Should_Initialize_With_Custom_Options"

# Focus Management tests
dotnet fixie --tests "InputRenderable.Focus_Management.Should_Handle_Focus_And_Blur_Correctly"
````

````

### Master Checklist Structure

The master checklist (`005-conversion-checklist.md`) will be structured as:

```markdown
# C# Conversion Checklist

## Progress

- Total files: {N}
- Completed: 0
- Remaining: {N}

## Phase 0 (No Dependencies) - {count} files

- [ ] [lib/RGBA.ts](./convert-lib-rgba.md)
- [ ] [ansi.ts](./convert-ansi.md)
...

## Phase 1 - {count} files

- [ ] [lib/border.ts](./convert-lib-border.md)
...

## Phase 2 - {count} files
...
````

### Expected Output

```
kanban/to-do/
├── 005-conversion-checklist.md    # Master epic/checklist
├── convert-lib-rgba.md
├── convert-ansi.md
├── convert-types.md
├── convert-renderer.md
└── ... (~59 conversion tasks)
```

---

## Clarification Decisions (Resolved)

### 1. Flat test grouping → Same file, separate classes

For `KeyHandler.test.ts` with tests like:

- `"KeyHandler - emits keypress events"`
- `"InternalKeyHandler - onInternal handlers run after regular handlers"`

**Decision:** Two separate classes in the same file (1:1 mapping with TypeScript file):

```csharp
// keyhandler-tests.cs
public class KeyHandler { ... }
public class InternalKeyHandler { ... }
```

### 2. Tests without prefix → Default to filename-derived class

**Decision:** Yes, default to class name derived from filename.

- `KeyHandler.test.ts` → `KeyHandler` class by default

### 3. Namespace handling → C# namespace for test file

**Decision:** The `Namespace` refers to the C# namespace for the test file.

This is non-traditional but makes the fully-qualified test name read much better (e.g., `InputRenderable.Initialization.Should_Initialize_Properly`).

### 4. C# file structure for nested describes → Folder with split classes

For a test file like `Input.test.ts` with multiple describe groups:

```typescript
describe("InputRenderable", () => {
  describe("Initialization", () => { ... })
  describe("Focus Management", () => { ... })
})
```

**Decision:** Use a folder that 1:1 matches the TypeScript file, then split each class to its own file inside that folder:

```
input-tests/
├── Initialization.cs
├── FocusManagement.cs
└── ... (one file per inner describe)
```

This keeps cognitive load low while maintaining the 1:1 mapping to the source file.

---

## Results

{Added after completion}
