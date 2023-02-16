using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace TimberApi.HarmonyPatcherSystem
{
    public class HarmonyPatcherActivator
    {
        private readonly IEnumerable<IHarmonyPatcher> _harmonyPatchers;

        public HarmonyPatcherActivator()
        {
            _harmonyPatchers = CreateHarmonyPatchers();
        }

        public void PatchAll()
        {
            foreach (var harmonyPatcher in _harmonyPatchers)
            {
                var harmony = new Harmony(harmonyPatcher.UniqueId);
                
                try
                {
                    harmonyPatcher.Apply(harmony);
                }
                catch (Exception)
                {
                    Debug.LogError($"Patcher {harmonyPatcher.UniqueId} failed.");
                }
            }
        }
        
        private static IEnumerable<IHarmonyPatcher> CreateHarmonyPatchers()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IHarmonyPatcher).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (IHarmonyPatcher) Activator.CreateInstance(AccessTools.TypeByName(x.Name)));
        }
    }
}