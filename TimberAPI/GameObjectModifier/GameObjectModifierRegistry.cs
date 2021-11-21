using System;
using System.Collections.Generic;
using HarmonyLib;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.GameObjectModifier
{
    public class GameObjectModifierRegistry : IGameObjectModifierRegistry
    {
        private static List<IGameObjectModifier> _gameObjectInitializers = new();
        
        public void AddModifier(IGameObjectModifier gameObjectInitializer)
        {
            _gameObjectInitializers.Add(gameObjectInitializer);
        }
        
        [HarmonyPatch(typeof(EntityService), "Instantiate", typeof(GameObject), typeof(Guid))]
        public static class EntityServicePatchGameObjectInitializers
        {
            private static void Postfix(ref GameObject __result)
            {
                for (int i = 0; i < _gameObjectInitializers.Count; i++)
                {
                    _gameObjectInitializers[i].Modify(__result);
                }
            }
        }
    }
}