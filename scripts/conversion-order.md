# C# Conversion Order - Dependency Analysis

Generated: 2025-12-13T06:56:52.625Z

## Overview

- **Total Files**: 128
- **Files with Tests**: 19
- **Files Missing Tests**: 104
- **Circular Dependencies**: 53
- **Examples**: 39

---

## Conversion Phases

Files are grouped by dependency depth. **Convert Phase 0 first** (no dependencies), then Phase 1, etc.

### Phase 0 (34 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `3d.ts` | 0 | 9 | ❌ |
| `ansi.ts` | 0 | 3 | ❌ |
| `examples/assets/Water_2_M_Normal.jpg` | 0 | 1 | ❌ |
| `examples/assets/concrete.png` | 0 | 1 | ❌ |
| `examples/assets/crate.png` | 0 | 3 | ❌ |
| `examples/assets/crate_emissive.png` | 0 | 2 | ❌ |
| `examples/assets/forrest_background.png` | 0 | 1 | ❌ |
| `examples/assets/hast-example.json` | 0 | 1 | ❌ |
| `examples/assets/heart.png` | 0 | 1 | ❌ |
| `examples/assets/main_char_idle.png` | 0 | 2 | ❌ |
| `examples/assets/main_char_run_loop.png` | 0 | 1 | ❌ |
| `examples/assets/roughness_map.jpg` | 0 | 1 | ❌ |
| `lib/RGBA.ts` | 0 | 22 | ❌ |
| `lib/debounce.ts` | 0 | 1 | ❌ |
| `lib/fonts/block.json` | 0 | 1 | ❌ |
| `lib/fonts/shade.json` | 0 | 1 | ❌ |
| `lib/fonts/slick.json` | 0 | 1 | ❌ |
| `lib/fonts/tiny.json` | 0 | 1 | ❌ |
| `lib/output.capture.ts` | 0 | 1 | ❌ |
| `lib/parse.mouse.ts` | 0 | 3 | ❌ |
| `lib/queue.ts` | 0 | 1 | ❌ |
| `lib/scroll-acceleration.ts` | 0 | 2 | ❌ |
| `lib/singleton.ts` | 0 | 5 | ❌ |
| `lib/tree-sitter/assets/javascript/highlights.scm` | 0 | 1 | ❌ |
| `lib/tree-sitter/assets/javascript/tree-sitter-javascript.wasm` | 0 | 1 | ❌ |
| `lib/tree-sitter/assets/typescript/highlights.scm` | 0 | 1 | ❌ |
| `lib/tree-sitter/assets/typescript/tree-sitter-typescript.wasm` | 0 | 1 | ❌ |
| `lib/tree-sitter/download-utils.ts` | 0 | 2 | ❌ |
| `lib/tree-sitter/resolve-ft.ts` | 0 | 1 | ❌ |
| `lib/tree-sitter/types.ts` | 0 | 6 | ❌ |
| `lib/validate-dir-name.ts` | 0 | 1 | ❌ |
| `lib/word-jumps.ts` | 0 | 0 | ✅ |
| `lib/yoga.options.ts` | 0 | 3 | ❌ |
| `testing/spy.ts` | 0 | 1 | ❌ |

### Phase 1 (10 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/border.ts` | 1 | 1 | ❌ |
| `lib/env.ts` | 1 | 6 | ✅ |
| `lib/parse.keypress-kitty.ts` | 1 | 1 | ✅ |
| `post/filters.ts` | 1 | 2 | ❌ |
| `renderables/Slider.ts` | 1 | 3 | ✅ |
| `lib/renderable.validations.ts` | 2 | 2 | ✅ |
| `lib/tree-sitter/assets/update.ts` | 2 | 1 | ❌ |
| `lib/tree-sitter/parser.worker.ts` | 2 | 0 | ❌ |
| `lib/tree-sitter/default-parsers.ts` | 5 | 1 | ❌ |
| `lib/ascii.font.ts` | 6 | 6 | ❌ |

### Phase 2 (4 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/parse.keypress.ts` | 1 | 3 | ✅ |
| `lib/data-paths.ts` | 3 | 2 | ✅ |
| `lib/tree-sitter/client.ts` | 5 | 2 | ✅ |
| `console.ts` | 6 | 2 | ❌ |

### Phase 3 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/KeyHandler.ts` | 2 | 8 | ✅ |

### Phase 4 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `types.ts` | 4 | 24 | ❌ |

### Phase 5 (10 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/objects-in-viewport.ts` | 1 | 2 | ❌ |
| `renderables/composition/vnode.ts` | 2 | 4 | ❌ |
| `utils.ts` | 2 | 4 | ❌ |
| `renderables/FrameBuffer.ts` | 3 | 2 | ❌ |
| `renderables/composition/VRenderable.ts` | 3 | 1 | ❌ |
| `renderables/Input.ts` | 5 | 2 | ✅ |
| `renderables/TabSelect.ts` | 5 | 2 | ❌ |
| `zig.ts` | 5 | 6 | ❌ |
| `renderables/Box.ts` | 6 | 4 | ❌ |
| `renderables/Select.ts` | 6 | 2 | ❌ |

### Phase 6 (4 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/syntax-style.ts` | 2 | 5 | ✅ |
| `text-buffer.ts` | 4 | 9 | ✅ |
| `renderables/ASCIIFont.ts` | 6 | 2 | ❌ |
| `renderables/ScrollBar.ts` | 7 | 2 | ❌ |

### Phase 7 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/tree-sitter-styled-text.ts` | 6 | 2 | ✅ |
| `renderables/TextNode.ts` | 6 | 5 | ✅ |

### Phase 8 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `renderables/composition/constructs.ts` | 5 | 1 | ❌ |
| `lib/tree-sitter/index.ts` | 8 | 4 | ❌ |

### Phase 9 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `renderables/Code.ts` | 5 | 1 | ✅ |
| `renderer.ts` | 14 | 8 | ❌ |

### Phase 10 (4 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `animation/Timeline.ts` | 1 | 3 | ✅ |
| `testing/mock-mouse.ts` | 1 | 2 | ✅ |
| `testing/mock-keys.ts` | 2 | 2 | ✅ |
| `renderables/ScrollBox.ts` | 9 | 4 | ❌ |

### Phase 11 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `testing/test-renderer.ts` | 4 | 1 | ❌ |
| `renderables/index.ts` | 16 | 5 | ❌ |

### Phase 12 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `testing.ts` | 4 | 0 | ❌ |
| `index.ts` | 12 | 44 | ❌ |

### Phase 13 (5 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/full-unicode-demo.ts` | 1 | 1 | ❌ |
| `examples/lib/standalone-keys.ts` | 1 | 37 | ❌ |
| `examples/terminal-title.ts` | 1 | 0 | ❌ |
| `lib/selection.ts` | 2 | 6 | ❌ |
| `benchmark/renderer-benchmark.ts` | 3 | 0 | ❌ |

