# Add repo path to all conversion task files

## Summary

Add the repo/worktree path to the Overview section of all 59 conversion task files (202-260). This ensures anyone working on a task knows exactly which repository branch/worktree to use.

## Todo List

- [x] Update all conversion task files (202-260) to add repo path to Overview section
- [x] Update `scripts/generate-conversion-tasks.ts` to include repo path in template for future regeneration

## Notes

**Repo path to add**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`

**Current Overview format:**

```markdown
## Overview

- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: ...
```

**Updated Overview format:**

```markdown
## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/{path}`
- **Phase**: {N}
- **Test Coverage**: ...
```

**Files to update** (from 201-conversion-checklist.md):

- 202-convert-3d.md through 260-convert-testing.md (59 files total)

**Implementation approach:**
Use sed or similar batch replacement across all task files in `kanban/to-do/`:

```bash
for f in kanban/to-do/2[0-5]*.md kanban/to-do/260*.md; do
  sed -i 's/^## Overview$/## Overview\n\n- **Repo**: `\/home\/steventcramer\/worktrees\/github.com\/TimeWarpEngineering\/opentui\/Cramer-2025-11-21-dev`/' "$f"
done
```

Or update the generation script and regenerate all tasks.

## Results

**Completed on 2024-12-14:**

1. Updated all 59 conversion task files (202-260) using sed to add repo path after Overview header
2. Updated `scripts/generate-conversion-tasks.ts` to include `- **Repo**: \`${ROOT}\`` in the template

All files now include the repo path in their Overview section.
