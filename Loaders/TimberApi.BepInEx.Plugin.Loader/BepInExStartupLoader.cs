using BepInEx;
using TimberApi.SharedLoader;

namespace TimberApi.BepInExPlugin.Loader
{
    public class BepInExStartupLoader : BaseStartupLoader
    {
        public static string LoaderType = "BepInEx";

        public BepInExStartupLoader(string timberApiRootPath) : base(LoaderType, timberApiRootPath, Paths.PluginPath)
        {

        }

        public static void Run(string timberApiRootPath)
        {
            var startLoader = new BepInExStartupLoader(timberApiRootPath);
            startLoader.StartLoader();
            startLoader.LoadAndInitializeCoreStartup();
        }
    }
}