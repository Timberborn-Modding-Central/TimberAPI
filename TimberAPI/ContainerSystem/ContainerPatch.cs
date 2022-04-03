using Bindito.Core.Internal;
using HarmonyLib;

namespace TimberbornAPI.ContainerSystem
{
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
            ContainerHolder.Container = __instance;
        }
    }
}