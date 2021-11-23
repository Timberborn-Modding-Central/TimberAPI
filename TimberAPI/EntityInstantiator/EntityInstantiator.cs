using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using HarmonyLib;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.EntityInstantiatorSystem
{
    internal class EntityInstantiator
    {
        private static ImmutableArray<IEntityInstantiator> _gameObjectModifiers;

        public EntityInstantiator(IEnumerable<IEntityInstantiator> visualElementInitializers)
        {
            _gameObjectModifiers = visualElementInitializers.ToImmutableArray();
        }
        
        [HarmonyPatch(typeof(EntityService), "Instantiate", typeof(GameObject), typeof(Guid))]
        public static class EntityServicePatchGameObjectInitializers
        {
            private static void Postfix(GameObject __result)
            {
                for (int i = 0; i < _gameObjectModifiers.Length; i++)
                {
                    _gameObjectModifiers[i].Instantiate(__result);
                }
            }
        }
    }
}