### Phase 14 (29 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/console-demo.ts` | 2 | 1 | ❌ |
| `examples/framebuffer-demo.ts` | 2 | 1 | ❌ |
| `examples/mouse-interaction-demo.ts` | 2 | 1 | ❌ |
| `examples/nested-zindex-demo.ts` | 2 | 1 | ❌ |
| `examples/relative-positioning-demo.ts` | 2 | 1 | ❌ |
| `examples/simple-layout-example.ts` | 2 | 1 | ❌ |
| `examples/text-selection-demo.ts` | 2 | 1 | ❌ |
| `examples/transparency-demo.ts` | 2 | 1 | ❌ |
| `examples/ascii-font-selection-demo.ts` | 3 | 1 | ❌ |
| `examples/fonts.ts` | 3 | 1 | ❌ |
| `examples/fractal-shader-demo.ts` | 3 | 1 | ❌ |
| `examples/live-state-demo.ts` | 3 | 1 | ❌ |
| `examples/scroll-example.ts` | 3 | 1 | ❌ |
| `examples/slider-demo.ts` | 3 | 0 | ❌ |
| `examples/split-mode-demo.ts` | 3 | 1 | ❌ |
| `examples/sticky-scroll-example.ts` | 3 | 1 | ❌ |
| `examples/text-node-demo.ts` | 3 | 1 | ❌ |
| `examples/timeline-example.ts` | 3 | 1 | ❌ |
| `examples/input-select-layout-demo.ts` | 4 | 1 | ❌ |
| `examples/physx-planck-2d-demo.ts` | 4 | 1 | ❌ |
| `examples/physx-rapier-2d-demo.ts` | 4 | 1 | ❌ |
| `examples/sprite-animation-demo.ts` | 4 | 1 | ❌ |
| `examples/static-sprite-demo.ts` | 4 | 1 | ❌ |
| `examples/text-wrap.ts` | 4 | 1 | ❌ |
| `examples/tree-sitter-syntax-highlighting-demo.ts` | 4 | 0 | ❌ |
| `examples/lights-phong-demo.ts` | 5 | 1 | ❌ |
| `examples/texture-loading-demo.ts` | 5 | 1 | ❌ |
| `examples/sprite-particle-generator-demo.ts` | 6 | 1 | ❌ |
| `renderables/TextBufferRenderable.ts` | 7 | 3 | ❌ |

### Phase 15 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `renderables/Text.ts` | 7 | 6 | ✅ |

### Phase 16 (5 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/input-demo.ts` | 3 | 1 | ❌ |
| `examples/select-demo.ts` | 3 | 1 | ❌ |
| `examples/styled-text-demo.ts` | 3 | 1 | ❌ |
| `examples/tab-select-demo.ts` | 3 | 1 | ❌ |
| `lib/styled-text.ts` | 4 | 7 | ❌ |

### Phase 17 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `lib/hast-styled-text.ts` | 3 | 2 | ❌ |

### Phase 18 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/hast-syntax-highlighting-demo.ts` | 5 | 1 | ❌ |
| `lib/index.ts` | 16 | 7 | ❌ |

### Phase 19 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `buffer.ts` | 4 | 18 | ❌ |

### Phase 20 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/shader-cube-demo.ts` | 6 | 1 | ❌ |
| `Renderable.ts` | 9 | 20 | ❌ |

### Phase 21 (2 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/lib/tab-controller.ts` | 6 | 1 | ❌ |
| `examples/vnode-composition-demo.ts` | 7 | 1 | ❌ |

### Phase 22 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/opentui-demo.ts` | 3 | 1 | ❌ |

### Phase 23 (1 files)

| File | Dependencies | Dependents | Has Test |
|------|--------------|------------|----------|
| `examples/index.ts` | 38 | 0 | ❌ |

---

## Test Coverage

### ✅ Files with Tests (19)

| Source File | Test File |
|-------------|-----------|
| `animation/Timeline.ts` | `packages/core/src/animation/Timeline.test.ts` |
| `lib/KeyHandler.ts` | `packages/core/src/lib/KeyHandler.test.ts` |
| `lib/data-paths.ts` | `packages/core/src/lib/data-paths.test.ts` |
| `lib/env.ts` | `packages/core/src/lib/env.test.ts` |
| `lib/parse.keypress-kitty.ts` | `packages/core/src/lib/parse.keypress-kitty.test.ts` |
| `lib/parse.keypress.ts` | `packages/core/src/lib/parse.keypress.test.ts` |
| `lib/renderable.validations.ts` | `packages/core/src/lib/renderable.validations.test.ts` |
| `lib/syntax-style.ts` | `packages/core/src/lib/syntax-style.test.ts` |
| `lib/tree-sitter-styled-text.ts` | `packages/core/src/lib/tree-sitter-styled-text.test.ts` |
| `lib/tree-sitter/client.ts` | `packages/core/src/lib/tree-sitter/client.test.ts` |
| `lib/word-jumps.ts` | `packages/core/src/lib/word-jumps.test.ts` |
| `renderables/Code.ts` | `packages/core/src/renderables/Code.test.ts` |
| `renderables/Input.ts` | `packages/core/src/renderables/Input.test.ts` |
| `renderables/Slider.ts` | `packages/core/src/renderables/Slider.test.ts` |
| `renderables/Text.ts` | `packages/core/src/renderables/Text.test.ts` |
| `renderables/TextNode.ts` | `packages/core/src/renderables/TextNode.test.ts` |
| `testing/mock-keys.ts` | `packages/core/src/testing/mock-keys.test.ts` |
| `testing/mock-mouse.ts` | `packages/core/src/testing/mock-mouse.test.ts` |
| `text-buffer.ts` | `packages/core/src/text-buffer.test.ts` |

### ❌ Files Missing Tests (104)

