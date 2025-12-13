# C# Conversion Order - Dependency Analysis

Generated: 2025-12-13T16:08:37.708Z

## Overview

- **Total Files**: 110
- **Files with Tests**: 19
- **Files Missing Tests**: 86
- **Circular Dependencies**: 117
- **Examples**: 39

---

## Conversion Phases

Files are grouped by dependency depth. **Convert Phase 0 first** (no dependencies), then Phase 1, etc.

### Phase 0 (16 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/3d.ts` | 0 | 9 | ❌ |
| `packages/core/src/ansi.ts` | 0 | 3 | ❌ |
| `packages/core/src/lib/RGBA.ts` | 0 | 22 | ❌ |
| `packages/core/src/lib/scroll-acceleration.ts` | 0 | 2 | ❌ |
| `packages/core/src/lib/yoga.options.ts` | 0 | 3 | ❌ |
| `packages/core/src/lib/parse.mouse.ts` | 0 | 3 | ❌ |
| `packages/core/src/lib/singleton.ts` | 0 | 5 | ❌ |
| `packages/core/src/lib/debounce.ts` | 0 | 1 | ❌ |
| `packages/core/src/lib/queue.ts` | 0 | 1 | ❌ |
| `packages/core/src/lib/tree-sitter/types.ts` | 0 | 6 | ❌ |
| `packages/core/src/lib/validate-dir-name.ts` | 0 | 1 | ❌ |
| `packages/core/src/lib/tree-sitter/resolve-ft.ts` | 0 | 1 | ❌ |
| `packages/core/src/lib/tree-sitter/download-utils.ts` | 0 | 2 | ❌ |
| `packages/core/src/lib/output.capture.ts` | 0 | 1 | ❌ |
| `packages/core/src/lib/word-jumps.ts` | 0 | 0 | ✅ |
| `packages/core/src/testing/spy.ts` | 0 | 1 | ❌ |

### Phase 1 (16 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/post/filters.ts` | 1 | 2 | ❌ |
| `packages/core/src/lib/border.ts` | 1 | 1 | ❌ |
| `packages/core/src/lib/parse.keypress-kitty.ts` | 1 | 1 | ✅ |
| `packages/core/src/lib/env.ts` | 1 | 6 | ✅ |
| `packages/core/src/lib/tree-sitter/default-parsers.ts` | 1 | 1 | ❌ |
| `packages/core/src/renderables/Slider.ts` | 1 | 3 | ✅ |
| `packages/core/src/lib/objects-in-viewport.ts` | 1 | 2 | ❌ |
| `packages/core/src/utils.ts` | 2 | 4 | ❌ |
| `packages/core/src/lib/ascii.font.ts` | 2 | 6 | ❌ |
| `packages/core/src/lib/tree-sitter/assets/update.ts` | 2 | 1 | ❌ |
| `packages/core/src/lib/renderable.validations.ts` | 2 | 2 | ✅ |
| `packages/core/src/renderables/composition/vnode.ts` | 2 | 4 | ❌ |
| `packages/core/src/lib/tree-sitter/parser.worker.ts` | 2 | 0 | ❌ |
| `packages/core/src/renderables/FrameBuffer.ts` | 3 | 2 | ❌ |
| `packages/core/src/renderables/composition/VRenderable.ts` | 3 | 1 | ❌ |
| `packages/core/src/renderables/TextNode.ts` | 6 | 5 | ✅ |

### Phase 2 (8 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/lib/parse.keypress.ts` | 1 | 3 | ✅ |
| `packages/core/src/lib/syntax-style.ts` | 2 | 5 | ✅ |
| `packages/core/src/lib/data-paths.ts` | 3 | 2 | ✅ |
| `packages/core/src/lib/tree-sitter/client.ts` | 5 | 2 | ✅ |
| `packages/core/src/zig.ts` | 5 | 6 | ❌ |
| `packages/core/src/renderables/composition/constructs.ts` | 5 | 1 | ❌ |
| `packages/core/src/renderables/ASCIIFont.ts` | 6 | 2 | ❌ |
| `packages/core/src/console.ts` | 6 | 2 | ❌ |

### Phase 3 (4 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/lib/KeyHandler.ts` | 2 | 8 | ✅ |
| `packages/core/src/lib/hast-styled-text.ts` | 3 | 2 | ❌ |
| `packages/core/src/lib/tree-sitter-styled-text.ts` | 6 | 2 | ✅ |
| `packages/core/src/renderables/TextBufferRenderable.ts` | 7 | 3 | ❌ |

### Phase 4 (4 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/Input.ts` | 5 | 2 | ✅ |
| `packages/core/src/renderables/TabSelect.ts` | 5 | 2 | ❌ |
| `packages/core/src/renderables/Select.ts` | 6 | 2 | ❌ |
| `packages/core/src/lib/tree-sitter/index.ts` | 8 | 4 | ❌ |

### Phase 5 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/Code.ts` | 5 | 1 | ✅ |
| `packages/core/src/lib/index.ts` | 16 | 7 | ❌ |

### Phase 6 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/Box.ts` | 6 | 4 | ❌ |

### Phase 7 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/ScrollBar.ts` | 7 | 2 | ❌ |

### Phase 8 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/ScrollBox.ts` | 9 | 4 | ❌ |

### Phase 9 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/index.ts` | 16 | 5 | ❌ |

### Phase 10 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/index.ts` | 12 | 44 | ❌ |

### Phase 11 (5 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/benchmark/renderer-benchmark.ts` | 1 | 0 | ❌ |
| `packages/core/src/examples/lib/standalone-keys.ts` | 1 | 37 | ❌ |
| `packages/core/src/examples/full-unicode-demo.ts` | 1 | 1 | ❌ |
| `packages/core/src/examples/terminal-title.ts` | 1 | 0 | ❌ |
| `packages/core/src/lib/selection.ts` | 2 | 6 | ❌ |

### Phase 12 (28 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/examples/console-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/framebuffer-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/nested-zindex-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/relative-positioning-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/transparency-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/simple-layout-example.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/mouse-interaction-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/text-selection-demo.ts` | 2 | 1 | ❌ |
| `packages/core/src/examples/ascii-font-selection-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/fonts.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/fractal-shader-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/lights-phong-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/physx-planck-2d-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/physx-rapier-2d-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/scroll-example.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/sticky-scroll-example.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/sprite-animation-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/sprite-particle-generator-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/static-sprite-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/texture-loading-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/live-state-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/text-node-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/slider-demo.ts` | 3 | 0 | ❌ |
| `packages/core/src/types.ts` | 4 | 24 | ❌ |
| `packages/core/src/examples/hast-syntax-highlighting-demo.ts` | 4 | 1 | ❌ |
| `packages/core/src/examples/input-select-layout-demo.ts` | 4 | 1 | ❌ |
| `packages/core/src/examples/text-wrap.ts` | 4 | 1 | ❌ |
| `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts` | 4 | 0 | ❌ |

