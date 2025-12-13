# Convert animation/Timeline.ts to C#

## Overview

- **Source**: `packages/core/src/animation/Timeline.ts`
- **Phase**: 19
- **Test Coverage**: ✅ `packages/core/src/animation/Timeline.test.ts`

## Dependencies (convert these first)

- [ ] `packages/core/src/renderer.ts` → [task](./258-convert-renderer.md)

## Dependents (blocked until this is done)

_None - no files depend on this_

## Dependency Graphs

- [Depth 1 - Direct](../../scripts/dependency-graphs/animation-timeline-depth-1.svg)
- [Depth 2 - Extended](../../scripts/dependency-graphs/animation-timeline-depth-2.svg)

## Tests

### Class: BasicAnimation

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should animate a single property` | `Should_Animate_A_Single_Property` |
| `should animate multiple properties` | `Should_Animate_Multiple_Properties` |
| `should handle easing functions` | `Should_Handle_Easing_Functions` |

### Class: TimelineControl

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should start paused when autoplay is false` | `Should_Start_Paused_When_Autoplay_Is_False` |
| `should animate when played` | `Should_Animate_When_Played` |
| `should pause animation` | `Should_Pause_Animation` |
| `should restart animation` | `Should_Restart_Animation` |
| `should play again when calling play() on a finished non-looping timeline` | `Should_Play_Again_When_Calling_Play()_On_A_Finished_Non-looping_Timeline` |
| `should call onPause callback when timeline is paused` | `Should_Call_Onpause_Callback_When_Timeline_Is_Paused` |
| `should not call onPause callback when timeline is not initialized with one` | `Should_Not_Call_Onpause_Callback_When_Timeline_Is_Not_Initialized_With_One` |
| `should not call onPause callback when timeline completes naturally` | `Should_Not_Call_Onpause_Callback_When_Timeline_Completes_Naturally` |

### Class: Looping

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should loop timeline when loop is true` | `Should_Loop_Timeline_When_Loop_Is_True` |
| `should not loop when loop is false` | `Should_Not_Loop_When_Loop_Is_False` |

### Class: IndividualAnimationLoops

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should loop individual animation specified number of times` | `Should_Loop_Individual_Animation_Specified_Number_Of_Times` |
| `should handle loop delay` | `Should_Handle_Loop_Delay` |

### Class: AlternatingAnimations

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should alternate direction with each loop` | `Should_Alternate_Direction_With_Each_Loop` |
| `should handle alternating with loop delay` | `Should_Handle_Alternating_With_Loop_Delay` |
| `should handle alternating animations with looping parent timeline` | `Should_Handle_Alternating_Animations_With_Looping_Parent_Timeline` |

### Class: TimelineSync

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should sync sub-timelines to main timeline` | `Should_Sync_Sub-timelines_To_Main_Timeline` |
| `should restart completed sub-timelines when main timeline loops` | `Should_Restart_Completed_Sub-timelines_When_Main_Timeline_Loops` |
| `should preserve initial values for looping sub-timeline when main timeline does not loop` | `Should_Preserve_Initial_Values_For_Looping_Sub-timeline_When_Main_Timeline_Does_Not_Loop` |
| `should pause sub-timelines when main timeline is paused` | `Should_Pause_Sub-timelines_When_Main_Timeline_Is_Paused` |

### Class: Callbacks

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should execute call callbacks at specified times` | `Should_Execute_Call_Callbacks_At_Specified_Times` |
| `should support string startTime parameters` | `Should_Support_String_Starttime_Parameters` |
| `should trigger onStart callback correctly` | `Should_Trigger_Onstart_Callback_Correctly` |
| `should trigger onLoop callback correctly for individual animation loops` | `Should_Trigger_Onloop_Callback_Correctly_For_Individual_Animation_Loops` |

### Class: ComplexLoopingScenarios

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should correctly reset and re-run finite-looped animation when parent timeline loops` | `Should_Correctly_Reset_And_Re-run_Finite-looped_Animation_When_Parent_Timeline_Loops` |

