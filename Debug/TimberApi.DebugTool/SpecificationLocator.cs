using Bindito.Core;
using HarmonyLib;
using Timberborn.Persistence;

namespace TimberApi.DebugTool;

[HarmonyPatch(typeof(PersistenceConfigurator), nameof(PersistenceConfigurator.Configure), new []{ typeof(IContainerDefinition)})]
public static class SpecificationLocator
{
    public static bool Prefix(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ISpecificationService>().To<SpecificationServiceLogger>().AsSingleton();
        return false;
    }
}