### Phase 13 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/renderables/Text.ts` | 7 | 6 | ✅ |

### Phase 14 (5 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/examples/tab-select-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/select-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/input-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/styled-text-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/lib/styled-text.ts` | 4 | 7 | ❌ |

### Phase 15 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/text-buffer.ts` | 4 | 9 | ✅ |

### Phase 16 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/buffer.ts` | 4 | 18 | ❌ |

### Phase 17 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/examples/shader-cube-demo.ts` | 6 | 1 | ❌ |
| `packages/core/src/Renderable.ts` | 9 | 20 | ❌ |

### Phase 18 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/examples/lib/tab-controller.ts` | 6 | 1 | ❌ |
| `packages/core/src/renderer.ts` | 14 | 8 | ❌ |

### Phase 19 (5 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/animation/Timeline.ts` | 1 | 3 | ✅ |
| `packages/core/src/testing/mock-mouse.ts` | 1 | 2 | ✅ |
| `packages/core/src/testing/mock-keys.ts` | 2 | 2 | ✅ |
| `packages/core/src/examples/opentui-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/vnode-composition-demo.ts` | 7 | 1 | ❌ |

### Phase 20 (3 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/examples/timeline-example.ts` | 3 | 1 | ❌ |
| `packages/core/src/examples/split-mode-demo.ts` | 3 | 1 | ❌ |
| `packages/core/src/testing/test-renderer.ts` | 4 | 1 | ❌ |

### Phase 21 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `packages/core/src/testing.ts` | 4 | 0 | ❌ |
| `packages/core/src/examples/index.ts` | 38 | 0 | ❌ |

---

## Test Coverage

### ✅ Files with Tests (19)

| Source File | Test File |
|-------------|-----------|
| `packages/core/src/animation/Timeline.ts` | `packages/core/src/animation/Timeline.test.ts` |
| `packages/core/src/text-buffer.ts` | `packages/core/src/text-buffer.test.ts` |
| `packages/core/src/renderables/Text.ts` | `packages/core/src/renderables/Text.test.ts` |
| `packages/core/src/lib/KeyHandler.ts` | `packages/core/src/lib/KeyHandler.test.ts` |
| `packages/core/src/lib/parse.keypress.ts` | `packages/core/src/lib/parse.keypress.test.ts` |
| `packages/core/src/lib/parse.keypress-kitty.ts` | `packages/core/src/lib/parse.keypress-kitty.test.ts` |
| `packages/core/src/lib/syntax-style.ts` | `packages/core/src/lib/syntax-style.test.ts` |
| `packages/core/src/lib/env.ts` | `packages/core/src/lib/env.test.ts` |
| `packages/core/src/lib/tree-sitter-styled-text.ts` | `packages/core/src/lib/tree-sitter-styled-text.test.ts` |
| `packages/core/src/lib/tree-sitter/client.ts` | `packages/core/src/lib/tree-sitter/client.test.ts` |
| `packages/core/src/lib/data-paths.ts` | `packages/core/src/lib/data-paths.test.ts` |
| `packages/core/src/lib/renderable.validations.ts` | `packages/core/src/lib/renderable.validations.test.ts` |
| `packages/core/src/renderables/Code.ts` | `packages/core/src/renderables/Code.test.ts` |
| `packages/core/src/renderables/TextNode.ts` | `packages/core/src/renderables/TextNode.test.ts` |
| `packages/core/src/renderables/Input.ts` | `packages/core/src/renderables/Input.test.ts` |
| `packages/core/src/renderables/Slider.ts` | `packages/core/src/renderables/Slider.test.ts` |
| `packages/core/src/lib/word-jumps.ts` | `packages/core/src/lib/word-jumps.test.ts` |
| `packages/core/src/testing/mock-keys.ts` | `packages/core/src/testing/mock-keys.test.ts` |
| `packages/core/src/testing/mock-mouse.ts` | `packages/core/src/testing/mock-mouse.test.ts` |

### ❌ Files Missing Tests (86)

