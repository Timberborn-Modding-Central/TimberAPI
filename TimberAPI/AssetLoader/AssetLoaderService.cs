using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TimberbornAPI.AssetLoader.AssetSystem;
using TimberbornAPI.AssetLoader.Exceptions;
using TimberbornAPI.AssetLoader.PluginSystem;
using TimberbornAPI.Common;

namespace TimberbornAPI.AssetLoader
{
    public class AssetLoaderService : IAssetLoaderService
    {
        internal static SceneEntryPoint ActiveScene = SceneEntryPoint.Global;

        internal static PluginRepository PluginRepository = new PluginRepository();

        public void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint, string[] assetLocation)
        {
            Console.WriteLine($"Creating new asset area with prefix: {prefix}");
            CreateNewPluginAsset(prefix, assetLocation, Path.GetDirectoryName(Assembly.GetCallingAssembly()?.Location), assetEntryPoint);
        }

        public void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint)
        {
            Console.WriteLine($"Creating new asset area with prefix: {prefix}");
            CreateNewPluginAsset(prefix, new[] { "assets" }, Path.GetDirectoryName(Assembly.GetCallingAssembly()?.Location), assetEntryPoint);
        }

        public void AddSceneAssets(string prefix)
        {
            Console.WriteLine($"Creating new asset area with prefix: {prefix}");
            CreateNewPluginAsset(prefix, new[] { "assets" }, Path.GetDirectoryName(Assembly.GetCallingAssembly()?.Location), SceneEntryPoint.InGame);
        }

        public void LoadSceneAssets(SceneEntryPoint scene)
        {
            Console.WriteLine($"Loading scene: {scene}, prefixes in scene: {string.Join(",", PluginRepository.All().Where(plugin => plugin.LoadingScene == scene).Select(plugin => plugin.Prefix))}");
            ActiveScene = scene;
            foreach (Plugin plugin in PluginRepository.All().Where(plugin => plugin.LoadingScene == scene))
            {
                plugin.AssetRepository.LoadAll();
            }
        }

        public void UnloadSceneAssets(SceneEntryPoint scene)
        {
            Console.WriteLine($"Unloading scene: {scene}");
            foreach (Plugin plugin in PluginRepository.All().Where(plugin => plugin.LoadingScene == scene))
            {
                plugin.AssetRepository.UnloadAll();
            }
        }

        private void CreateNewPluginAsset(string prefix, string[] assetLocation, string assemblyFolder, SceneEntryPoint loadingScene)
        {
            if (assemblyFolder == null || string.IsNullOrEmpty(assemblyFolder))
            {
                Console.WriteLine($"Failed to load assets with the prefix {prefix}. dll location was not found");
                return;
            }

            try
            {
                Plugin plugin = new Plugin(prefix, assetLocation, assemblyFolder, loadingScene);
                List<string[]> relativeAssetPaths = ModPluginAssetRelativePathFinder(plugin.AssemblyPath, Path.Combine(plugin.RootPath));
                foreach (string[] relativeAssetPath in relativeAssetPaths)
                {
                    plugin.AssetRepository.Add(new CustomAssetBundle(plugin, relativeAssetPath.Take(relativeAssetPath.Length - 1).ToArray(), relativeAssetPath.Last()));
                }

                PluginRepository.Add(plugin);
                Console.WriteLine($"Prefix {plugin.Prefix}, assets: {plugin.AssetRepository.All().Count()}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Failed to load assets for prefix: {prefix}");
                Console.WriteLine(e.Message);
            }
            catch (PluginPrefixInUseException e)
            {
                Console.WriteLine($"Failed to load prefix {e.Plugin.Prefix}, prefix is already in use.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong please contact the mod owner.");
                Console.WriteLine(e.Message);
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