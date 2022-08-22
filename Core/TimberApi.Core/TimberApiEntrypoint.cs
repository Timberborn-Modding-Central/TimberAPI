using System;
using System.IO;
using System.Reflection;
using System.Text;
using MonoMod.RuntimeDetour;
using TimberApi.Core.BootstrapSystem;
using TimberApi.Core.Common;
using TimberApi.Core2.Common;
using TimberApi.LoaderInterfaces;
using Timberborn.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.Core
{
    internal class TimberApiEntrypoint : ITimberApiPatcher
    {
        public void Initialize()
        {
            SetupMonoHooks();
        }

        public void SetupMonoHooks()
        {
            var hook = new Hook(
                typeof(GameStartLogger).GetMethod("GetModdingInfo", BindingFlags.Static | BindingFlags.NonPublic),
                typeof(TimberApiEntrypoint).GetMethod(nameof(GetModdingInfoHook))
            );

            var fix = new Hook(
                typeof(GameStartLogger).GetMethod("AppendDriveInfo", BindingFlags.Static | BindingFlags.NonPublic),
                typeof(TimberApiEntrypoint).GetMethod(nameof(LagFix))
            );
        }

        public static void LagFix(StringBuilder systemInfo) { }

        public static string GetModdingInfoHook()
        {
            try
            {
                var timberApiManager = new GameObject("TimberApiManager");
                timberApiManager.AddComponent<TimberApiBootstrapSystemConfigurator>();
                Object.DontDestroyOnLoad(timberApiManager);

                ModResolver.TryGetMods(out string mods);
                return "Modded: true, " + "TimberApi, " + mods;
            }
            catch (Exception e)
            {
                File.WriteAllText("Exception.txt", e.ToString());
                throw;
            }
        }
    }
}