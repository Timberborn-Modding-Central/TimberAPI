using System;
using System.Collections.Generic;
using Bindito.Core.Internal;
using HarmonyLib;

namespace TimberApi.Core2.DependencyContainerSystem
{
    public static class DependencyContainer
    {
        private static Bindito.Core.IContainer _container = null!;

        public static T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        public static object GetInstance(Type type)
        {
            return _container.GetInstance(type);
        }

        public static IEnumerable<object> GetBoundInstances()
        {
            return _container.GetBoundInstances();
        }

        [HarmonyPatch(
            typeof(Container),
            MethodType.Constructor,
            typeof(IInstanceBank),
            typeof(IValidatingMethodInjector),
            typeof(IBoundInstanceService),
            typeof(IContainerCreator))]
        public static class ContainerPatch
        {
            private static void Postfix(Container __instance)
            {
                DependencyContainer._container = __instance;
            }
        }
    }
}