- `packages/core/src/3d.ts`
- `packages/core/src/renderer.ts`
- `packages/core/src/ansi.ts`
- `packages/core/src/Renderable.ts`
- `packages/core/src/buffer.ts`
- `packages/core/src/lib/styled-text.ts`
- `packages/core/src/lib/RGBA.ts`
- `packages/core/src/types.ts`
- `packages/core/src/lib/selection.ts`
- `packages/core/src/utils.ts`
- `packages/core/src/post/filters.ts`
- `packages/core/src/lib/border.ts`
- `packages/core/src/lib/ascii.font.ts`
- `packages/core/src/lib/hast-styled-text.ts`
- `packages/core/src/lib/scroll-acceleration.ts`
- `packages/core/src/lib/yoga.options.ts`
- `packages/core/src/lib/parse.mouse.ts`
- `packages/core/src/lib/singleton.ts`
- `packages/core/src/lib/debounce.ts`
- `packages/core/src/lib/queue.ts`
- `packages/core/src/lib/tree-sitter/types.ts`
- `packages/core/src/lib/tree-sitter/default-parsers.ts`
- `packages/core/src/lib/validate-dir-name.ts`
- `packages/core/src/lib/tree-sitter/resolve-ft.ts`
- `packages/core/src/lib/tree-sitter/assets/update.ts`
- `packages/core/src/lib/tree-sitter/download-utils.ts`
- `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts`
- `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/composition/vnode.ts`
- `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/lib/objects-in-viewport.ts`
- `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts`
- `packages/core/src/console.ts`
- `packages/core/src/lib/output.capture.ts`
- `packages/core/src/benchmark/renderer-benchmark.ts`
- `packages/core/src/examples/ascii-font-selection-demo.ts`
- `packages/core/src/examples/lib/standalone-keys.ts`
- `packages/core/src/examples/console-demo.ts`
- `packages/core/src/examples/fonts.ts`
- `packages/core/src/examples/fractal-shader-demo.ts`
- `packages/core/src/examples/framebuffer-demo.ts`
- `packages/core/src/examples/full-unicode-demo.ts`
- `packages/core/src/examples/hast-syntax-highlighting-demo.ts`
- `packages/core/src/examples/lights-phong-demo.ts`
- `packages/core/src/examples/physx-planck-2d-demo.ts`
- `packages/core/src/examples/physx-rapier-2d-demo.ts`
- `packages/core/src/examples/opentui-demo.ts`
- `packages/core/src/examples/lib/tab-controller.ts`
- `packages/core/src/examples/nested-zindex-demo.ts`
- `packages/core/src/examples/relative-positioning-demo.ts`
- `packages/core/src/examples/transparency-demo.ts`
- `packages/core/src/examples/scroll-example.ts`
- `packages/core/src/examples/sticky-scroll-example.ts`
- `packages/core/src/examples/shader-cube-demo.ts`
- `packages/core/src/examples/sprite-animation-demo.ts`
- `packages/core/src/examples/sprite-particle-generator-demo.ts`
- `packages/core/src/examples/static-sprite-demo.ts`
- `packages/core/src/examples/texture-loading-demo.ts`
- `packages/core/src/examples/timeline-example.ts`
- `packages/core/src/examples/tab-select-demo.ts`
- `packages/core/src/examples/select-demo.ts`
- `packages/core/src/examples/input-demo.ts`
- `packages/core/src/examples/simple-layout-example.ts`
- `packages/core/src/examples/input-select-layout-demo.ts`
- `packages/core/src/examples/styled-text-demo.ts`
- `packages/core/src/examples/mouse-interaction-demo.ts`
- `packages/core/src/examples/text-selection-demo.ts`
- `packages/core/src/examples/split-mode-demo.ts`
- `packages/core/src/examples/vnode-composition-demo.ts`
- `packages/core/src/examples/live-state-demo.ts`
- `packages/core/src/examples/text-node-demo.ts`
- `packages/core/src/examples/text-wrap.ts`
- `packages/core/src/examples/slider-demo.ts`
- `packages/core/src/examples/terminal-title.ts`
- `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`
- `packages/core/src/lib/tree-sitter/parser.worker.ts`
- `packages/core/src/testing.ts`
- `packages/core/src/testing/test-renderer.ts`
- `packages/core/src/testing/spy.ts`

---

## Examples by Complexity

Examples ranked from simplest (fewest imports) to most complex:

| Example | Import Count |
|---------|--------------|
| `packages/core/src/examples/full-unicode-demo.ts` | 1 |
| `packages/core/src/examples/terminal-title.ts` | 1 |
| `packages/core/src/examples/mouse-interaction-demo.ts` | 2 |
| `packages/core/src/examples/framebuffer-demo.ts` | 2 |
| `packages/core/src/examples/simple-layout-example.ts` | 2 |
| `packages/core/src/examples/console-demo.ts` | 2 |
| `packages/core/src/examples/text-selection-demo.ts` | 2 |
| `packages/core/src/examples/live-state-demo.ts` | 3 |
| `packages/core/src/examples/styled-text-demo.ts` | 3 |
| `packages/core/src/examples/text-node-demo.ts` | 3 |
| `packages/core/src/examples/timeline-example.ts` | 3 |
| `packages/core/src/examples/select-demo.ts` | 3 |
| `packages/core/src/examples/transparency-demo.ts` | 3 |
| `packages/core/src/examples/sticky-scroll-example.ts` | 3 |
| `packages/core/src/examples/split-mode-demo.ts` | 3 |
| `packages/core/src/examples/tab-select-demo.ts` | 3 |
| `packages/core/src/examples/input-demo.ts` | 3 |
| `packages/core/src/examples/scroll-example.ts` | 3 |
| `packages/core/src/examples/slider-demo.ts` | 3 |
| `packages/core/src/examples/ascii-font-selection-demo.ts` | 3 |
| `packages/core/src/examples/relative-positioning-demo.ts` | 3 |
| `packages/core/src/examples/fonts.ts` | 3 |
| `packages/core/src/examples/nested-zindex-demo.ts` | 3 |
| `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts` | 4 |
| `packages/core/src/examples/opentui-demo.ts` | 4 |
| `packages/core/src/examples/hast-syntax-highlighting-demo.ts` | 4 |
| `packages/core/src/examples/input-select-layout-demo.ts` | 4 |
| `packages/core/src/examples/text-wrap.ts` | 4 |
| `packages/core/src/examples/static-sprite-demo.ts` | 6 |
| `packages/core/src/examples/fractal-shader-demo.ts` | 6 |
| `packages/core/src/examples/vnode-composition-demo.ts` | 8 |
| `packages/core/src/examples/shader-cube-demo.ts` | 9 |
| `packages/core/src/examples/texture-loading-demo.ts` | 9 |
| `packages/core/src/examples/sprite-animation-demo.ts` | 10 |
| `packages/core/src/examples/sprite-particle-generator-demo.ts` | 10 |
| `packages/core/src/examples/physx-planck-2d-demo.ts` | 10 |
| `packages/core/src/examples/lights-phong-demo.ts` | 11 |
| `packages/core/src/examples/physx-rapier-2d-demo.ts` | 11 |
| `packages/core/src/examples/index.ts` | 38 |

---

## ⚠️ Circular Dependencies

These cycles must be resolved before conversion:

