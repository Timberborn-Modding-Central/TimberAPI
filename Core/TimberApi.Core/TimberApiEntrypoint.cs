using System;
using System.IO;
using System.Reflection;
using MonoMod.RuntimeDetour;
using TimberApi.Core.BootstrapSystem;
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
        }

        public static string GetModdingInfoHook()
        {
            try
            {
                LoadTimberApiManager();
                ModResolver.TryGetMods(out string mods);
                return "Modded: true, " + "TimberApi, " + mods;
            }
            catch (Exception e)
            {
                File.WriteAllText("Exception.txt", e.ToString());
                throw;
            }
        }

        public static void LoadTimberApiManager()
        {
            var timberApiManager = new GameObject("TimberApiManager");
            timberApiManager.AddComponent<TimberApiBootstrapSystemConfigurator>();
            Object.DontDestroyOnLoad(timberApiManager);
        }
    }
}