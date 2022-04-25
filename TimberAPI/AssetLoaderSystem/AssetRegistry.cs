using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.AssetLoaderSystem.Exceptions;
using TimberbornAPI.AssetLoaderSystem.PluginSystem;
using TimberbornAPI.Common;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.AssetLoaderSystem
{
    public class AssetRegistry : IAssetRegistry
    {
        internal static SceneEntryPoint ActiveScene = SceneEntryPoint.Global;

        internal static PluginRepository PluginRepository = new();

        public void AddSceneAssets(string prefix)
        {
            AddSceneAssets(prefix, SceneEntryPoint.InGame, new[] { "assets" }, Assembly.GetCallingAssembly()?.Location);
        }

        public void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint)
        {
            AddSceneAssets(prefix, assetEntryPoint, new[] { "assets" }, Assembly.GetCallingAssembly()?.Location);
        }

        public void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint, string[] assetLocation)
        {
            AddSceneAssets(prefix, assetEntryPoint, assetLocation, Assembly.GetCallingAssembly()?.Location);
        }

        public void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint, string[] assetLocation, string assemblyLocation) {
            Log.LogInfo($"Creating new asset area with prefix: {prefix}");
            CreateNewPluginAsset(prefix, assetLocation, Path.GetDirectoryName(assemblyLocation), assetEntryPoint);
        }

        public void LoadSceneAssets(SceneEntryPoint scene)
        {
            Log.LogInfo($"Loading scene: {scene}, prefixes in scene: {string.Join(",", PluginRepository.All().Where(plugin => plugin.LoadingScene == scene).Select(plugin => plugin.Prefix))}");
            ActiveScene = scene;
            foreach (Plugin plugin in PluginRepository.All().Where(plugin => plugin.LoadingScene == scene))
            {
                plugin.AssetRepository.LoadAll();
            }
        }

        public void UnloadSceneAssets(SceneEntryPoint scene)
        {
            Log.LogInfo($"Unloading scene: {scene}");
            foreach (Plugin plugin in PluginRepository.All().Where(plugin => plugin.LoadingScene == scene))
            {
                plugin.AssetRepository.UnloadAll();
            }
        }

        private void CreateNewPluginAsset(string prefix, string[] assetLocation, string assemblyFolder, SceneEntryPoint loadingScene)
        {
            if (assemblyFolder == null || string.IsNullOrEmpty(assemblyFolder))
            {
                Log.LogError($"Failed to load assets with the prefix {prefix}. dll location was not found");
                return;
            }

            try
            {
                Plugin plugin = new Plugin(prefix, assetLocation, assemblyFolder, loadingScene);
                List<string[]> relativeAssetPaths = ModPluginAssetRelativePathFinder(plugin.AssemblyPath, Path.Combine(plugin.RootPath));
                foreach (string[] relativeAssetPath in relativeAssetPaths)
                {
                    plugin.AssetRepository.Add(new CustomAssetBundle(plugin, relativeAssetPath.Take(relativeAssetPath.Length - 1).ToArray(), relativeAssetPath.Last()));
                    Log.LogInfo($"Asset {plugin.Prefix}/{string.Join("/", relativeAssetPath)} found");
                }

                PluginRepository.Add(plugin);
                Log.LogInfo($"Prefix {plugin.Prefix}, assets: {plugin.AssetRepository.All().Count()}");
            }
            catch (DirectoryNotFoundException e)
            {
                Log.LogError($"Failed to load assets for prefix: {prefix}");
                Log.LogError(e.Message);
            }
            catch (PluginPrefixInUseException e)
            {
                Log.LogInfo($"Failed to load prefix {e.Plugin.Prefix}, prefix is already in use.");
            }
            catch (Exception e)
            {
                Log.LogError($"Something went wrong please contact the mod owner.");
                Log.LogError(e.Message);
                throw;
            }
        }

        /// <summary>
        /// returns all asset locations with a relative path.
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        private List<string[]> ModPluginAssetRelativePathFinder(string assemblyPath, string rootPath)
        {
            return FromAbsoluteToRelative(RecursiveAssetSearch(Path.Combine(assemblyPath, rootPath)), rootPath);
        }

        /// <summary>
        /// Extracts the absolute path location
        /// </summary>
        /// <param name="absolutePathList"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private List<string[]> FromAbsoluteToRelative(IEnumerable<string> absolutePathList, string root)
        {
            return absolutePathList.Select(absolutePath =>
                absolutePath[(absolutePath.LastIndexOf(root, StringComparison.Ordinal) + root.Length + 1)..].Split('\\'))
                .ToList();
        }

        /// <summary>
        /// returns absolute paths from all assets inside the root folder
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        private List<string> RecursiveAssetSearch(string absolutePath)
        {
            List<string> assetLocations = new List<string>();
            assetLocations.AddRange(AssetsInFolder(absolutePath));
            foreach (string directory in Directory.GetDirectories(absolutePath))
            {
                assetLocations.AddRange(RecursiveAssetSearch(directory));
            }
            return assetLocations;
        }

        /// <summary>
        /// Iterates thru files, allowed files extensions: none, .bundle, .asset
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        private IEnumerable<string> AssetsInFolder(string absolutePath)
        {
            return Directory.GetFiles(absolutePath).Where(asset =>
                !Path.HasExtension(asset)
                || Path.GetExtension(asset).Equals(".bundle")
                || Path.GetExtension(asset).Equals(".asset"));
        }
    }
}