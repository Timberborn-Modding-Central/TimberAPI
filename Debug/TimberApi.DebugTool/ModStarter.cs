using HarmonyLib;
using Timberborn.ModManagerScene;

namespace TimberApi.DebugTool;

public class ModStarter : IModStarter
{
    public void StartMod(IModEnvironment modEnvironment)
    {
        var harmony = new Harmony("TimberApi.Debug");
        
        harmony.PatchAll();
    }
}