using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.Common;

namespace TimberbornAPI.AssetLoaderSystem.PluginSystem
{
    internal class Plugin
    {
        public readonly AssetRepository AssetRepository;

        public readonly string AssemblyPath;

        public readonly string Prefix;

        public readonly SceneEntryPoint LoadingScene;

        public readonly string[] RootPath;

        public Plugin(string prefix, string[] rootPath, string assemblyPath, SceneEntryPoint loadingScene)
        {
            Prefix = prefix;
            RootPath = rootPath;
            AssemblyPath = assemblyPath;
            LoadingScene = loadingScene;
            AssetRepository = new AssetRepository();
        }
    }
}