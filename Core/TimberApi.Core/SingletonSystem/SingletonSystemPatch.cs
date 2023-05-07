using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using HarmonyLib;
using TimberApi.Common;
using TimberApi.Common.SingletonSystem;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.Core.SingletonSystem
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SingletonSystemPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.SingletonSystem";

        public override void Apply(Harmony harmony)
        {
            try
            {
                harmony.Patch(
                    GetMethodInfo<SingletonLifecycleService>(nameof(SingletonLifecycleService.LoadAll)),
                    GetHarmonyMethod(nameof(LoadAllPrefix))
                );

                harmony.Patch(
                    GetMethodInfo<SingletonLifecycleService>(nameof(SingletonLifecycleService.LoadSingletons)),
                    GetHarmonyMethod(nameof(LoadSingletonsPrefix)),
                    GetHarmonyMethod(nameof(LoadSingletonsPostfix))
                );
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, $"HarmonyException-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), e.ToString());
                throw;
            }
        }

        public static void LoadAllPrefix(ISingletonRepository ____singletonRepository)
        {
            LoadSingleton(____singletonRepository.GetSingletons<ITimberApiLoadableSingleton>(), singleton => singleton.Load());
        }

        public static void LoadSingletonsPrefix(ISingletonRepository ____singletonRepository)
        {
            LoadSingleton(____singletonRepository.GetSingletons<IEarlyLoadableSingleton>(), singleton => singleton.EarlyLoad());
        }

        public static void LoadSingletonsPostfix(ISingletonRepository ____singletonRepository)
        {
            LoadSingleton(____singletonRepository.GetSingletons<ILateLoadableSingleton>(), singleton => singleton.LateLoad());
        }

        private static void LoadSingleton<T>(IEnumerable<T> singletons, Action<T> action) where T : class
        {
            foreach (var singleton in singletons)
            {
                action(singleton);
            }
        }
    }
}