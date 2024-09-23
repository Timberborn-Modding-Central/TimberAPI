using HarmonyLib;
using TimberApi.HarmonySystem;
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
            harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        );

        harmony.Patch(
            harmony.GetMethodInfo<FactionService>(nameof(FactionService.Load)),
            harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        );

        harmony.Patch(
            harmony.GetMethodInfo<GameSceneWorldSaveSupplier>(nameof(GameSceneWorldSaveSupplier.Load)),
            harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        );

        harmony.Patch(
            harmony.GetMethodInfo<FactionSpecificationService>(nameof(FactionSpecificationService.Load)),
            harmony.GetHarmonyMethod<EarlyLoadPatcher>(nameof(BlockingLoadableSingletonLoad))
        );
    }

    public static bool BlockingLoadableSingletonLoad()
    {
        if (SceneManager.CurrentScene == Scene.MainMenu) return true;

        return !BlockLoading;
    }
}