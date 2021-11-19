using Bindito.Unity;
using HarmonyLib;
using Timberborn.GameSaveRepositorySystem;
using Timberborn.MainMenuSceneLoading;
using Timberborn.MapEditorSceneLoading;
using Timberborn.MapSystem;
using Timberborn.MasterSceneLoading;
using TimberbornAPI.Common;

namespace TimberbornAPI.AssetLoader.Patches
{
    public class SceneLoaderPatcher
    {
        [HarmonyPatch(typeof(ProjectConfigurator), "Awake")]
        public static class ProjectConfiguratorPatch
        {
            private static void Postfix()
            {
                TimberAPI.AssetRegistry.LoadSceneAssets(SceneEntryPoint.Global);
                TimberAPI.AssetRegistry.LoadSceneAssets(SceneEntryPoint.MainMenu);
            }
        }

        [HarmonyPatch(typeof(MainMenuSceneLoader), "StartMainMenu")]
        public static class MMainMenuSceneLoaderPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(SceneEntryPoint.MainMenu);
            }
        }

        [HarmonyPatch(typeof(MasterSceneLoader), "StartNewGame", typeof(NewGameConfiguration))]
        public static class MasterSceneLoaderStartNewPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(SceneEntryPoint.InGame);
            }
        }

        [HarmonyPatch(typeof(MasterSceneLoader), "StartSaveGame", typeof(SaveReference))]
        public static class MasterSceneLoaderStartSavePatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(SceneEntryPoint.InGame);
            }
        }

        [HarmonyPatch(typeof(MapEditorSceneLoader), "StartNewMap")]
        public static class MapEditorSceneLoaderStartNewPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(SceneEntryPoint.MapEditor);
            }
        }

        [HarmonyPatch(typeof(MapEditorSceneLoader), "LoadMap", typeof(MapFileReference))]
        public static class MapEditorSceneLoaderLoadPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(SceneEntryPoint.MapEditor);
            }
        }

        private static class LoadHelper
        {
            /**
             * Unloads active scene assets, loads the new scene accets
             */
            internal static void LoadSceneAssets(SceneEntryPoint scene)
            {
                TimberAPI.AssetRegistry.UnloadSceneAssets(AssetRegistry.ActiveScene);
                TimberAPI.AssetRegistry.LoadSceneAssets(scene);
            }
        }
    }
}