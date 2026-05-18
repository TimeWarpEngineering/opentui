# Convert renderables/Slider.ts to C#

## Overview

- **Repo**: `/home/steventcramer/worktrees/github.com/TimeWarpEngineering/opentui/Cramer-2025-11-21-dev`
- **Source**: `packages/core/src/renderables/Slider.ts`
- **Target**: `source/timewarp-tui-core/renderables/slider.cs`
- **Phase**: 1
- **Test Coverage**: ✅ `packages/core/src/renderables/Slider.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/index.ts` _(not convertible)_

## Dependents (blocked until this is done)

- `packages/core/src/renderables/ScrollBar.ts`

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/renderables-slider-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/renderables-slider-depth-2.svg)

## Tests

### Class: Tests

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `SliderRenderable > Value-based API` | `Sliderrenderable_>_Value-based_Api` |
| `SliderRenderable > Automatic thumb size calculation` | `Sliderrenderable_>_Automatic_Thumb_Size_Calculation` |
| `SliderRenderable > Custom step size` | `Sliderrenderable_>_Custom_Step_Size` |
| `SliderRenderable > Minimum thumb size` | `Sliderrenderable_>_Minimum_Thumb_Size` |
| `SliderRenderable > onChange callback` | `Sliderrenderable_>_Onchange_Callback` |
| `SliderRenderable > Vertical thumb size calculation` | `Sliderrenderable_>_Vertical_Thumb_Size_Calculation` |
| `SliderRenderable > Horizontal thumb size calculation` | `Sliderrenderable_>_Horizontal_Thumb_Size_Calculation` |
| `SliderRenderable > Edge cases in thumb size calculation` | `Sliderrenderable_>_Edge_Cases_In_Thumb_Size_Calculation` |
| `SliderRenderable > Thumb size minimum clamping` | `Sliderrenderable_>_Thumb_Size_Minimum_Clamping` |
| `SliderRenderable > Thumb size can be less than 2` | `Sliderrenderable_>_Thumb_Size_Can_Be_Less_Than_2` |
| `SliderRenderable > Mouse interaction - horizontal click on thumb` | `Sliderrenderable_>_Mouse_Interaction_-_Horizontal_Click_On_Thumb` |
| `SliderRenderable > Mouse interaction - horizontal click on track` | `Sliderrenderable_>_Mouse_Interaction_-_Horizontal_Click_On_Track` |
| `SliderRenderable > Mouse interaction - vertical click on thumb` | `Sliderrenderable_>_Mouse_Interaction_-_Vertical_Click_On_Thumb` |
| `SliderRenderable > Mouse interaction - vertical click on track` | `Sliderrenderable_>_Mouse_Interaction_-_Vertical_Click_On_Track` |
| `SliderRenderable > Mouse interaction - horizontal drag` | `Sliderrenderable_>_Mouse_Interaction_-_Horizontal_Drag` |
| `SliderRenderable > Mouse interaction - vertical drag` | `Sliderrenderable_>_Mouse_Interaction_-_Vertical_Drag` |
| `SliderRenderable > Mouse interaction - drag with onChange callback` | `Sliderrenderable_>_Mouse_Interaction_-_Drag_With_Onchange_Callback` |
| `SliderRenderable > Mouse interaction - drag beyond bounds` | `Sliderrenderable_>_Mouse_Interaction_-_Drag_Beyond_Bounds` |
| `SliderRenderable > Mouse interaction - click outside slider bounds` | `Sliderrenderable_>_Mouse_Interaction_-_Click_Outside_Slider_Bounds` |
| `SliderRenderable > Mouse interaction - precision dragging with small viewport` | `Sliderrenderable_>_Mouse_Interaction_-_Precision_Dragging_With_Small_Viewport` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/renderables/Slider.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "Tests.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