- `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/console.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/lib/objects-in-viewport.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/renderer.ts` → `packages/core/src/lib/tree-sitter/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/renderables/composition/vnode.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/renderer.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/Renderable.ts` → `packages/core/src/lib/renderable.validations.ts` → `packages/core/src/Renderable.ts`
- `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts`
- `packages/core/src/buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts`
- `packages/core/src/buffer.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts`
- `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts`
- `packages/core/src/text-buffer.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts`
- `packages/core/src/lib/styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts`
- `packages/core/src/lib/styled-text.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts`
- `packages/core/src/renderables/Text.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/Text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts`
- `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts`
- `packages/core/src/types.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts`
- `packages/core/src/lib/selection.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts`
- `packages/core/src/index.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/post/filters.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/renderer.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts`
- `packages/core/src/index.ts` → `packages/core/src/console.ts` → `packages/core/src/index.ts`
- `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts`
- `packages/core/src/utils.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/utils.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/tree-sitter/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/index.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts`
- `packages/core/src/lib/parse.keypress.ts` → `packages/core/src/lib/parse.keypress-kitty.ts` → `packages/core/src/lib/parse.keypress.ts`
- `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts` → `packages/core/src/lib/tree-sitter/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts`
- `packages/core/src/lib/tree-sitter/index.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/tree-sitter/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/VRenderable.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/vnode.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/FrameBuffer.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Input.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Select.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Slider.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/TabSelect.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts`
- `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/renderables/FrameBuffer.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts`
- `packages/core/src/renderables/FrameBuffer.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/FrameBuffer.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ASCIIFont.ts` → `packages/core/src/renderables/FrameBuffer.ts`
- `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/renderable.validations.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/Box.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/Box.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/Box.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Box.ts`
- `packages/core/src/renderables/Code.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/Code.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/Code.ts` → `packages/core/src/lib/tree-sitter/index.ts` → `packages/core/src/lib/tree-sitter-styled-text.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/renderables/TextBufferRenderable.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Code.ts` → `packages/core/src/renderables/TextBufferRenderable.ts`
- `packages/core/src/zig.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts` → `packages/core/src/zig.ts`
- `packages/core/src/zig.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts` → `packages/core/src/zig.ts`
- `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/composition/vnode.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts`
- `packages/core/src/renderables/TextNode.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/zig.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/TextNode.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/hast-styled-text.ts` → `packages/core/src/lib/syntax-style.ts` → `packages/core/src/utils.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/TextNode.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts`
- `packages/core/src/renderables/composition/vnode.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/constructs.ts` → `packages/core/src/renderables/composition/vnode.ts`
- `packages/core/src/renderables/composition/VRenderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/composition/VRenderable.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/composition/VRenderable.ts`
- `packages/core/src/renderables/Input.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/Input.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Input.ts`
- `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/lib/index.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/renderables/Slider.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBar.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/lib/objects-in-viewport.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderer.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderables/Box.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderables/composition/vnode.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/ScrollBox.ts` → `packages/core/src/renderables/ScrollBar.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/ScrollBox.ts`
- `packages/core/src/renderables/Select.ts` → `packages/core/src/lib/ascii.font.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/Select.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/Select.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/Select.ts`
- `packages/core/src/renderables/TabSelect.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/TabSelect.ts`
- `packages/core/src/renderables/TabSelect.ts` → `packages/core/src/types.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/renderables/TextNode.ts` → `packages/core/src/renderables/index.ts` → `packages/core/src/renderables/TabSelect.ts`
- `packages/core/src/console.ts` → `packages/core/src/buffer.ts` → `packages/core/src/text-buffer.ts` → `packages/core/src/lib/styled-text.ts` → `packages/core/src/renderables/Text.ts` → `packages/core/src/Renderable.ts` → `packages/core/src/lib/selection.ts` → `packages/core/src/index.ts` → `packages/core/src/animation/Timeline.ts` → `packages/core/src/renderer.ts` → `packages/core/src/console.ts`

---

## Detailed File Information

<details>
<summary>Click to expand full dependency details</summary>

### `packages/core/src/3d.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (9): `packages/core/src/examples/fractal-shader-demo.ts`, `packages/core/src/examples/lights-phong-demo.ts`, `packages/core/src/examples/physx-planck-2d-demo.ts`, `packages/core/src/examples/physx-rapier-2d-demo.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/sprite-animation-demo.ts`, `packages/core/src/examples/sprite-particle-generator-demo.ts`, `packages/core/src/examples/static-sprite-demo.ts`, `packages/core/src/examples/texture-loading-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/ansi.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `packages/core/src/renderer.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/testing/mock-keys.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/RGBA.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (22): `packages/core/src/renderer.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/border.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/zig.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/console.ts`, `packages/core/src/examples/hast-syntax-highlighting-demo.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/scroll-acceleration.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `packages/core/src/lib/index.ts`, `packages/core/src/renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/yoga.options.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `packages/core/src/Renderable.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/renderable.validations.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/parse.mouse.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `packages/core/src/renderer.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/lib/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/singleton.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (5): `packages/core/src/renderer.ts`, `packages/core/src/lib/env.ts`, `packages/core/src/lib/tree-sitter/index.ts`, `packages/core/src/lib/data-paths.ts`, `packages/core/src/console.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/debounce.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/queue.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/types.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (6): `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/lib/tree-sitter/client.ts`, `packages/core/src/lib/tree-sitter/default-parsers.ts`, `packages/core/src/lib/tree-sitter/index.ts`, `packages/core/src/lib/tree-sitter/assets/update.ts`, `packages/core/src/lib/tree-sitter/parser.worker.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/validate-dir-name.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/lib/data-paths.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/resolve-ft.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/lib/tree-sitter/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/download-utils.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `packages/core/src/lib/tree-sitter/assets/update.ts`, `packages/core/src/lib/tree-sitter/parser.worker.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/output.capture.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/console.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/word-jumps.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (0): None
- **Test**: ✅ `packages/core/src/lib/word-jumps.test.ts`

### `packages/core/src/testing/spy.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `packages/core/src/testing.ts`
- **Test**: ❌ Missing

### `packages/core/src/animation/Timeline.ts`

- **Depth**: 19
- **Dependencies** (1): `packages/core/src/renderer.ts`
- **Dependents** (3): `packages/core/src/index.ts`, `packages/core/src/examples/timeline-example.ts`, `packages/core/src/examples/split-mode-demo.ts`
- **Test**: ✅ `packages/core/src/animation/Timeline.test.ts`

### `packages/core/src/post/filters.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/buffer.ts`
- **Dependents** (2): `packages/core/src/index.ts`, `packages/core/src/examples/shader-cube-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/border.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/lib/RGBA.ts`
- **Dependents** (1): `packages/core/src/lib/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/parse.keypress.ts`

- **Depth**: 2
- **Dependencies** (1): `packages/core/src/lib/parse.keypress-kitty.ts`
- **Dependents** (3): `packages/core/src/lib/index.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/parse.keypress-kitty.ts`
- **Test**: ✅ `packages/core/src/lib/parse.keypress.test.ts`

### `packages/core/src/lib/parse.keypress-kitty.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/lib/parse.keypress.ts`
- **Dependents** (1): `packages/core/src/lib/parse.keypress.ts`
- **Test**: ✅ `packages/core/src/lib/parse.keypress-kitty.test.ts`

### `packages/core/src/lib/env.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/lib/singleton.ts`
- **Dependents** (6): `packages/core/src/renderer.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/tree-sitter/client.ts`, `packages/core/src/lib/data-paths.ts`, `packages/core/src/zig.ts`, `packages/core/src/console.ts`
- **Test**: ✅ `packages/core/src/lib/env.test.ts`

