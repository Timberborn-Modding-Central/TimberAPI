using Bindito.Core;
using HarmonyLib;
using Timberborn.AssetSystem;

namespace TimberbornAPI.AssetLoaderSystem.ResourceAssetPatch
{
    [HarmonyPatch(typeof(AssetSystemConfigurator), "Configure", typeof(IContainerDefinition))]
    public static class ResourceAssetLoaderPatch
    {
        private static bool Prefix(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IResourceAssetLoader>().To<TimberApiResourceAssetLoader>().AsSingleton();
            return false;
        }
    }