- `3d.ts`
- `Renderable.ts`
- `ansi.ts`
- `benchmark/renderer-benchmark.ts`
- `buffer.ts`
- `console.ts`
- `examples/ascii-font-selection-demo.ts`
- `examples/assets/Water_2_M_Normal.jpg`
- `examples/assets/concrete.png`
- `examples/assets/crate.png`
- `examples/assets/crate_emissive.png`
- `examples/assets/forrest_background.png`
- `examples/assets/hast-example.json`
- `examples/assets/heart.png`
- `examples/assets/main_char_idle.png`
- `examples/assets/main_char_run_loop.png`
- `examples/assets/roughness_map.jpg`
- `examples/console-demo.ts`
- `examples/fonts.ts`
- `examples/fractal-shader-demo.ts`
- `examples/framebuffer-demo.ts`
- `examples/full-unicode-demo.ts`
- `examples/hast-syntax-highlighting-demo.ts`
- `examples/input-demo.ts`
- `examples/input-select-layout-demo.ts`
- `examples/lib/standalone-keys.ts`
- `examples/lib/tab-controller.ts`
- `examples/lights-phong-demo.ts`
- `examples/live-state-demo.ts`
- `examples/mouse-interaction-demo.ts`
- `examples/nested-zindex-demo.ts`
- `examples/opentui-demo.ts`
- `examples/physx-planck-2d-demo.ts`
- `examples/physx-rapier-2d-demo.ts`
- `examples/relative-positioning-demo.ts`
- `examples/scroll-example.ts`
- `examples/select-demo.ts`
- `examples/shader-cube-demo.ts`
- `examples/simple-layout-example.ts`
- `examples/slider-demo.ts`
- `examples/split-mode-demo.ts`
- `examples/sprite-animation-demo.ts`
- `examples/sprite-particle-generator-demo.ts`
- `examples/static-sprite-demo.ts`
- `examples/sticky-scroll-example.ts`
- `examples/styled-text-demo.ts`
- `examples/tab-select-demo.ts`
- `examples/terminal-title.ts`
- `examples/text-node-demo.ts`
- `examples/text-selection-demo.ts`
- `examples/text-wrap.ts`
- `examples/texture-loading-demo.ts`
- `examples/timeline-example.ts`
- `examples/transparency-demo.ts`
- `examples/tree-sitter-syntax-highlighting-demo.ts`
- `examples/vnode-composition-demo.ts`
- `lib/RGBA.ts`
- `lib/ascii.font.ts`
- `lib/border.ts`
- `lib/debounce.ts`
- `lib/fonts/block.json`
- `lib/fonts/shade.json`
- `lib/fonts/slick.json`
- `lib/fonts/tiny.json`
- `lib/hast-styled-text.ts`
- `lib/objects-in-viewport.ts`
- `lib/output.capture.ts`
- `lib/parse.mouse.ts`
- `lib/queue.ts`
- `lib/scroll-acceleration.ts`
- `lib/selection.ts`
- `lib/singleton.ts`
- `lib/styled-text.ts`
- `lib/tree-sitter/assets/javascript/highlights.scm`
- `lib/tree-sitter/assets/javascript/tree-sitter-javascript.wasm`
- `lib/tree-sitter/assets/typescript/highlights.scm`
- `lib/tree-sitter/assets/typescript/tree-sitter-typescript.wasm`
- `lib/tree-sitter/assets/update.ts`
- `lib/tree-sitter/default-parsers.ts`
- `lib/tree-sitter/download-utils.ts`
- `lib/tree-sitter/parser.worker.ts`
- `lib/tree-sitter/resolve-ft.ts`
- `lib/tree-sitter/types.ts`
- `lib/validate-dir-name.ts`
- `lib/yoga.options.ts`
- `post/filters.ts`
- `renderables/ASCIIFont.ts`
- `renderables/Box.ts`
- `renderables/FrameBuffer.ts`
- `renderables/ScrollBar.ts`
- `renderables/ScrollBox.ts`
- `renderables/Select.ts`
- `renderables/TabSelect.ts`
- `renderables/TextBufferRenderable.ts`
- `renderables/composition/VRenderable.ts`
- `renderables/composition/constructs.ts`
- `renderables/composition/vnode.ts`
- `renderer.ts`
- `testing.ts`
- `testing/spy.ts`
- `testing/test-renderer.ts`
- `types.ts`
- `utils.ts`
- `zig.ts`

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

- `lib/parse.keypress.ts` → `lib/parse.keypress-kitty.ts` → `lib/parse.keypress.ts`
- `buffer.ts` → `lib/index.ts` → `lib/ascii.font.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `Renderable.ts`
- `lib/styled-text.ts` → `renderables/Text.ts` → `lib/styled-text.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `Renderable.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `buffer.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `console.ts` → `buffer.ts`
- `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `console.ts` → `index.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/objects-in-viewport.ts` → `types.ts` → `Renderable.ts`
- `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/objects-in-viewport.ts` → `types.ts` → `lib/selection.ts`
- `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/selection.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/tree-sitter/index.ts` → `lib/syntax-style.ts` → `utils.ts` → `Renderable.ts`
- `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/tree-sitter/index.ts` → `lib/tree-sitter-styled-text.ts` → `lib/styled-text.ts`
- `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/tree-sitter/index.ts` → `lib/tree-sitter-styled-text.ts` → `text-buffer.ts` → `lib/styled-text.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `animation/Timeline.ts` → `renderer.ts` → `lib/tree-sitter/index.ts` → `lib/tree-sitter-styled-text.ts` → `text-buffer.ts` → `zig.ts` → `buffer.ts`
- `text-buffer.ts` → `zig.ts` → `text-buffer.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `buffer.ts`
- `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `lib/index.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `post/filters.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ASCIIFont.ts` → `Renderable.ts`
- `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ASCIIFont.ts` → `lib/selection.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ASCIIFont.ts` → `renderables/FrameBuffer.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ASCIIFont.ts` → `renderables/FrameBuffer.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Box.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Box.ts` → `buffer.ts`
- `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Box.ts` → `lib/index.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Box.ts` → `lib/renderable.validations.ts` → `Renderable.ts`
- `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Code.ts` → `lib/styled-text.ts`
- `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Code.ts` → `renderables/TextBufferRenderable.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Input.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Input.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBar.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBar.ts` → `buffer.ts`
- `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBar.ts` → `lib/index.ts`
- `index.ts` → `renderables/index.ts` → `renderables/ScrollBar.ts` → `renderables/Slider.ts` → `index.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBox.ts` → `Renderable.ts`
- `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBox.ts` → `lib/index.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/ScrollBox.ts` → `renderables/composition/vnode.ts` → `Renderable.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Select.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Select.ts` → `buffer.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/TabSelect.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/TabSelect.ts` → `buffer.ts`
- `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/Text.ts`
- `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/TextBufferRenderable.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/TextNode.ts` → `Renderable.ts`
- `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/TextNode.ts` → `lib/styled-text.ts`
- `renderables/index.ts` → `renderables/TextNode.ts` → `renderables/index.ts`
- `Renderable.ts` → `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/composition/VRenderable.ts` → `Renderable.ts`
- `buffer.ts` → `lib/index.ts` → `lib/hast-styled-text.ts` → `lib/styled-text.ts` → `renderables/Text.ts` → `renderables/TextBufferRenderable.ts` → `lib/selection.ts` → `index.ts` → `renderables/index.ts` → `renderables/composition/VRenderable.ts` → `buffer.ts`
- `renderables/index.ts` → `renderables/composition/constructs.ts` → `renderables/index.ts`

---

## Detailed File Information

<details>
<summary>Click to expand full dependency details</summary>

### `3d.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (9): `examples/fractal-shader-demo.ts`, `examples/lights-phong-demo.ts`, `examples/physx-planck-2d-demo.ts`, `examples/physx-rapier-2d-demo.ts`, `examples/shader-cube-demo.ts`, `examples/sprite-animation-demo.ts`, `examples/sprite-particle-generator-demo.ts`, `examples/static-sprite-demo.ts`, `examples/texture-loading-demo.ts`
- **Test**: ❌ Missing