### Class: TimingPrecision

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should account for overshoot when animation starts late` | `Should_Account_For_Overshoot_When_Animation_Starts_Late` |
| `should handle multiple animations with different start time overshoots` | `Should_Handle_Multiple_Animations_With_Different_Start_Time_Overshoots` |
| `should handle zero duration animations with overshoot` | `Should_Handle_Zero_Duration_Animations_With_Overshoot` |
| `should account for overshoot in loop delays` | `Should_Account_For_Overshoot_In_Loop_Delays` |
| `should handle multiple loop delay overshoots` | `Should_Handle_Multiple_Loop_Delay_Overshoots` |
| `should handle alternating animations with loop delay overshoot` | `Should_Handle_Alternating_Animations_With_Loop_Delay_Overshoot` |
| `should account for overshoot when starting synced timelines` | `Should_Account_For_Overshoot_When_Starting_Synced_Timelines` |
| `should handle multiple synced timelines with different overshoot amounts` | `Should_Handle_Multiple_Synced_Timelines_With_Different_Overshoot_Amounts` |
| `should handle alternating animation with main timeline loop and overshoot` | `Should_Handle_Alternating_Animation_With_Main_Timeline_Loop_And_Overshoot` |
| `should maintain precision across multiple frame updates at 30fps` | `Should_Maintain_Precision_Across_Multiple_Frame_Updates_At_30fps` |

### Class: AnimationStartTimeOvershoot

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should account for overshoot when animation starts late` | `Should_Account_For_Overshoot_When_Animation_Starts_Late` |
| `should handle multiple animations with different start time overshoots` | `Should_Handle_Multiple_Animations_With_Different_Start_Time_Overshoots` |
| `should handle zero duration animations with overshoot` | `Should_Handle_Zero_Duration_Animations_With_Overshoot` |

### Class: LoopDelayPrecision

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should account for overshoot in loop delays` | `Should_Account_For_Overshoot_In_Loop_Delays` |
| `should handle multiple loop delay overshoots` | `Should_Handle_Multiple_Loop_Delay_Overshoots` |
| `should handle alternating animations with loop delay overshoot` | `Should_Handle_Alternating_Animations_With_Loop_Delay_Overshoot` |

### Class: SyncedTimelinePrecision

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should account for overshoot when starting synced timelines` | `Should_Account_For_Overshoot_When_Starting_Synced_Timelines` |
| `should handle multiple synced timelines with different overshoot amounts` | `Should_Handle_Multiple_Synced_Timelines_With_Different_Overshoot_Amounts` |

### Class: ComplexPrecisionScenarios

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle alternating animation with main timeline loop and overshoot` | `Should_Handle_Alternating_Animation_With_Main_Timeline_Loop_And_Overshoot` |
| `should maintain precision across multiple frame updates at 30fps` | `Should_Maintain_Precision_Across_Multiple_Frame_Updates_At_30fps` |

### Class: EdgeCases

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle zero duration` | `Should_Handle_Zero_Duration` |
| `should handle negative deltaTime gracefully` | `Should_Handle_Negative_Deltatime_Gracefully` |
| `should handle very large deltaTime` | `Should_Handle_Very_Large_Deltatime` |

### Class: NewEasingFunctionTests

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should animate correctly with ${tc.name} easing` | `Should_Animate_Correctly_With_${tc.name}_Easing` |

### Class: DeltaTimeInOnUpdateCallbacks

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should provide correct deltaTime to onUpdate callbacks` | `Should_Provide_Correct_Deltatime_To_Onupdate_Callbacks` |
| `should support throttling patterns like the vignette example` | `Should_Support_Throttling_Patterns_Like_The_Vignette_Example` |
| `should provide deltaTime across multiple animation loops` | `Should_Provide_Deltatime_Across_Multiple_Animation_Loops` |
| `should provide deltaTime to synced sub-timeline animations` | `Should_Provide_Deltatime_To_Synced_Sub-timeline_Animations` |
| `should handle deltaTime correctly when animation starts mid-frame` | `Should_Handle_Deltatime_Correctly_When_Animation_Starts_Mid-frame` |
| `should provide correct deltaTime for zero duration animations` | `Should_Provide_Correct_Deltatime_For_Zero_Duration_Animations` |
| `should provide consistent deltaTime during alternating animations` | `Should_Provide_Consistent_Deltatime_During_Alternating_Animations` |

### Class: OnUpdateCallbackFrequencyAndCorrectness

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should provide correct progress values in onUpdate callbacks` | `Should_Provide_Correct_Progress_Values_In_Onupdate_Callbacks` |
| `should call onUpdate for each animation in a looping scenario without duplicates` | `Should_Call_Onupdate_For_Each_Animation_In_A_Looping_Scenario_Without_Duplicates` |
| `should call onUpdate correctly for alternating animations` | `Should_Call_Onupdate_Correctly_For_Alternating_Animations` |
| `should provide correct deltaTime and timing information in onUpdate` | `Should_Provide_Correct_Deltatime_And_Timing_Information_In_Onupdate` |
| `should not call onUpdate multiple times for zero duration animations` | `Should_Not_Call_Onupdate_Multiple_Times_For_Zero_Duration_Animations` |
| `should not call onUpdate after animation completes` | `Should_Not_Call_Onupdate_After_Animation_Completes` |
| `should call onUpdate for multiple targets on same animation correctly` | `Should_Call_Onupdate_For_Multiple_Targets_On_Same_Animation_Correctly` |

### Class: TargetValuePersistenceBug

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should not reset target values to initial values when animation hasnt started` | `Should_Not_Reset_Target_Values_To_Initial_Values_When_Animation_Hasnt_Started` |
| `should not reset target values to initial values after onUpdate` | `Should_Not_Reset_Target_Values_To_Initial_Values_After_Onupdate` |
| `should preserve final values across timeline loops` | `Should_Preserve_Final_Values_Across_Timeline_Loops` |
| `should preserve original initial values across timeline loops` | `Should_Preserve_Original_Initial_Values_Across_Timeline_Loops` |

