using Bindito.Core;
using HarmonyLib;
using TimberApi.Core2.Common;
using TimberApi.Internal.SingletonSystem.Singletons;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetScenePatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {

            Harmony harmony = new Harmony("TimberApi.assets");

            harmony.Patch(
                original: AccessTools.Method(typeof(MasterSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(AssetScenePatcher), nameof(PatchMasterSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(AssetScenePatcher), nameof(PatchMainMenuSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MapEditorSceneConfigurator), "Configure"),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(AssetScenePatcher), nameof(PatchMapEditorSceneConfigurator)))
            );
        }

        public static SceneEntrypoint CurrentScene;

        private static void PatchMasterSceneConfigurator()
        {
            var assetBundleLoader = TimberApiInternal.Container.GetInstance<AssetBundleLoader>();
            UnloadCurrentSceneAssets(assetBundleLoader);
            LoadAssetsForScene(SceneEntrypoint.InGame, assetBundleLoader);
        }

        private static void PatchMainMenuSceneConfigurator()
        {
            var assetBundleLoader = TimberApiInternal.Container.GetInstance<AssetBundleLoader>();
            UnloadCurrentSceneAssets(assetBundleLoader);
            LoadAssetsForScene(SceneEntrypoint.MainMenu, assetBundleLoader);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            var assetBundleLoader = TimberApiInternal.Container.GetInstance<AssetBundleLoader>();
            UnloadCurrentSceneAssets(assetBundleLoader);
            LoadAssetsForScene(SceneEntrypoint.MapEditor, assetBundleLoader);
        }

        private static void UnloadCurrentSceneAssets(AssetBundleLoader assetBundleLoader)
        {
            if (CurrentScene == 0)
            {
                return;
            }
            assetBundleLoader.UnloadAll(CurrentScene);
        }

        private static void LoadAssetsForScene(SceneEntrypoint sceneEntrypoint, AssetBundleLoader assetBundleLoader)
        {
            assetBundleLoader.LoadAll(sceneEntrypoint);
            CurrentScene = sceneEntrypoint;
        }
    }
}