### `ansi.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `lib/KeyHandler.ts`, `renderer.ts`, `testing/mock-keys.ts`
- **Test**: ❌ Missing

### `examples/assets/Water_2_M_Normal.jpg`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/lights-phong-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/concrete.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/physx-rapier-2d-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/crate.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `benchmark/renderer-benchmark.ts`, `examples/physx-planck-2d-demo.ts`, `examples/texture-loading-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/crate_emissive.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `benchmark/renderer-benchmark.ts`, `examples/texture-loading-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/forrest_background.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/sprite-particle-generator-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/hast-example.json`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/hast-syntax-highlighting-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/heart.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/sprite-particle-generator-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/main_char_idle.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `examples/sprite-animation-demo.ts`, `examples/static-sprite-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/main_char_run_loop.png`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/sprite-particle-generator-demo.ts`
- **Test**: ❌ Missing

### `examples/assets/roughness_map.jpg`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `examples/lights-phong-demo.ts`
- **Test**: ❌ Missing

### `lib/RGBA.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (22): `console.ts`, `examples/hast-syntax-highlighting-demo.ts`, `examples/lib/tab-controller.ts`, `examples/tree-sitter-syntax-highlighting-demo.ts`, `lib/ascii.font.ts`, `lib/border.ts`, `lib/index.ts`, `lib/styled-text.ts`, `lib/syntax-style.ts`, `renderables/ASCIIFont.ts`, `renderables/Box.ts`, `renderables/Input.ts`, `renderables/Select.ts`, `renderables/TabSelect.ts`, `renderables/Text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `renderables/composition/constructs.ts`, `renderer.ts`, `text-buffer.ts`, `types.ts`, `zig.ts`
- **Test**: ❌ Missing

### `lib/debounce.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `lib/fonts/block.json`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/ascii.font.ts`
- **Test**: ❌ Missing

### `lib/fonts/shade.json`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/ascii.font.ts`
- **Test**: ❌ Missing

### `lib/fonts/slick.json`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/ascii.font.ts`
- **Test**: ❌ Missing

### `lib/fonts/tiny.json`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/ascii.font.ts`
- **Test**: ❌ Missing

### `lib/output.capture.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `console.ts`
- **Test**: ❌ Missing

### `lib/parse.mouse.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `Renderable.ts`, `lib/index.ts`, `renderer.ts`
- **Test**: ❌ Missing

### `lib/queue.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `lib/scroll-acceleration.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `lib/index.ts`, `renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `lib/singleton.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (5): `console.ts`, `lib/data-paths.ts`, `lib/env.ts`, `lib/tree-sitter/index.ts`, `renderer.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/assets/javascript/highlights.scm`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/default-parsers.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/assets/javascript/tree-sitter-javascript.wasm`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/default-parsers.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/assets/typescript/highlights.scm`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/default-parsers.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/assets/typescript/tree-sitter-typescript.wasm`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/default-parsers.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/download-utils.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (2): `lib/tree-sitter/assets/update.ts`, `lib/tree-sitter/parser.worker.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/resolve-ft.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/tree-sitter/index.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/types.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (6): `lib/tree-sitter-styled-text.ts`, `lib/tree-sitter/assets/update.ts`, `lib/tree-sitter/client.ts`, `lib/tree-sitter/default-parsers.ts`, `lib/tree-sitter/index.ts`, `lib/tree-sitter/parser.worker.ts`
- **Test**: ❌ Missing

### `lib/validate-dir-name.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `lib/data-paths.ts`
- **Test**: ❌ Missing

### `lib/word-jumps.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (0): None
- **Test**: ✅ `packages/core/src/lib/word-jumps.test.ts`

### `lib/yoga.options.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (3): `Renderable.ts`, `lib/index.ts`, `lib/renderable.validations.ts`
- **Test**: ❌ Missing

### `testing/spy.ts`

- **Depth**: 0
- **Dependencies** (0): None
- **Dependents** (1): `testing.ts`
- **Test**: ❌ Missing

### `animation/Timeline.ts`

- **Depth**: 10
- **Dependencies** (1): `renderer.ts`
- **Dependents** (3): `examples/split-mode-demo.ts`, `examples/timeline-example.ts`, `index.ts`
- **Test**: ✅ `packages/core/src/animation/Timeline.test.ts`

### `examples/full-unicode-demo.ts`

- **Depth**: 13
- **Dependencies** (1): `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/lib/standalone-keys.ts`

- **Depth**: 13
- **Dependencies** (1): `index.ts`
- **Dependents** (37): `examples/ascii-font-selection-demo.ts`, `examples/console-demo.ts`, `examples/fonts.ts`, `examples/fractal-shader-demo.ts`, `examples/framebuffer-demo.ts`, `examples/hast-syntax-highlighting-demo.ts`, `examples/index.ts`, `examples/input-demo.ts`, `examples/input-select-layout-demo.ts`, `examples/lights-phong-demo.ts`, `examples/live-state-demo.ts`, `examples/mouse-interaction-demo.ts`, `examples/nested-zindex-demo.ts`, `examples/opentui-demo.ts`, `examples/physx-planck-2d-demo.ts`, `examples/physx-rapier-2d-demo.ts`, `examples/relative-positioning-demo.ts`, `examples/scroll-example.ts`, `examples/select-demo.ts`, `examples/shader-cube-demo.ts`, `examples/simple-layout-example.ts`, `examples/slider-demo.ts`, `examples/split-mode-demo.ts`, `examples/sprite-animation-demo.ts`, `examples/sprite-particle-generator-demo.ts`, `examples/static-sprite-demo.ts`, `examples/sticky-scroll-example.ts`, `examples/styled-text-demo.ts`, `examples/tab-select-demo.ts`, `examples/text-node-demo.ts`, `examples/text-selection-demo.ts`, `examples/text-wrap.ts`, `examples/texture-loading-demo.ts`, `examples/timeline-example.ts`, `examples/transparency-demo.ts`, `examples/tree-sitter-syntax-highlighting-demo.ts`, `examples/vnode-composition-demo.ts`
- **Test**: ❌ Missing

### `examples/terminal-title.ts`

