using TimberApi.Core.BootstrapSystem;
using TimberApi.Core.CompatibilitySystem;
using TimberApi.New;
using UnityEngine;

namespace TimberApi.Core
{
    public static class Startup
    {
        public static void Run()
        {
            var timberApi = new GameObject("TimberApi");

            if (!IsTimberApiCompatibleWithGame())
            {
                timberApi.AddComponent<CompatibilityVisualizer>();
            }
            else
            {
                timberApi.AddComponent<TimberApiBootstrapSystemConfigurator>();
            }

            Object.DontDestroyOnLoad(timberApi);
        }

        private static bool IsTimberApiCompatibleWithGame()
        {
            return Versions.GameVersion >= Versions.TimberApiMinimumGameVersion;
        }
    }
}