### `packages/core/src/lib/tree-sitter/default-parsers.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/lib/tree-sitter/types.ts`
- **Dependents** (1): `packages/core/src/lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/Slider.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/index.ts`
- **Dependents** (3): `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/examples/slider-demo.ts`
- **Test**: ✅ `packages/core/src/renderables/Slider.test.ts`

### `packages/core/src/lib/objects-in-viewport.ts`

- **Depth**: 1
- **Dependencies** (1): `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderer.ts`, `packages/core/src/renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `packages/core/src/benchmark/renderer-benchmark.ts`

- **Depth**: 11
- **Dependencies** (1): `packages/core/src/index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/examples/lib/standalone-keys.ts`

- **Depth**: 11
- **Dependencies** (1): `packages/core/src/index.ts`
- **Dependents** (37): `packages/core/src/examples/ascii-font-selection-demo.ts`, `packages/core/src/examples/console-demo.ts`, `packages/core/src/examples/fonts.ts`, `packages/core/src/examples/fractal-shader-demo.ts`, `packages/core/src/examples/framebuffer-demo.ts`, `packages/core/src/examples/hast-syntax-highlighting-demo.ts`, `packages/core/src/examples/index.ts`, `packages/core/src/examples/lights-phong-demo.ts`, `packages/core/src/examples/physx-planck-2d-demo.ts`, `packages/core/src/examples/physx-rapier-2d-demo.ts`, `packages/core/src/examples/opentui-demo.ts`, `packages/core/src/examples/nested-zindex-demo.ts`, `packages/core/src/examples/relative-positioning-demo.ts`, `packages/core/src/examples/transparency-demo.ts`, `packages/core/src/examples/scroll-example.ts`, `packages/core/src/examples/sticky-scroll-example.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/sprite-animation-demo.ts`, `packages/core/src/examples/sprite-particle-generator-demo.ts`, `packages/core/src/examples/static-sprite-demo.ts`, `packages/core/src/examples/texture-loading-demo.ts`, `packages/core/src/examples/timeline-example.ts`, `packages/core/src/examples/tab-select-demo.ts`, `packages/core/src/examples/select-demo.ts`, `packages/core/src/examples/input-demo.ts`, `packages/core/src/examples/simple-layout-example.ts`, `packages/core/src/examples/input-select-layout-demo.ts`, `packages/core/src/examples/styled-text-demo.ts`, `packages/core/src/examples/mouse-interaction-demo.ts`, `packages/core/src/examples/text-selection-demo.ts`, `packages/core/src/examples/split-mode-demo.ts`, `packages/core/src/examples/vnode-composition-demo.ts`, `packages/core/src/examples/live-state-demo.ts`, `packages/core/src/examples/text-node-demo.ts`, `packages/core/src/examples/text-wrap.ts`, `packages/core/src/examples/slider-demo.ts`, `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/full-unicode-demo.ts`

- **Depth**: 11
- **Dependencies** (1): `packages/core/src/index.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/terminal-title.ts`

- **Depth**: 11
- **Dependencies** (1): `packages/core/src/index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/testing/mock-mouse.ts`

- **Depth**: 19
- **Dependencies** (1): `packages/core/src/renderer.ts`
- **Dependents** (2): `packages/core/src/testing.ts`, `packages/core/src/testing/test-renderer.ts`
- **Test**: ✅ `packages/core/src/testing/mock-mouse.test.ts`

### `packages/core/src/lib/selection.ts`

- **Depth**: 11
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/lib/ascii.font.ts`
- **Dependents** (6): `packages/core/src/renderer.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`
- **Test**: ❌ Missing

### `packages/core/src/utils.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/types.ts`, `packages/core/src/Renderable.ts`
- **Dependents** (4): `packages/core/src/lib/styled-text.ts`, `packages/core/src/index.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/KeyHandler.ts`

- **Depth**: 3
- **Dependencies** (2): `packages/core/src/lib/parse.keypress.ts`, `packages/core/src/ansi.ts`
- **Dependents** (8): `packages/core/src/renderer.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/TabSelect.ts`
- **Test**: ✅ `packages/core/src/lib/KeyHandler.test.ts`

### `packages/core/src/lib/ascii.font.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/buffer.ts`, `packages/core/src/lib/RGBA.ts`
- **Dependents** (6): `packages/core/src/lib/selection.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/examples/fonts.ts`, `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/syntax-style.ts`

- **Depth**: 2
- **Dependencies** (2): `packages/core/src/lib/RGBA.ts`, `packages/core/src/utils.ts`
- **Dependents** (5): `packages/core/src/lib/index.ts`, `packages/core/src/lib/hast-styled-text.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/lib/tree-sitter/index.ts`, `packages/core/src/renderables/Code.ts`
- **Test**: ✅ `packages/core/src/lib/syntax-style.test.ts`

### `packages/core/src/lib/tree-sitter/assets/update.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/lib/tree-sitter/download-utils.ts`, `packages/core/src/lib/tree-sitter/types.ts`
- **Dependents** (1): `packages/core/src/lib/tree-sitter/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/renderable.validations.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/Renderable.ts`, `packages/core/src/lib/yoga.options.ts`
- **Dependents** (2): `packages/core/src/Renderable.ts`, `packages/core/src/renderables/Box.ts`
- **Test**: ✅ `packages/core/src/lib/renderable.validations.test.ts`

### `packages/core/src/renderables/composition/vnode.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`
- **Dependents** (4): `packages/core/src/Renderable.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/console-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/framebuffer-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/nested-zindex-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/relative-positioning-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/transparency-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/simple-layout-example.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/mouse-interaction-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/text-selection-demo.ts`

