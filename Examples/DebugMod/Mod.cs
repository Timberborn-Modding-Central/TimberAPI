using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;

namespace DebugMod
{
    public class Mod : IModEntrypoint
    {
        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            new Harmony("DebugMod").PatchAll();
        }
    }
}