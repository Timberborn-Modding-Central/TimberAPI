using System;
using System.IO;
using System.Reflection;
using System.Text;
using Bindito.Unity;
using MonoMod.RuntimeDetour;
using TimberApi.Internal.BootstrapSystem;
using TimberApi.Internal.Common;
using TimberApi.Internal.TimberApiVisualizer;
using TimberApi.LoaderInterfaces;
using Timberborn.Core;
using Timberborn.MasterSceneLoading;
using Timberborn.SceneLoading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace TimberApi.Internal
{
    internal class TimberApiEntrypoint : ITimberApiPatcher
    {
        public void Initialize()
        {
            Paths.Load();
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
                timberApiManager.AddComponent<TimberApiBootstrapConfigurator>();
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