- **Depth**: 12
- **Dependencies** (2): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/parser.worker.ts`

- **Depth**: 1
- **Dependencies** (2): `packages/core/src/lib/tree-sitter/types.ts`, `packages/core/src/lib/tree-sitter/download-utils.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/testing/mock-keys.ts`

- **Depth**: 19
- **Dependencies** (2): `packages/core/src/renderer.ts`, `packages/core/src/ansi.ts`
- **Dependents** (2): `packages/core/src/testing.ts`, `packages/core/src/testing/test-renderer.ts`
- **Test**: ✅ `packages/core/src/testing/mock-keys.test.ts`

### `packages/core/src/lib/hast-styled-text.ts`

- **Depth**: 3
- **Dependencies** (3): `packages/core/src/text-buffer.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/lib/syntax-style.ts`
- **Dependents** (2): `packages/core/src/lib/index.ts`, `packages/core/src/examples/hast-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/data-paths.ts`

- **Depth**: 2
- **Dependencies** (3): `packages/core/src/lib/singleton.ts`, `packages/core/src/lib/env.ts`, `packages/core/src/lib/validate-dir-name.ts`
- **Dependents** (2): `packages/core/src/lib/index.ts`, `packages/core/src/lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/data-paths.test.ts`

### `packages/core/src/renderables/FrameBuffer.ts`

- **Depth**: 1
- **Dependencies** (3): `packages/core/src/Renderable.ts`, `packages/core/src/buffer.ts`, `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/ASCIIFont.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/composition/VRenderable.ts`

- **Depth**: 1
- **Dependencies** (3): `packages/core/src/Renderable.ts`, `packages/core/src/buffer.ts`, `packages/core/src/types.ts`
- **Dependents** (1): `packages/core/src/renderables/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/ascii-font-selection-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/fonts.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/fractal-shader-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/lights-phong-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/physx-planck-2d-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/physx-rapier-2d-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/opentui-demo.ts`

- **Depth**: 19
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/scroll-example.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/sticky-scroll-example.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/sprite-animation-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/sprite-particle-generator-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/static-sprite-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/texture-loading-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/timeline-example.ts`

- **Depth**: 20
- **Dependencies** (3): `packages/core/src/animation/Timeline.ts`, `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/tab-select-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/renderables/Text.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/select-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/renderables/Text.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/input-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/renderables/Text.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/styled-text-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/split-mode-demo.ts`

- **Depth**: 20
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/animation/Timeline.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/live-state-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/text-node-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/slider-demo.ts`

- **Depth**: 12
- **Dependencies** (3): `packages/core/src/index.ts`, `packages/core/src/renderables/Slider.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/buffer.ts`

- **Depth**: 16
- **Dependencies** (4): `packages/core/src/text-buffer.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/zig.ts`, `packages/core/src/types.ts`
- **Dependents** (18): `packages/core/src/renderer.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/index.ts`, `packages/core/src/post/filters.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/renderables/FrameBuffer.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/zig.ts`, `packages/core/src/renderables/composition/VRenderable.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/console.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/text-buffer.ts`

- **Depth**: 15
- **Dependencies** (4): `packages/core/src/lib/styled-text.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/zig.ts`, `packages/core/src/types.ts`
- **Dependents** (9): `packages/core/src/buffer.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/index.ts`, `packages/core/src/lib/hast-styled-text.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/zig.ts`, `packages/core/src/renderables/TextNode.ts`
- **Test**: ✅ `packages/core/src/text-buffer.test.ts`

### `packages/core/src/lib/styled-text.ts`

- **Depth**: 14
- **Dependencies** (4): `packages/core/src/renderables/Text.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/utils.ts`, `packages/core/src/lib/RGBA.ts`
- **Dependents** (7): `packages/core/src/text-buffer.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/hast-styled-text.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/renderables/Code.ts`, `packages/core/src/renderables/TextNode.ts`
- **Test**: ❌ Missing

### `packages/core/src/types.ts`

- **Depth**: 12
- **Dependencies** (4): `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/lib/KeyHandler.ts`
- **Dependents** (24): `packages/core/src/renderer.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/buffer.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/index.ts`, `packages/core/src/utils.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/FrameBuffer.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/Code.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/zig.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/renderables/composition/VRenderable.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/lib/objects-in-viewport.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/hast-syntax-highlighting-demo.ts`

- **Depth**: 12
- **Dependencies** (4): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/hast-styled-text.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/input-select-layout-demo.ts`

- **Depth**: 12
- **Dependencies** (4): `packages/core/src/index.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/text-wrap.ts`

- **Depth**: 12
- **Dependencies** (4): `packages/core/src/index.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`

- **Depth**: 12
- **Dependencies** (4): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/tree-sitter/index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/testing.ts`

- **Depth**: 21
- **Dependencies** (4): `packages/core/src/testing/test-renderer.ts`, `packages/core/src/testing/mock-keys.ts`, `packages/core/src/testing/mock-mouse.ts`, `packages/core/src/testing/spy.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `packages/core/src/testing/test-renderer.ts`

- **Depth**: 20
- **Dependencies** (4): `packages/core/src/renderer.ts`, `packages/core/src/zig.ts`, `packages/core/src/testing/mock-keys.ts`, `packages/core/src/testing/mock-mouse.ts`
- **Dependents** (1): `packages/core/src/testing.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/client.ts`

- **Depth**: 2
- **Dependencies** (5): `packages/core/src/lib/debounce.ts`, `packages/core/src/lib/queue.ts`, `packages/core/src/lib/tree-sitter/types.ts`, `packages/core/src/lib/tree-sitter/default-parsers.ts`, `packages/core/src/lib/env.ts`
- **Dependents** (2): `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/tree-sitter/client.test.ts`

### `packages/core/src/renderables/Code.ts`

- **Depth**: 5
- **Dependencies** (5): `packages/core/src/types.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/lib/tree-sitter/index.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`
- **Dependents** (1): `packages/core/src/renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/Code.test.ts`

### `packages/core/src/zig.ts`

- **Depth**: 2
- **Dependencies** (5): `packages/core/src/types.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/buffer.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/lib/env.ts`
- **Dependents** (6): `packages/core/src/renderer.ts`, `packages/core/src/buffer.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/index.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/testing/test-renderer.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/composition/constructs.ts`

- **Depth**: 2
- **Dependencies** (5): `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/RGBA.ts`
- **Dependents** (1): `packages/core/src/renderables/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/Input.ts`

- **Depth**: 4
- **Dependencies** (5): `packages/core/src/buffer.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/examples/input-select-layout-demo.ts`
- **Test**: ✅ `packages/core/src/renderables/Input.test.ts`

### `packages/core/src/renderables/TabSelect.ts`

- **Depth**: 4
- **Dependencies** (5): `packages/core/src/Renderable.ts`, `packages/core/src/buffer.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/examples/lib/tab-controller.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter-styled-text.ts`

- **Depth**: 3
- **Dependencies** (6): `packages/core/src/text-buffer.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/lib/tree-sitter/client.ts`, `packages/core/src/lib/tree-sitter/types.ts`, `packages/core/src/utils.ts`
- **Dependents** (2): `packages/core/src/lib/index.ts`, `packages/core/src/lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/tree-sitter-styled-text.test.ts`