- **Depth**: 13
- **Dependencies** (1): `index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `lib/border.ts`

- **Depth**: 1
- **Dependencies** (1): `lib/RGBA.ts`
- **Dependents** (1): `lib/index.ts`
- **Test**: ❌ Missing

### `lib/env.ts`

- **Depth**: 1
- **Dependencies** (1): `lib/singleton.ts`
- **Dependents** (6): `console.ts`, `lib/data-paths.ts`, `lib/index.ts`, `lib/tree-sitter/client.ts`, `renderer.ts`, `zig.ts`
- **Test**: ✅ `packages/core/src/lib/env.test.ts`

### `lib/objects-in-viewport.ts`

- **Depth**: 5
- **Dependencies** (1): `types.ts`
- **Dependents** (2): `renderables/ScrollBox.ts`, `renderer.ts`
- **Test**: ❌ Missing

### `lib/parse.keypress-kitty.ts`

- **Depth**: 1
- **Dependencies** (1): `lib/parse.keypress.ts`
- **Dependents** (1): `lib/parse.keypress.ts`
- **Test**: ✅ `packages/core/src/lib/parse.keypress-kitty.test.ts`

### `lib/parse.keypress.ts`

- **Depth**: 2
- **Dependencies** (1): `lib/parse.keypress-kitty.ts`
- **Dependents** (3): `lib/KeyHandler.ts`, `lib/index.ts`, `lib/parse.keypress-kitty.ts`
- **Test**: ✅ `packages/core/src/lib/parse.keypress.test.ts`

### `post/filters.ts`

- **Depth**: 1
- **Dependencies** (1): `buffer.ts`
- **Dependents** (2): `examples/shader-cube-demo.ts`, `index.ts`
- **Test**: ❌ Missing

### `renderables/Slider.ts`

- **Depth**: 1
- **Dependencies** (1): `index.ts`
- **Dependents** (3): `examples/slider-demo.ts`, `renderables/ScrollBar.ts`, `renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/Slider.test.ts`

### `testing/mock-mouse.ts`

- **Depth**: 10
- **Dependencies** (1): `renderer.ts`
- **Dependents** (2): `testing.ts`, `testing/test-renderer.ts`
- **Test**: ✅ `packages/core/src/testing/mock-mouse.test.ts`

### `examples/console-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/framebuffer-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/mouse-interaction-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/nested-zindex-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/relative-positioning-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/simple-layout-example.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/text-selection-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/transparency-demo.ts`

- **Depth**: 14
- **Dependencies** (2): `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `lib/KeyHandler.ts`

- **Depth**: 3
- **Dependencies** (2): `ansi.ts`, `lib/parse.keypress.ts`
- **Dependents** (8): `Renderable.ts`, `lib/index.ts`, `renderables/Input.ts`, `renderables/ScrollBar.ts`, `renderables/Select.ts`, `renderables/TabSelect.ts`, `renderer.ts`, `types.ts`
- **Test**: ✅ `packages/core/src/lib/KeyHandler.test.ts`

### `lib/renderable.validations.ts`

- **Depth**: 1
- **Dependencies** (2): `Renderable.ts`, `lib/yoga.options.ts`
- **Dependents** (2): `Renderable.ts`, `renderables/Box.ts`
- **Test**: ✅ `packages/core/src/lib/renderable.validations.test.ts`

### `lib/selection.ts`

- **Depth**: 13
- **Dependencies** (2): `index.ts`, `lib/ascii.font.ts`
- **Dependents** (6): `Renderable.ts`, `lib/index.ts`, `renderables/ASCIIFont.ts`, `renderables/TextBufferRenderable.ts`, `renderer.ts`, `types.ts`
- **Test**: ❌ Missing

### `lib/syntax-style.ts`

- **Depth**: 6
- **Dependencies** (2): `lib/RGBA.ts`, `utils.ts`
- **Dependents** (5): `lib/hast-styled-text.ts`, `lib/index.ts`, `lib/tree-sitter-styled-text.ts`, `lib/tree-sitter/index.ts`, `renderables/Code.ts`
- **Test**: ✅ `packages/core/src/lib/syntax-style.test.ts`

### `lib/tree-sitter/assets/update.ts`

- **Depth**: 1
- **Dependencies** (2): `lib/tree-sitter/download-utils.ts`, `lib/tree-sitter/types.ts`
- **Dependents** (1): `lib/tree-sitter/index.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/parser.worker.ts`

- **Depth**: 1
- **Dependencies** (2): `lib/tree-sitter/download-utils.ts`, `lib/tree-sitter/types.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `renderables/composition/vnode.ts`

- **Depth**: 5
- **Dependencies** (2): `Renderable.ts`, `types.ts`
- **Dependents** (4): `Renderable.ts`, `renderables/ScrollBox.ts`, `renderables/composition/constructs.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `testing/mock-keys.ts`

- **Depth**: 10
- **Dependencies** (2): `ansi.ts`, `renderer.ts`
- **Dependents** (2): `testing.ts`, `testing/test-renderer.ts`
- **Test**: ✅ `packages/core/src/testing/mock-keys.test.ts`

### `utils.ts`

- **Depth**: 5
- **Dependencies** (2): `Renderable.ts`, `types.ts`
- **Dependents** (4): `index.ts`, `lib/styled-text.ts`, `lib/syntax-style.ts`, `lib/tree-sitter-styled-text.ts`
- **Test**: ❌ Missing

### `benchmark/renderer-benchmark.ts`

- **Depth**: 13
- **Dependencies** (3): `examples/assets/crate.png`, `examples/assets/crate_emissive.png`, `index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `examples/ascii-font-selection-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/ASCIIFont.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/fonts.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `lib/ascii.font.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/fractal-shader-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `3d.ts`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/input-demo.ts`

- **Depth**: 16
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Text.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/live-state-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Box.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/opentui-demo.ts`

- **Depth**: 22
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `examples/lib/tab-controller.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/scroll-example.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/ScrollBox.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/select-demo.ts`

- **Depth**: 16
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Text.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/slider-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Slider.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `examples/split-mode-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `animation/Timeline.ts`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/sticky-scroll-example.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/ScrollBox.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/styled-text-demo.ts`

- **Depth**: 16
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Text.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/tab-select-demo.ts`

- **Depth**: 16
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Text.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/text-node-demo.ts`

- **Depth**: 14
- **Dependencies** (3): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/TextNode.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/timeline-example.ts`

- **Depth**: 14
- **Dependencies** (3): `animation/Timeline.ts`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `lib/data-paths.ts`

- **Depth**: 2
- **Dependencies** (3): `lib/env.ts`, `lib/singleton.ts`, `lib/validate-dir-name.ts`
- **Dependents** (2): `lib/index.ts`, `lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/data-paths.test.ts`

### `lib/hast-styled-text.ts`

- **Depth**: 17
- **Dependencies** (3): `lib/styled-text.ts`, `lib/syntax-style.ts`, `text-buffer.ts`
- **Dependents** (2): `examples/hast-syntax-highlighting-demo.ts`, `lib/index.ts`
- **Test**: ❌ Missing

### `renderables/FrameBuffer.ts`

- **Depth**: 5
- **Dependencies** (3): `Renderable.ts`, `buffer.ts`, `types.ts`
- **Dependents** (2): `renderables/ASCIIFont.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/composition/VRenderable.ts`

- **Depth**: 5
- **Dependencies** (3): `Renderable.ts`, `buffer.ts`, `types.ts`
- **Dependents** (1): `renderables/index.ts`
- **Test**: ❌ Missing

### `buffer.ts`

