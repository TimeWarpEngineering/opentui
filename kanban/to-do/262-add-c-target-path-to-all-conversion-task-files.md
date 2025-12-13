# Add C# target path to all conversion task files

## Summary

Add the C# target file path to the Overview section of all 59 conversion task files (202-260). This ensures anyone working on a conversion knows exactly where to create the C# file.

## Todo List

- [ ] Update all conversion task files (202-260) to add Target path to Overview section
- [ ] Update `scripts/generate-conversion-tasks.ts` to include Target path in template for future regeneration

## Notes

**Target path pattern**: `source/timewarp-tui-core/{kebab-case-path}.cs`

**Conversion rules**:

1. Strip `packages/core/src/` prefix from source path
2. Convert filename to kebab-case:
   - `RGBA.ts` → `rgba.cs`
   - `KeyHandler.ts` → `key-handler.cs`
   - `ASCIIFont.ts` → `ascii-font.cs`
   - `TextNode.ts` → `text-node.cs`
3. Preserve directory structure
4. Change `.ts` extension to `.cs`

**Examples**:

| Source                                        | Target                                               |
| --------------------------------------------- | ---------------------------------------------------- |
| `packages/core/src/lib/RGBA.ts`               | `source/timewarp-tui-core/lib/rgba.cs`               |
| `packages/core/src/renderables/Input.ts`      | `source/timewarp-tui-core/renderables/input.cs`      |
| `packages/core/src/3d.ts`                     | `source/timewarp-tui-core/3d.cs`                     |
| `packages/core/src/lib/tree-sitter/client.ts` | `source/timewarp-tui-core/lib/tree-sitter/client.cs` |
| `packages/core/src/lib/KeyHandler.ts`         | `source/timewarp-tui-core/lib/key-handler.cs`        |

**Current Overview format:**

```markdown
## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: ...
```

**Updated Overview format:**

```markdown
## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/{path}`
- **Target**: `source/timewarp-tui-core/{kebab-case-path}.cs`
- **Phase**: {N}
- **Test Coverage**: ...
```

**Files to update** (from 201-conversion-checklist.md):

- 202-convert-3d.md through 260-convert-testing.md (59 files total)

## Results

_Added after completion_