### `packages/core/src/renderables/ASCIIFont.ts`

- **Depth**: 2
- **Dependencies** (6): `packages/core/src/Renderable.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/renderables/FrameBuffer.ts`, `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/examples/ascii-font-selection-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/Box.ts`

- **Depth**: 6
- **Dependencies** (6): `packages/core/src/Renderable.ts`, `packages/core/src/lib/renderable.validations.ts`, `packages/core/src/buffer.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/types.ts`
- **Dependents** (4): `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/live-state-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/TextNode.ts`

- **Depth**: 1
- **Dependencies** (6): `packages/core/src/renderables/index.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/types.ts`
- **Dependents** (5): `packages/core/src/renderables/Text.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/examples/text-node-demo.ts`, `packages/core/src/examples/text-wrap.ts`
- **Test**: ✅ `packages/core/src/renderables/TextNode.test.ts`

### `packages/core/src/renderables/Select.ts`

- **Depth**: 4
- **Dependencies** (6): `packages/core/src/buffer.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/examples/input-select-layout-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/console.ts`

- **Depth**: 2
- **Dependencies** (6): `packages/core/src/index.ts`, `packages/core/src/buffer.ts`, `packages/core/src/lib/output.capture.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/singleton.ts`, `packages/core/src/lib/env.ts`
- **Dependents** (2): `packages/core/src/renderer.ts`, `packages/core/src/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/lib/tab-controller.ts`

- **Depth**: 18
- **Dependencies** (6): `packages/core/src/Renderable.ts`, `packages/core/src/buffer.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/index.ts`, `packages/core/src/lib/RGBA.ts`
- **Dependents** (1): `packages/core/src/examples/opentui-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/shader-cube-demo.ts`

- **Depth**: 17
- **Dependencies** (6): `packages/core/src/index.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/post/filters.ts`, `packages/core/src/buffer.ts`, `packages/core/src/3d.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/Text.ts`

- **Depth**: 13
- **Dependencies** (7): `packages/core/src/Renderable.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/types.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`
- **Dependents** (6): `packages/core/src/lib/styled-text.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/examples/tab-select-demo.ts`, `packages/core/src/examples/select-demo.ts`, `packages/core/src/examples/input-demo.ts`, `packages/core/src/examples/styled-text-demo.ts`
- **Test**: ✅ `packages/core/src/renderables/Text.test.ts`

### `packages/core/src/renderables/TextBufferRenderable.ts`

- **Depth**: 3
- **Dependencies** (7): `packages/core/src/Renderable.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/types.ts`, `packages/core/src/buffer.ts`, `packages/core/src/zig.ts`
- **Dependents** (3): `packages/core/src/renderables/Text.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/Code.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/ScrollBar.ts`

- **Depth**: 7
- **Dependencies** (7): `packages/core/src/buffer.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/Slider.ts`
- **Dependents** (2): `packages/core/src/renderables/index.ts`, `packages/core/src/renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/vnode-composition-demo.ts`

- **Depth**: 19
- **Dependencies** (7): `packages/core/src/renderer.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/types.ts`, `packages/core/src/buffer.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/Renderable.ts`
- **Dependents** (1): `packages/core/src/examples/index.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/tree-sitter/index.ts`

- **Depth**: 4
- **Dependencies** (8): `packages/core/src/lib/singleton.ts`, `packages/core/src/lib/tree-sitter/client.ts`, `packages/core/src/lib/tree-sitter/types.ts`, `packages/core/src/lib/data-paths.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/lib/tree-sitter/resolve-ft.ts`, `packages/core/src/lib/tree-sitter/assets/update.ts`
- **Dependents** (4): `packages/core/src/renderer.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/renderables/Code.ts`, `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/Renderable.ts`

- **Depth**: 17
- **Dependencies** (9): `packages/core/src/buffer.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/parse.mouse.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/lib/yoga.options.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/renderer.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/renderable.validations.ts`
- **Dependents** (20): `packages/core/src/renderer.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/types.ts`, `packages/core/src/index.ts`, `packages/core/src/utils.ts`, `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/FrameBuffer.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/lib/renderable.validations.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/renderables/composition/VRenderable.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/ScrollBox.ts`

- **Depth**: 8
- **Dependencies** (9): `packages/core/src/lib/index.ts`, `packages/core/src/lib/objects-in-viewport.ts`, `packages/core/src/lib/scroll-acceleration.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/renderer.ts`, `packages/core/src/types.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/renderables/ScrollBar.ts`
- **Dependents** (4): `packages/core/src/renderables/index.ts`, `packages/core/src/examples/scroll-example.ts`, `packages/core/src/examples/sticky-scroll-example.ts`, `packages/core/src/examples/text-wrap.ts`
- **Test**: ❌ Missing

### `packages/core/src/index.ts`

- **Depth**: 10
- **Dependencies** (12): `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`, `packages/core/src/utils.ts`, `packages/core/src/buffer.ts`, `packages/core/src/text-buffer.ts`, `packages/core/src/post/filters.ts`, `packages/core/src/animation/Timeline.ts`, `packages/core/src/lib/index.ts`, `packages/core/src/renderer.ts`, `packages/core/src/renderables/index.ts`, `packages/core/src/zig.ts`, `packages/core/src/console.ts`
- **Dependents** (44): `packages/core/src/lib/selection.ts`, `packages/core/src/renderables/Slider.ts`, `packages/core/src/console.ts`, `packages/core/src/benchmark/renderer-benchmark.ts`, `packages/core/src/examples/ascii-font-selection-demo.ts`, `packages/core/src/examples/lib/standalone-keys.ts`, `packages/core/src/examples/console-demo.ts`, `packages/core/src/examples/fonts.ts`, `packages/core/src/examples/fractal-shader-demo.ts`, `packages/core/src/examples/framebuffer-demo.ts`, `packages/core/src/examples/full-unicode-demo.ts`, `packages/core/src/examples/hast-syntax-highlighting-demo.ts`, `packages/core/src/examples/index.ts`, `packages/core/src/examples/lights-phong-demo.ts`, `packages/core/src/examples/physx-planck-2d-demo.ts`, `packages/core/src/examples/physx-rapier-2d-demo.ts`, `packages/core/src/examples/opentui-demo.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/nested-zindex-demo.ts`, `packages/core/src/examples/relative-positioning-demo.ts`, `packages/core/src/examples/transparency-demo.ts`, `packages/core/src/examples/scroll-example.ts`, `packages/core/src/examples/sticky-scroll-example.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/sprite-animation-demo.ts`, `packages/core/src/examples/sprite-particle-generator-demo.ts`, `packages/core/src/examples/static-sprite-demo.ts`, `packages/core/src/examples/texture-loading-demo.ts`, `packages/core/src/examples/timeline-example.ts`, `packages/core/src/examples/tab-select-demo.ts`, `packages/core/src/examples/select-demo.ts`, `packages/core/src/examples/input-demo.ts`, `packages/core/src/examples/simple-layout-example.ts`, `packages/core/src/examples/input-select-layout-demo.ts`, `packages/core/src/examples/styled-text-demo.ts`, `packages/core/src/examples/mouse-interaction-demo.ts`, `packages/core/src/examples/text-selection-demo.ts`, `packages/core/src/examples/split-mode-demo.ts`, `packages/core/src/examples/live-state-demo.ts`, `packages/core/src/examples/text-node-demo.ts`, `packages/core/src/examples/text-wrap.ts`, `packages/core/src/examples/slider-demo.ts`, `packages/core/src/examples/terminal-title.ts`, `packages/core/src/examples/tree-sitter-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderer.ts`

