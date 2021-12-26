using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using HarmonyLib;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.EntityActionSystem
{
    internal class EntityActionApplier
    {
        private static ImmutableArray<IEntityAction> _entityActions;

        public EntityActionApplier(IEnumerable<IEntityAction> entityActions)
        {
            _entityActions = entityActions.ToImmutableArray();
        }
        
        [HarmonyPatch(typeof(EntityService), "Instantiate", typeof(GameObject), typeof(Guid))]
        public static class EntityServicePatchGameObjectInitializers
        {
            private static void Postfix(GameObject __result)
            {
                for (int i = 0; i < _entityActions.Length; i++)
                {
                    _entityActions[i].ApplyToEntity(__result);
                }
            }
        }
    }
}