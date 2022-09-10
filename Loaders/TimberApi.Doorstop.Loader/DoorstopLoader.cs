using System.Reflection;
using MonoMod.RuntimeDetour;
using TimberApi.SharedLoader;
using Timberborn.Core;

namespace TimberApi.Doorstop.Loader
{
    public class DoorstopLoader : BaseStartupLoader
    {
        private static DoorstopLoader _instance = null!;

        public static string LoaderType = "Doorstop";

        private static readonly string[] LibraryDlls =
        {
            "0Harmony.dll",
            "Mono.Cecil.dll",
            "Mono.Cecil.Mdb.dll",
            "Mono.Cecil.Pdb.dll",
            "Mono.Cecil.Rocks.dll",
            "MonoMod.RuntimeDetour.dll",
            "MonoMod.Utils.dll"
        };

        public DoorstopLoader(string timberApiRootPath, string modsPath) : base(LoaderType, timberApiRootPath, modsPath, LibraryDlls)
        {
            _instance = this;
        }

        public static void Run(string timberApiRootPath, string modsPath)
        {
            new DoorstopLoader(timberApiRootPath, modsPath).StartLoader();

            var hook = new Hook(typeof(GameStartLogger).GetMethod("GetModdingInfo", BindingFlags.Static | BindingFlags.NonPublic),
                typeof(DoorstopLoader).GetMethod(nameof(GetModdingInfoHook), BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static string GetModdingInfoHook()
        {
            _instance.LoadAndInitializeCoreStartup();
            ModResolver.TryGetMods(out string mods);
            return "Modded: true, " + "TimberApi, " + mods;
        }
    }
}