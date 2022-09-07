using BepInEx;
using TimberApi.SharedLoader;

namespace TimberApi.BepInExPlugin
{
    public class BepInExStartupLoader : BaseStartupLoader
    {
        public static string LoaderType = "BepInEx";

        public BepInExStartupLoader(string timberApiRootPath) : base(LoaderType, timberApiRootPath, Paths.PluginPath)
        {

        }

        public static void Run(string timberApiRootPath)
        {
            new BepInExStartupLoader(timberApiRootPath).Run();
        }
    }
}