- **Depth**: 18
- **Dependencies** (14): `packages/core/src/ansi.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/types.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/buffer.ts`, `packages/core/src/zig.ts`, `packages/core/src/console.ts`, `packages/core/src/lib/parse.mouse.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/lib/singleton.ts`, `packages/core/src/lib/objects-in-viewport.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/env.ts`, `packages/core/src/lib/tree-sitter/index.ts`
- **Dependents** (8): `packages/core/src/animation/Timeline.ts`, `packages/core/src/Renderable.ts`, `packages/core/src/index.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/vnode-composition-demo.ts`, `packages/core/src/testing/test-renderer.ts`, `packages/core/src/testing/mock-keys.ts`, `packages/core/src/testing/mock-mouse.ts`
- **Test**: ❌ Missing

### `packages/core/src/lib/index.ts`

- **Depth**: 5
- **Dependencies** (16): `packages/core/src/lib/border.ts`, `packages/core/src/lib/KeyHandler.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/lib/hast-styled-text.ts`, `packages/core/src/lib/RGBA.ts`, `packages/core/src/lib/parse.keypress.ts`, `packages/core/src/lib/scroll-acceleration.ts`, `packages/core/src/lib/styled-text.ts`, `packages/core/src/lib/yoga.options.ts`, `packages/core/src/lib/parse.mouse.ts`, `packages/core/src/lib/selection.ts`, `packages/core/src/lib/env.ts`, `packages/core/src/lib/tree-sitter-styled-text.ts`, `packages/core/src/lib/tree-sitter/index.ts`, `packages/core/src/lib/syntax-style.ts`, `packages/core/src/lib/data-paths.ts`
- **Dependents** (7): `packages/core/src/buffer.ts`, `packages/core/src/index.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/renderables/index.ts`

- **Depth**: 9
- **Dependencies** (16): `packages/core/src/renderables/ASCIIFont.ts`, `packages/core/src/renderables/Box.ts`, `packages/core/src/renderables/Code.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/renderables/composition/VRenderable.ts`, `packages/core/src/renderables/composition/vnode.ts`, `packages/core/src/renderables/FrameBuffer.ts`, `packages/core/src/renderables/Input.ts`, `packages/core/src/renderables/ScrollBar.ts`, `packages/core/src/renderables/ScrollBox.ts`, `packages/core/src/renderables/Select.ts`, `packages/core/src/renderables/Slider.ts`, `packages/core/src/renderables/TabSelect.ts`, `packages/core/src/renderables/Text.ts`, `packages/core/src/renderables/TextBufferRenderable.ts`, `packages/core/src/renderables/TextNode.ts`
- **Dependents** (5): `packages/core/src/index.ts`, `packages/core/src/renderables/composition/constructs.ts`, `packages/core/src/renderables/TextNode.ts`, `packages/core/src/examples/lib/tab-controller.ts`, `packages/core/src/examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `packages/core/src/examples/index.ts`

- **Depth**: 21
- **Dependencies** (38): `packages/core/src/index.ts`, `packages/core/src/lib/ascii.font.ts`, `packages/core/src/examples/fonts.ts`, `packages/core/src/examples/fractal-shader-demo.ts`, `packages/core/src/examples/framebuffer-demo.ts`, `packages/core/src/examples/lights-phong-demo.ts`, `packages/core/src/examples/physx-planck-2d-demo.ts`, `packages/core/src/examples/physx-rapier-2d-demo.ts`, `packages/core/src/examples/opentui-demo.ts`, `packages/core/src/examples/nested-zindex-demo.ts`, `packages/core/src/examples/relative-positioning-demo.ts`, `packages/core/src/examples/transparency-demo.ts`, `packages/core/src/examples/scroll-example.ts`, `packages/core/src/examples/sticky-scroll-example.ts`, `packages/core/src/examples/shader-cube-demo.ts`, `packages/core/src/examples/sprite-animation-demo.ts`, `packages/core/src/examples/sprite-particle-generator-demo.ts`, `packages/core/src/examples/static-sprite-demo.ts`, `packages/core/src/examples/texture-loading-demo.ts`, `packages/core/src/examples/timeline-example.ts`, `packages/core/src/examples/tab-select-demo.ts`, `packages/core/src/examples/select-demo.ts`, `packages/core/src/examples/input-demo.ts`, `packages/core/src/examples/simple-layout-example.ts`, `packages/core/src/examples/input-select-layout-demo.ts`, `packages/core/src/examples/styled-text-demo.ts`, `packages/core/src/examples/mouse-interaction-demo.ts`, `packages/core/src/examples/text-selection-demo.ts`, `packages/core/src/examples/ascii-font-selection-demo.ts`, `packages/core/src/examples/split-mode-demo.ts`, `packages/core/src/examples/console-demo.ts`, `packages/core/src/examples/vnode-composition-demo.ts`, `packages/core/src/examples/hast-syntax-highlighting-demo.ts`, `packages/core/src/examples/live-state-demo.ts`, `packages/core/src/examples/full-unicode-demo.ts`, `packages/core/src/examples/text-node-demo.ts`, `packages/core/src/examples/text-wrap.ts`, `packages/core/src/examples/lib/standalone-keys.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

</details>
