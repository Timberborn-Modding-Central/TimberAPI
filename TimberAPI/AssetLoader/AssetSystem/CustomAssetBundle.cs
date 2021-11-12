using System;
using System.IO;
using System.Linq;
using TimberbornAPI.AssetLoader.PluginSystem;
using UnityEngine;

namespace TimberbornAPI.AssetLoader.AssetSystem
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

        public void Load()
        {
            if (IsBundleLoaded || AssetBundle != null)
            {
                if(_plugin.LoadingScene == IAssetLoaderSystem.EntryPoint.Global)
                    return;
                Console.WriteLine($"Asset: {FileName} was already loaded.");
                return;
            }
            
            AssetBundle = AssetBundle.LoadFromFile(Path.Combine(_plugin.AssemblyPath, Path.Combine(FullPath), FileName));
            if(AssetBundle != null)
                IsBundleLoaded = true;
        }
        
        public void Unload()
        {
            if (!IsBundleLoaded || AssetBundle == null)
            {
                Console.WriteLine($"Asset: {FileName} was already unloaded.");
                return;
            }
            
            AssetBundle.Unload(true);
            AssetBundle = null;
            IsBundleLoaded = false;
        }
    }
}