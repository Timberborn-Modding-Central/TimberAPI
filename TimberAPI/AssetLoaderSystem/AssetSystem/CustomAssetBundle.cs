using System.IO;
using System.Linq;
using TimberbornAPI.AssetLoaderSystem.PluginSystem;
using TimberbornAPI.Common;
using UnityEngine;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.AssetLoaderSystem.AssetSystem
{
    internal class CustomAssetBundle
    {
        private readonly Plugin _plugin;

        public readonly string FileName;

        public readonly string[] FullPath;

        public readonly string[] AssetPath;

        public AssetBundle AssetBundle { get; private set; }

        public bool IsBundleLoaded;

        public CustomAssetBundle(Plugin plugin, string[] path, string fileName)
        {
            IsBundleLoaded = false;
            _plugin = plugin;
            AssetPath = path;
            FullPath = _plugin.RootPath.Concat(AssetPath).ToArray();
            FileName = fileName;
        }

        /// <summary>
        /// Loads a asset bundle
        /// </summary>
        public void Load()
        {
            if (IsBundleLoaded || AssetBundle != null)
            {
                if (_plugin.LoadingScene == SceneEntryPoint.Global)
                    return;
                Log.LogWarning($"Asset: {FileName} was already loaded.");
                return;
            }

            AssetBundle = AssetBundle.LoadFromFile(Path.Combine(_plugin.AssemblyPath, Path.Combine(FullPath), FileName));
            if (AssetBundle != null)
                IsBundleLoaded = true;
        }

        /// <summary>
        /// Unloads a asset bundle
        /// </summary>
        public void Unload()
        {
            if (!IsBundleLoaded || AssetBundle == null)
            {
                Log.LogWarning($"Asset: {FileName} was already unloaded.");
                return;
            }

            AssetBundle.Unload(true);
            AssetBundle = null;
            IsBundleLoaded = false;
        }
    }
}