using HarmonyLib;
using TimberApi.DependencyContainerSystem;
using TimberApi.HarmonySystem;
using Timberborn.BlueprintSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.GameScene;
using Timberborn.PrefabGroupSystem;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

internal class EarlyLoadPatcher
{
    public static bool BlockLoading = true;

    public static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<PrefabGroupService>(nameof(PrefabGroupService.Load)),
            postfix: harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(FixyPixy))
        );
        
        
        // harmony.Patch(
        //     harmony.GetMethodInfo<PrefabGroupService>(nameof(PrefabGroupService.Load)),
        //     harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        // );
        //
        // harmony.Patch(
        //     harmony.GetMethodInfo<FactionService>(nameof(FactionService.Load)),
        //     harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        // );
        //
        // harmony.Patch(
        //     harmony.GetMethodInfo<GameSceneSerializedWorldSupplier>(nameof(GameSceneSerializedWorldSupplier.Load)),
        //     harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        // );
        //
        // harmony.Patch(
        //     harmony.GetMethodInfo<FactionSpecService>(nameof(FactionSpecService.Load)),
        //     harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        // );
        //
        // harmony.Patch(
        //     harmony.GetMethodInfo<SpecService>(nameof(SpecService.Load)),
        //     harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        // );
    }
    
    public static void FixyPixy()
    {
        DependencyContainer.GetInstance<GeneratedSpecLoader>().RegenerateSpecBlueprints();
    }

    public static bool BlockingLoadableSingletonLoad()
    {
        return !BlockLoading;
    }
}