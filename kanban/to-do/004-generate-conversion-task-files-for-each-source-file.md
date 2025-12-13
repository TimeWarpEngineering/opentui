# Generate Conversion Task Files for Each Source File

## Summary

Auto-generate individual kanban task files for each convertible TypeScript file, plus a master checklist to track overall C# conversion progress.

## Todo List

- [ ] Create conversion task template
- [ ] For each convertible file (in topological/phase order):
  - [ ] Generate `kanban/to-do/convert-{kebab-name}.md` with:
    - [ ] Source file path
    - [ ] Phase number (dependency depth)
    - [ ] Test coverage status and test file path
    - [ ] Dependencies list with links to their task files
    - [ ] Dependents list (what's blocked by this file)
    - [ ] Links to depth-1 and depth-2 SVG files
- [ ] Generate `kanban/to-do/005-conversion-checklist.md` master checklist:
  - [ ] Group files by phase (Phase 0, Phase 1, etc.)
  - [ ] Each file links to its conversion task
  - [ ] Checkbox format for tracking progress
- [ ] Update `scripts/analyze-deps.ts` to run task generation
- [ ] Add `--generate-tasks` flag to control task generation (optional)

## Notes

**Priority:** Medium (depends on per-file graph generation)

**Labels/Tags:** tooling, c#-conversion, automation

**Depends on:** Task 003 (per-file graphs)

### Task Template

Each generated task file will follow this structure:

```markdown
# Convert {file} to C#

## Overview

- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: Yes/No `{test-file-path}`

## Dependencies (convert these first)

- [ ] `dep1.ts` -> [task](./convert-dep1.md)
- [ ] `dep2.ts` -> [task](./convert-dep2.md)

## Dependents (blocked until this is done)

- `dependent1.ts`
- `dependent2.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/{name}-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/{name}-depth-2.svg)

## Implementation Notes

{Space for manual notes during conversion}

## Results

{Added after completion}
```

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
```

### Expected Output

```
kanban/to-do/
├── 005-conversion-checklist.md    # Master epic/checklist
├── convert-lib-rgba.md
├── convert-ansi.md
├── convert-types.md
├── convert-renderer.md
└── ... (~25-35 conversion tasks)
```

## Results

{Added after completion}
