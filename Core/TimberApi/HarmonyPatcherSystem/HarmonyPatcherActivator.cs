using System;
using System.Collections.Generic;
using System.Linq;
using Bindito.Core;
using HarmonyLib;
using TimberApi.SceneSystem;
using UnityEngine;

namespace TimberApi.HarmonyPatcherSystem
{
    public class HarmonyPatcherActivator
    {
        private readonly IEnumerable<IHarmonyPatcher> _harmonyPatchers;

        private readonly Dictionary<string, Harmony> _activatePatchers;

        public HarmonyPatcherActivator()
        {
            _harmonyPatchers = CreateHarmonyPatchers();
            _activatePatchers = new Dictionary<string, Harmony>();
            TimberApiSceneManager.SceneChanged += ApiSceneManagerOnSceneChanged;
        }

        private void ApiSceneManagerOnSceneChanged(SceneEntrypoint previousscene, SceneEntrypoint currentscene, IContainerDefinition currentcontainerdefinition)
        {
            PatchAll(currentscene);
        }

        public void PatchAll(SceneEntrypoint? scene)
        {
            foreach (var harmonyPatcher in _harmonyPatchers)
            {
                try
                {
                    var shouldApply = harmonyPatcher.ShouldApply(scene);

                    if(shouldApply && _activatePatchers.ContainsKey(harmonyPatcher.UniqueId))
                    {
                        continue;
                    }
                    
                    if(shouldApply)
                    {
                        var harmony = new Harmony(harmonyPatcher.UniqueId);
                        
                        harmonyPatcher.Apply(harmony);
                        _activatePatchers.Add(harmonyPatcher.UniqueId, harmony);
                        continue;
                    }

                    if(_activatePatchers.TryGetValue(harmonyPatcher.UniqueId, out var activeHarmony))
                    {
                        activeHarmony.UnpatchAll(harmonyPatcher.UniqueId);
                        _activatePatchers.Remove(harmonyPatcher.UniqueId);
                    }
                }
                catch (Exception exception)
                {
                    TimberApi.ConsoleWriter.Log($"Patcher {harmonyPatcher.UniqueId} failed.\r\n" + exception, LogType.Error);
                }
            }
        }

        private static IEnumerable<IHarmonyPatcher> CreateHarmonyPatchers()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IHarmonyPatcher).IsAssignableFrom(x) && ! x.IsInterface && ! x.IsAbstract)
                .Select(x => (IHarmonyPatcher) Activator.CreateInstance(x));
        }
    }
}