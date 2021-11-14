using Bindito.Unity;
using HarmonyLib;
using Timberborn.GameSaveRepositorySystem;
using Timberborn.MainMenuSceneLoading;
using Timberborn.MapEditorSceneLoading;
using Timberborn.MapSystem;
using Timberborn.MasterSceneLoading;

namespace TimberbornAPI.AssetLoader.Patches
{
    public class SceneLoaderPatcher
    {
        [HarmonyPatch(typeof(ProjectConfigurator), "Awake")]
        public static class ProjectConfiguratorPatch
        {
            private static void Postfix()
            {
                TimberAPI.AssetLoaderSystem.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.Global);
                TimberAPI.AssetLoaderSystem.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.MainMenu);
            }
        }
        
        [HarmonyPatch(typeof(MainMenuSceneLoader), "StartMainMenu")]
        public static class MMainMenuSceneLoaderPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.MainMenu);
            }
        }
        
        [HarmonyPatch(typeof(MasterSceneLoader), "StartNewGame", typeof(NewGameConfiguration))]
        public static class MasterSceneLoaderStartNewPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.InGame);
            }
        }
        
        [HarmonyPatch(typeof(MasterSceneLoader), "StartSaveGame", typeof(SaveReference))]
        public static class MasterSceneLoaderStartSavePatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.InGame);
            }
        }
        
        [HarmonyPatch(typeof(MapEditorSceneLoader), "StartNewMap")]
        public static class MapEditorSceneLoaderStartNewPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.MapEditor);
            }
        }
        
        [HarmonyPatch(typeof(MapEditorSceneLoader), "LoadMap", typeof(MapFileReference))]
        public static class MapEditorSceneLoaderLoadPatch
        {
            private static void Postfix()
            {
                LoadHelper.LoadSceneAssets(IAssetLoaderSystem.EntryPoint.MapEditor);
            }
        }

        private static class LoadHelper
        {
            /**
             * Unloads active scene assets, loads the new scene accets
             */
            internal static void LoadSceneAssets(IAssetLoaderSystem.EntryPoint scene)
            {
                TimberAPI.AssetLoaderSystem.UnloadSceneAssets(AssetLoaderSystem.ActiveScene);
                TimberAPI.AssetLoaderSystem.LoadSceneAssets(scene);
            }
        }
    }
}