- **Depth**: 19
- **Dependencies** (4): `lib/index.ts`, `text-buffer.ts`, `types.ts`, `zig.ts`
- **Dependents** (18): `Renderable.ts`, `console.ts`, `examples/lib/tab-controller.ts`, `examples/shader-cube-demo.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `lib/ascii.font.ts`, `post/filters.ts`, `renderables/Box.ts`, `renderables/FrameBuffer.ts`, `renderables/Input.ts`, `renderables/ScrollBar.ts`, `renderables/Select.ts`, `renderables/TabSelect.ts`, `renderables/TextBufferRenderable.ts`, `renderables/composition/VRenderable.ts`, `renderer.ts`, `zig.ts`
- **Test**: ❌ Missing

### `examples/input-select-layout-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/Input.ts`, `renderables/Select.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/physx-planck-2d-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `3d.ts`, `examples/assets/crate.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/physx-rapier-2d-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `3d.ts`, `examples/assets/concrete.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/sprite-animation-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `3d.ts`, `examples/assets/main_char_idle.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/static-sprite-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `3d.ts`, `examples/assets/main_char_idle.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/text-wrap.ts`

- **Depth**: 14
- **Dependencies** (4): `examples/lib/standalone-keys.ts`, `index.ts`, `renderables/ScrollBox.ts`, `renderables/TextNode.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/tree-sitter-syntax-highlighting-demo.ts`

- **Depth**: 14
- **Dependencies** (4): `examples/lib/standalone-keys.ts`, `index.ts`, `lib/RGBA.ts`, `lib/tree-sitter/index.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `lib/styled-text.ts`

- **Depth**: 16
- **Dependencies** (4): `lib/RGBA.ts`, `renderables/Text.ts`, `text-buffer.ts`, `utils.ts`
- **Dependents** (7): `lib/hast-styled-text.ts`, `lib/index.ts`, `lib/tree-sitter-styled-text.ts`, `renderables/Code.ts`, `renderables/Text.ts`, `renderables/TextNode.ts`, `text-buffer.ts`
- **Test**: ❌ Missing

### `testing.ts`

- **Depth**: 12
- **Dependencies** (4): `testing/mock-keys.ts`, `testing/mock-mouse.ts`, `testing/spy.ts`, `testing/test-renderer.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

### `testing/test-renderer.ts`

- **Depth**: 11
- **Dependencies** (4): `renderer.ts`, `testing/mock-keys.ts`, `testing/mock-mouse.ts`, `zig.ts`
- **Dependents** (1): `testing.ts`
- **Test**: ❌ Missing

### `text-buffer.ts`

- **Depth**: 6
- **Dependencies** (4): `lib/RGBA.ts`, `lib/styled-text.ts`, `types.ts`, `zig.ts`
- **Dependents** (9): `buffer.ts`, `index.ts`, `lib/hast-styled-text.ts`, `lib/styled-text.ts`, `lib/tree-sitter-styled-text.ts`, `renderables/Text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `zig.ts`
- **Test**: ✅ `packages/core/src/text-buffer.test.ts`

### `types.ts`

- **Depth**: 4
- **Dependencies** (4): `Renderable.ts`, `lib/KeyHandler.ts`, `lib/RGBA.ts`, `lib/selection.ts`
- **Dependents** (24): `Renderable.ts`, `buffer.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `lib/objects-in-viewport.ts`, `renderables/ASCIIFont.ts`, `renderables/Box.ts`, `renderables/Code.ts`, `renderables/FrameBuffer.ts`, `renderables/Input.ts`, `renderables/ScrollBar.ts`, `renderables/ScrollBox.ts`, `renderables/Select.ts`, `renderables/TabSelect.ts`, `renderables/Text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `renderables/composition/VRenderable.ts`, `renderables/composition/constructs.ts`, `renderables/composition/vnode.ts`, `renderer.ts`, `text-buffer.ts`, `utils.ts`, `zig.ts`
- **Test**: ❌ Missing

### `examples/hast-syntax-highlighting-demo.ts`

- **Depth**: 18
- **Dependencies** (5): `examples/assets/hast-example.json`, `examples/lib/standalone-keys.ts`, `index.ts`, `lib/RGBA.ts`, `lib/hast-styled-text.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/lights-phong-demo.ts`

- **Depth**: 14
- **Dependencies** (5): `3d.ts`, `examples/assets/Water_2_M_Normal.jpg`, `examples/assets/roughness_map.jpg`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/texture-loading-demo.ts`

- **Depth**: 14
- **Dependencies** (5): `3d.ts`, `examples/assets/crate.png`, `examples/assets/crate_emissive.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/client.ts`

- **Depth**: 2
- **Dependencies** (5): `lib/debounce.ts`, `lib/env.ts`, `lib/queue.ts`, `lib/tree-sitter/default-parsers.ts`, `lib/tree-sitter/types.ts`
- **Dependents** (2): `lib/tree-sitter-styled-text.ts`, `lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/tree-sitter/client.test.ts`

### `lib/tree-sitter/default-parsers.ts`

- **Depth**: 1
- **Dependencies** (5): `lib/tree-sitter/assets/javascript/highlights.scm`, `lib/tree-sitter/assets/javascript/tree-sitter-javascript.wasm`, `lib/tree-sitter/assets/typescript/highlights.scm`, `lib/tree-sitter/assets/typescript/tree-sitter-typescript.wasm`, `lib/tree-sitter/types.ts`
- **Dependents** (1): `lib/tree-sitter/client.ts`
- **Test**: ❌ Missing

### `renderables/Code.ts`

- **Depth**: 9
- **Dependencies** (5): `lib/styled-text.ts`, `lib/syntax-style.ts`, `lib/tree-sitter/index.ts`, `renderables/TextBufferRenderable.ts`, `types.ts`
- **Dependents** (1): `renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/Code.test.ts`

### `renderables/Input.ts`

- **Depth**: 5
- **Dependencies** (5): `Renderable.ts`, `buffer.ts`, `lib/KeyHandler.ts`, `lib/RGBA.ts`, `types.ts`
- **Dependents** (2): `examples/input-select-layout-demo.ts`, `renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/Input.test.ts`

### `renderables/TabSelect.ts`

- **Depth**: 5
- **Dependencies** (5): `Renderable.ts`, `buffer.ts`, `lib/KeyHandler.ts`, `lib/RGBA.ts`, `types.ts`
- **Dependents** (2): `examples/lib/tab-controller.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/composition/constructs.ts`

- **Depth**: 8
- **Dependencies** (5): `lib/RGBA.ts`, `renderables/TextNode.ts`, `renderables/composition/vnode.ts`, `renderables/index.ts`, `types.ts`
- **Dependents** (1): `renderables/index.ts`
- **Test**: ❌ Missing

### `zig.ts`

- **Depth**: 5
- **Dependencies** (5): `buffer.ts`, `lib/RGBA.ts`, `lib/env.ts`, `text-buffer.ts`, `types.ts`
- **Dependents** (6): `buffer.ts`, `index.ts`, `renderables/TextBufferRenderable.ts`, `renderer.ts`, `testing/test-renderer.ts`, `text-buffer.ts`
- **Test**: ❌ Missing

### `console.ts`

- **Depth**: 2
- **Dependencies** (6): `buffer.ts`, `index.ts`, `lib/RGBA.ts`, `lib/env.ts`, `lib/output.capture.ts`, `lib/singleton.ts`
- **Dependents** (2): `index.ts`, `renderer.ts`
- **Test**: ❌ Missing

### `examples/lib/tab-controller.ts`

- **Depth**: 21
- **Dependencies** (6): `Renderable.ts`, `buffer.ts`, `index.ts`, `lib/RGBA.ts`, `renderables/TabSelect.ts`, `renderables/index.ts`
- **Dependents** (1): `examples/opentui-demo.ts`
- **Test**: ❌ Missing

### `examples/shader-cube-demo.ts`

- **Depth**: 20
- **Dependencies** (6): `3d.ts`, `buffer.ts`, `examples/lib/standalone-keys.ts`, `index.ts`, `lib/index.ts`, `post/filters.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `examples/sprite-particle-generator-demo.ts`