### Class: MultipleAnimationsOnSameObject

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should handle multiple animations on the same object` | `Should_Handle_Multiple_Animations_On_The_Same_Object` |
| `should handle multiple sequential animations on the same object` | `Should_Handle_Multiple_Sequential_Animations_On_The_Same_Object` |
| `should handle overlapping animations on different properties` | `Should_Handle_Overlapping_Animations_On_Different_Properties` |
| `should handle multiple animations with different easing functions` | `Should_Handle_Multiple_Animations_With_Different_Easing_Functions` |

### Class: JSAnimationTargetsArrayHandling

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should provide single target as targets[0] in onUpdate callback` | `Should_Provide_Single_Target_As_Targets[0]_In_Onupdate_Callback` |
| `should provide multiple targets correctly in targets array` | `Should_Provide_Multiple_Targets_Correctly_In_Targets_Array` |
| `should provide targets with complex object properties` | `Should_Provide_Targets_With_Complex_Object_Properties` |
| `should maintain targets array consistency with different animation properties` | `Should_Maintain_Targets_Array_Consistency_With_Different_Animation_Properties` |
| `should handle class instances with getter/setter properties` | `Should_Handle_Class_Instances_With_Getter/setter_Properties` |

### Class: Scene00ReproductionBug

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should execute callbacks at position 0 again when timeline loops` | `Should_Execute_Callbacks_At_Position_0_Again_When_Timeline_Loops` |

### Class: TimelineOnCompleteCallback

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should call onComplete when timeline finishes (non-looping)` | `Should_Call_Oncomplete_When_Timeline_Finishes_(non-looping)` |
| `should not call onComplete for looping timelines` | `Should_Not_Call_Oncomplete_For_Looping_Timelines` |
| `should call onComplete again when timeline is restarted and completes` | `Should_Call_Oncomplete_Again_When_Timeline_Is_Restarted_And_Completes` |
| `should not call onComplete when timeline is paused before completion` | `Should_Not_Call_Oncomplete_When_Timeline_Is_Paused_Before_Completion` |
| `should call onComplete when playing again after pause reaches completion` | `Should_Call_Oncomplete_When_Playing_Again_After_Pause_Reaches_Completion` |
| `should call onComplete with correct timing when timeline has overshoot` | `Should_Call_Oncomplete_With_Correct_Timing_When_Timeline_Has_Overshoot` |
| `should work correctly with synced sub-timelines` | `Should_Work_Correctly_With_Synced_Sub-timelines` |
| `should handle onComplete with timeline that has only callbacks` | `Should_Handle_Oncomplete_With_Timeline_That_Has_Only_Callbacks` |
| `should handle onComplete when timeline duration is shorter than animations` | `Should_Handle_Oncomplete_When_Timeline_Duration_Is_Shorter_Than_Animations` |
| `should not call onComplete multiple times on same completion` | `Should_Not_Call_Oncomplete_Multiple_Times_On_Same_Completion` |

### Class: OnceMethod

| TypeScript Test Name | C# Test Name |
|---------------------|--------------|
| `should execute once animation immediately` | `Should_Execute_Once_Animation_Immediately` |
| `should remove once animation after completion` | `Should_Remove_Once_Animation_After_Completion` |
| `should not re-execute once animation when timeline loops` | `Should_Not_Re-execute_Once_Animation_When_Timeline_Loops` |
| `should handle multiple once animations` | `Should_Handle_Multiple_Once_Animations` |
| `should handle once animations with different easing functions` | `Should_Handle_Once_Animations_With_Different_Easing_Functions` |
| `should trigger onUpdate callbacks for once animations` | `Should_Trigger_Onupdate_Callbacks_For_Once_Animations` |
| `should handle zero duration once animations` | `Should_Handle_Zero_Duration_Once_Animations` |
| `should handle once animations added while timeline is paused` | `Should_Handle_Once_Animations_Added_While_Timeline_Is_Paused` |

## Test Execution

```bash
# Run TypeScript tests
cd packages/core && bun test packages/core/src/animation/Timeline.test.ts

# Run C# tests (after conversion)
cd test/timewarp-tui-core-tests
dotnet fixie --tests "BasicAnimation.*"
```

## Implementation Notes

_Space for manual notes during conversion_

## Results

_Added after completion_
