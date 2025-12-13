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
  - [ ] Generate `kanban/to-do/{NNN}-convert-{kebab-name}.md` with:
    - [ ] Source file path
    - [ ] Phase number (dependency depth)
    - [ ] Test coverage status and test file path
    - [ ] Dependencies list with links to their task files
    - [ ] Dependents list (what's blocked by this file)
    - [ ] Links to depth-1 and depth-2 SVG files
    - [ ] Test name mapping table (TypeScript → C#)
    - [ ] Test execution commands
- [ ] Generate `kanban/to-do/201-conversion-checklist.md` master checklist:
  - [ ] Group files by phase (Phase 0, Phase 1, etc.)
  - [ ] Each file links to its conversion task
  - [ ] Checkbox format for tracking progress
- [ ] Update `scripts/analyze-deps.ts` to run task generation
- [ ] Add `--generate-tasks` flag to control task generation (optional)

## Notes

**Priority:** Medium (depends on per-file graph generation)

**Labels/Tags:** tooling, c#-conversion, automation

**Depends on:** Task 003 (per-file graphs) - COMPLETED

**Delegation:** The kanban-manager agent handles task organization only. Delegate implementation steps (script writing, code changes) to the **copilot** agent using:

```
Task(description="Implement task generation", prompt="<detailed implementation request>", subagent_type="copilot")
```

---

## Design Decisions

### 1. TypeScript → C# File Mapping (1:1)

Every TypeScript test file maps to exactly one C# test location:

| Pattern                                               | C# Structure                                             |
| ----------------------------------------------------- | -------------------------------------------------------- |
| **Flat tests** (single class or prefixed classes)     | Single file: `keyhandler-tests.cs`                       |
| **Nested describes** (multiple inner describe blocks) | Folder: `input-tests/` with one `.cs` per inner describe |

### 2. Test Class Naming

- **Flat tests without prefix**: Class name derived from filename (`KeyHandler.test.ts` → `KeyHandler` class)
- **Flat tests with prefix**: Multiple classes in same file (`"KeyHandler - ..."` and `"InternalKeyHandler - ..."` → two classes)
- **Nested describes**: Outer describe = C# namespace, inner describes = class names

### 3. C# Namespace = Outer Describe

For nested describes, the outer `describe` block becomes the C# namespace. This makes fully-qualified test names read naturally:

```
InputRenderable.Initialization.Should_Initialize_Properly_With_Default_Options
```

### 4. Test Method Naming (Pascal_Snake_Case)

- Mirror TypeScript test name exactly
- Capitalize first letter of each word, use underscores between words
- Strip redundant class name prefixes (e.g., `"KeyHandler - "`)

Examples:

- `"should initialize properly"` → `Should_Initialize_Properly`
- `"KeyHandler - emits events"` → `Emits_Events` (prefix stripped)

---

## Test Structure Patterns

### Pattern 1: Nested `describe`/`it` → Folder with split files

```typescript
// Input.test.ts
describe("InputRenderable", () => {
  describe("Initialization", () => {
    it("should initialize properly", () => { ... })
  })
  describe("Focus Management", () => {
    it("should handle focus", () => { ... })
  })
})
```

**C# Output:**

```
input-tests/
├── initialization.cs          // namespace InputRenderable { class Initialization { ... } }
└── focus-management.cs        // namespace InputRenderable { class FocusManagement { ... } }
```

### Pattern 2: Flat `test` with prefix → Single file, multiple classes

```typescript
// KeyHandler.test.ts
test("KeyHandler - emits keypress events", () => { ... })
test("InternalKeyHandler - runs after regular handlers", () => { ... })
```

**C# Output:**

```csharp
// keyhandler-tests.cs
public class KeyHandler {
    public void Emits_Keypress_Events() { ... }
}

public class InternalKeyHandler {
    public void Runs_After_Regular_Handlers() { ... }
}
```

### Pattern 3: `describe` with `test` blocks → Single file

```typescript
// env.test.ts
describe("env registry", () => {
  test("should register string env vars", () => { ... })
})
```

**C# Output:**

```csharp
// env-tests.cs
public class Env_Registry {
    public void Should_Register_String_Env_Vars() { ... }
}
```

---

## Generated Task Template

Each conversion task file will follow this structure:

```markdown
# Convert {file} to C#

## Overview

- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: ✅/❌ `{test-file-path}`

## Dependencies (convert these first)

- [ ] `dep1.ts` → [task](./NNN-convert-dep1.md)
- [ ] `dep2.ts` → [task](./NNN-convert-dep2.md)

## Dependents (blocked until this is done)

- `dependent1.ts`
- `dependent2.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/{name}-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/{name}-depth-2.svg)

## Tests

### Class: {ClassName}

| TypeScript Test Name              | C# Test Name                      |
| --------------------------------- | --------------------------------- |
| `should initialize properly`      | `Should_Initialize_Properly`      |
| `handles modifier keys correctly` | `Handles_Modifier_Keys_Correctly` |

## Test Execution

\`\`\`bash
cd test/timewarp-tui-core-tests
dotnet fixie --tests "{ClassName}.Should_Initialize_Properly"
\`\`\`

## Implementation Notes

{Space for manual notes during conversion}

## Results

{Added after completion}
```

---

## Master Checklist Structure

The master checklist (`201-conversion-checklist.md`) will be structured as:

```markdown
# C# Conversion Checklist

## Progress

- Total files: {N}
- Completed: 0
- Remaining: {N}

## Phase 0 (No Dependencies) - {count} files

- [ ] [lib/RGBA.ts](./202-convert-lib-rgba.md)
- [ ] [ansi.ts](./203-convert-ansi.md)
      ...

## Phase 1 - {count} files

- [ ] [lib/border.ts](./204-convert-lib-border.md)
      ...
```

---

## Expected Output

```
kanban/to-do/
├── 201-conversion-checklist.md       # Master epic/checklist
├── 202-convert-lib-rgba.md
├── 203-convert-ansi.md
├── 204-convert-types.md
├── 205-convert-renderer.md
└── ... (~59 conversion tasks, numbered 202-260)
```

---

## Results

{Added after completion}
