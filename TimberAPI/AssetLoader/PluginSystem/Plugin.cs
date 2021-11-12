using TimberbornAPI.AssetLoader.AssetSystem;

namespace TimberbornAPI.AssetLoader.PluginSystem
{
    internal class Plugin
    {
        public readonly AssetRepository AssetRepository;

        public readonly string AssemblyPath;
        
        public readonly string Prefix;

        public readonly IAssetLoaderSystem.EntryPoint LoadingScene;

        public readonly string[] RootPath;

        public Plugin(string prefix, string[] rootPath, string assemblyPath, IAssetLoaderSystem.EntryPoint loadingScene)
        {
            Prefix = prefix;
            RootPath = rootPath;
            AssemblyPath = assemblyPath;
            LoadingScene = loadingScene;
            AssetRepository = new AssetRepository();
        }
    }
}