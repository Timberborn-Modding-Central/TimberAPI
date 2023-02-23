using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using TimberApi.Common;
using TimberApi.Common.SingletonSystem;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.Core.SingletonSystem
{
    public class SingletonSystemPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.SingletonSystem";

        public override void Apply(Harmony harmony)
        {
            try
            {
                harmony.Patch(
                    GetMethodInfo("Timberborn.SingletonSystem.SingletonLifecycleService", "LoadAll"),
                    GetHarmonyMethod(nameof(SingletonLifecycleServicePrefix))
                );
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        public static void Patch()
        {
            try
            {
                var harmony = new Harmony("TimberApi.singletonSystem");
                harmony.Patch(AccessTools.TypeByName("Timberborn.SingletonSystem.SingletonLifecycleService").GetMethod("LoadAll"),
                    new HarmonyMethod(AccessTools.Method(typeof(SingletonSystemPatcher), nameof(SingletonLifecycleServicePrefix))));
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        public static void SingletonLifecycleServicePrefix(ISingletonRepository ____singletonRepository)
        {
            SingletonActivator(____singletonRepository.GetSingletons<ITimberApiPreLoadableSingleton>(), singleton => singleton.PreLoad());
            SingletonActivator(____singletonRepository.GetSingletons<ITimberApiLoadableSingleton>(), singleton => singleton.Load());
            SingletonActivator(____singletonRepository.GetSingletons<ITimberApiPostLoadableSingleton>(), singleton => singleton.PostLoad());
        }

        private static void SingletonActivator<T>(IEnumerable<T> singletons, Action<T> action) where T : class
        {
            foreach (T singleton in singletons)
            {
                action(singleton);
            }
        }
    }
}