- **Depth**: 14
- **Dependencies** (6): `3d.ts`, `examples/assets/forrest_background.png`, `examples/assets/heart.png`, `examples/assets/main_char_run_loop.png`, `examples/lib/standalone-keys.ts`, `index.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `lib/ascii.font.ts`

- **Depth**: 1
- **Dependencies** (6): `buffer.ts`, `lib/RGBA.ts`, `lib/fonts/block.json`, `lib/fonts/shade.json`, `lib/fonts/slick.json`, `lib/fonts/tiny.json`
- **Dependents** (6): `examples/fonts.ts`, `examples/index.ts`, `lib/index.ts`, `lib/selection.ts`, `renderables/ASCIIFont.ts`, `renderables/Select.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter-styled-text.ts`

- **Depth**: 7
- **Dependencies** (6): `lib/styled-text.ts`, `lib/syntax-style.ts`, `lib/tree-sitter/client.ts`, `lib/tree-sitter/types.ts`, `text-buffer.ts`, `utils.ts`
- **Dependents** (2): `lib/index.ts`, `lib/tree-sitter/index.ts`
- **Test**: ✅ `packages/core/src/lib/tree-sitter-styled-text.test.ts`

### `renderables/ASCIIFont.ts`

- **Depth**: 6
- **Dependencies** (6): `Renderable.ts`, `lib/RGBA.ts`, `lib/ascii.font.ts`, `lib/selection.ts`, `renderables/FrameBuffer.ts`, `types.ts`
- **Dependents** (2): `examples/ascii-font-selection-demo.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/Box.ts`

- **Depth**: 5
- **Dependencies** (6): `Renderable.ts`, `buffer.ts`, `lib/RGBA.ts`, `lib/index.ts`, `lib/renderable.validations.ts`, `types.ts`
- **Dependents** (4): `examples/live-state-demo.ts`, `renderables/ScrollBar.ts`, `renderables/ScrollBox.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/Select.ts`

- **Depth**: 5
- **Dependencies** (6): `Renderable.ts`, `buffer.ts`, `lib/KeyHandler.ts`, `lib/RGBA.ts`, `lib/ascii.font.ts`, `types.ts`
- **Dependents** (2): `examples/input-select-layout-demo.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/TextNode.ts`

- **Depth**: 7
- **Dependencies** (6): `Renderable.ts`, `lib/RGBA.ts`, `lib/styled-text.ts`, `renderables/index.ts`, `text-buffer.ts`, `types.ts`
- **Dependents** (5): `examples/text-node-demo.ts`, `examples/text-wrap.ts`, `renderables/Text.ts`, `renderables/composition/constructs.ts`, `renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/TextNode.test.ts`

### `examples/vnode-composition-demo.ts`

- **Depth**: 21
- **Dependencies** (7): `Renderable.ts`, `buffer.ts`, `examples/lib/standalone-keys.ts`, `lib/index.ts`, `renderables/index.ts`, `renderer.ts`, `types.ts`
- **Dependents** (1): `examples/index.ts`
- **Test**: ❌ Missing

### `renderables/ScrollBar.ts`

- **Depth**: 6
- **Dependencies** (7): `Renderable.ts`, `buffer.ts`, `lib/KeyHandler.ts`, `lib/index.ts`, `renderables/Box.ts`, `renderables/Slider.ts`, `types.ts`
- **Dependents** (2): `renderables/ScrollBox.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `renderables/Text.ts`

- **Depth**: 15
- **Dependencies** (7): `Renderable.ts`, `lib/RGBA.ts`, `lib/styled-text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `text-buffer.ts`, `types.ts`
- **Dependents** (6): `examples/input-demo.ts`, `examples/select-demo.ts`, `examples/styled-text-demo.ts`, `examples/tab-select-demo.ts`, `lib/styled-text.ts`, `renderables/index.ts`
- **Test**: ✅ `packages/core/src/renderables/Text.test.ts`

### `renderables/TextBufferRenderable.ts`

- **Depth**: 14
- **Dependencies** (7): `Renderable.ts`, `buffer.ts`, `lib/RGBA.ts`, `lib/selection.ts`, `text-buffer.ts`, `types.ts`, `zig.ts`
- **Dependents** (3): `renderables/Code.ts`, `renderables/Text.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `lib/tree-sitter/index.ts`

- **Depth**: 8
- **Dependencies** (8): `lib/data-paths.ts`, `lib/singleton.ts`, `lib/syntax-style.ts`, `lib/tree-sitter-styled-text.ts`, `lib/tree-sitter/assets/update.ts`, `lib/tree-sitter/client.ts`, `lib/tree-sitter/resolve-ft.ts`, `lib/tree-sitter/types.ts`
- **Dependents** (4): `examples/tree-sitter-syntax-highlighting-demo.ts`, `lib/index.ts`, `renderables/Code.ts`, `renderer.ts`
- **Test**: ❌ Missing

### `Renderable.ts`

- **Depth**: 20
- **Dependencies** (9): `buffer.ts`, `lib/KeyHandler.ts`, `lib/parse.mouse.ts`, `lib/renderable.validations.ts`, `lib/selection.ts`, `lib/yoga.options.ts`, `renderables/composition/vnode.ts`, `renderer.ts`, `types.ts`
- **Dependents** (20): `examples/lib/tab-controller.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `lib/renderable.validations.ts`, `renderables/ASCIIFont.ts`, `renderables/Box.ts`, `renderables/FrameBuffer.ts`, `renderables/Input.ts`, `renderables/ScrollBar.ts`, `renderables/ScrollBox.ts`, `renderables/Select.ts`, `renderables/TabSelect.ts`, `renderables/Text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `renderables/composition/VRenderable.ts`, `renderables/composition/vnode.ts`, `renderer.ts`, `types.ts`, `utils.ts`
- **Test**: ❌ Missing

### `renderables/ScrollBox.ts`

- **Depth**: 10
- **Dependencies** (9): `Renderable.ts`, `lib/index.ts`, `lib/objects-in-viewport.ts`, `lib/scroll-acceleration.ts`, `renderables/Box.ts`, `renderables/ScrollBar.ts`, `renderables/composition/vnode.ts`, `renderer.ts`, `types.ts`
- **Dependents** (4): `examples/scroll-example.ts`, `examples/sticky-scroll-example.ts`, `examples/text-wrap.ts`, `renderables/index.ts`
- **Test**: ❌ Missing

### `index.ts`

- **Depth**: 12
- **Dependencies** (12): `Renderable.ts`, `animation/Timeline.ts`, `buffer.ts`, `console.ts`, `lib/index.ts`, `post/filters.ts`, `renderables/index.ts`, `renderer.ts`, `text-buffer.ts`, `types.ts`, `utils.ts`, `zig.ts`
- **Dependents** (44): `benchmark/renderer-benchmark.ts`, `console.ts`, `examples/ascii-font-selection-demo.ts`, `examples/console-demo.ts`, `examples/fonts.ts`, `examples/fractal-shader-demo.ts`, `examples/framebuffer-demo.ts`, `examples/full-unicode-demo.ts`, `examples/hast-syntax-highlighting-demo.ts`, `examples/index.ts`, `examples/input-demo.ts`, `examples/input-select-layout-demo.ts`, `examples/lib/standalone-keys.ts`, `examples/lib/tab-controller.ts`, `examples/lights-phong-demo.ts`, `examples/live-state-demo.ts`, `examples/mouse-interaction-demo.ts`, `examples/nested-zindex-demo.ts`, `examples/opentui-demo.ts`, `examples/physx-planck-2d-demo.ts`, `examples/physx-rapier-2d-demo.ts`, `examples/relative-positioning-demo.ts`, `examples/scroll-example.ts`, `examples/select-demo.ts`, `examples/shader-cube-demo.ts`, `examples/simple-layout-example.ts`, `examples/slider-demo.ts`, `examples/split-mode-demo.ts`, `examples/sprite-animation-demo.ts`, `examples/sprite-particle-generator-demo.ts`, `examples/static-sprite-demo.ts`, `examples/sticky-scroll-example.ts`, `examples/styled-text-demo.ts`, `examples/tab-select-demo.ts`, `examples/terminal-title.ts`, `examples/text-node-demo.ts`, `examples/text-selection-demo.ts`, `examples/text-wrap.ts`, `examples/texture-loading-demo.ts`, `examples/timeline-example.ts`, `examples/transparency-demo.ts`, `examples/tree-sitter-syntax-highlighting-demo.ts`, `lib/selection.ts`, `renderables/Slider.ts`
- **Test**: ❌ Missing

### `renderer.ts`

- **Depth**: 9
- **Dependencies** (14): `Renderable.ts`, `ansi.ts`, `buffer.ts`, `console.ts`, `lib/KeyHandler.ts`, `lib/RGBA.ts`, `lib/env.ts`, `lib/objects-in-viewport.ts`, `lib/parse.mouse.ts`, `lib/selection.ts`, `lib/singleton.ts`, `lib/tree-sitter/index.ts`, `types.ts`, `zig.ts`
- **Dependents** (8): `Renderable.ts`, `animation/Timeline.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `renderables/ScrollBox.ts`, `testing/mock-keys.ts`, `testing/mock-mouse.ts`, `testing/test-renderer.ts`
- **Test**: ❌ Missing

### `lib/index.ts`

- **Depth**: 18
- **Dependencies** (16): `lib/KeyHandler.ts`, `lib/RGBA.ts`, `lib/ascii.font.ts`, `lib/border.ts`, `lib/data-paths.ts`, `lib/env.ts`, `lib/hast-styled-text.ts`, `lib/parse.keypress.ts`, `lib/parse.mouse.ts`, `lib/scroll-acceleration.ts`, `lib/selection.ts`, `lib/styled-text.ts`, `lib/syntax-style.ts`, `lib/tree-sitter-styled-text.ts`, `lib/tree-sitter/index.ts`, `lib/yoga.options.ts`
- **Dependents** (7): `buffer.ts`, `examples/shader-cube-demo.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `renderables/Box.ts`, `renderables/ScrollBar.ts`, `renderables/ScrollBox.ts`
- **Test**: ❌ Missing

### `renderables/index.ts`

- **Depth**: 11
- **Dependencies** (16): `renderables/ASCIIFont.ts`, `renderables/Box.ts`, `renderables/Code.ts`, `renderables/FrameBuffer.ts`, `renderables/Input.ts`, `renderables/ScrollBar.ts`, `renderables/ScrollBox.ts`, `renderables/Select.ts`, `renderables/Slider.ts`, `renderables/TabSelect.ts`, `renderables/Text.ts`, `renderables/TextBufferRenderable.ts`, `renderables/TextNode.ts`, `renderables/composition/VRenderable.ts`, `renderables/composition/constructs.ts`, `renderables/composition/vnode.ts`
- **Dependents** (5): `examples/lib/tab-controller.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `renderables/TextNode.ts`, `renderables/composition/constructs.ts`
- **Test**: ❌ Missing

### `examples/index.ts`

- **Depth**: 23
- **Dependencies** (38): `examples/ascii-font-selection-demo.ts`, `examples/console-demo.ts`, `examples/fonts.ts`, `examples/fractal-shader-demo.ts`, `examples/framebuffer-demo.ts`, `examples/full-unicode-demo.ts`, `examples/hast-syntax-highlighting-demo.ts`, `examples/input-demo.ts`, `examples/input-select-layout-demo.ts`, `examples/lib/standalone-keys.ts`, `examples/lights-phong-demo.ts`, `examples/live-state-demo.ts`, `examples/mouse-interaction-demo.ts`, `examples/nested-zindex-demo.ts`, `examples/opentui-demo.ts`, `examples/physx-planck-2d-demo.ts`, `examples/physx-rapier-2d-demo.ts`, `examples/relative-positioning-demo.ts`, `examples/scroll-example.ts`, `examples/select-demo.ts`, `examples/shader-cube-demo.ts`, `examples/simple-layout-example.ts`, `examples/split-mode-demo.ts`, `examples/sprite-animation-demo.ts`, `examples/sprite-particle-generator-demo.ts`, `examples/static-sprite-demo.ts`, `examples/sticky-scroll-example.ts`, `examples/styled-text-demo.ts`, `examples/tab-select-demo.ts`, `examples/text-node-demo.ts`, `examples/text-selection-demo.ts`, `examples/text-wrap.ts`, `examples/texture-loading-demo.ts`, `examples/timeline-example.ts`, `examples/transparency-demo.ts`, `examples/vnode-composition-demo.ts`, `index.ts`, `lib/ascii.font.ts`
- **Dependents** (0): None
- **Test**: ❌ Missing

</details>
