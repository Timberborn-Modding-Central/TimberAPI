using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.SingletonSystem;
using Timberborn.AssetSystem;

namespace TimberApi.ResourceAssetSystem
{
    internal class AssetSystemConfiguratorPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            var harmony = new Harmony("TimberApi.AssetLoaderPatcher");
            harmony.Patch(AccessTools.Method(typeof(AssetSystemConfigurator), nameof(AssetSystemConfigurator.Configure)),
                new HarmonyMethod(AccessTools.Method(typeof(AssetSystemConfiguratorPatcher), nameof(AssetSystemConfiguratorPatch))));
        }

        private static bool AssetSystemConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IResourceAssetLoader>().To<ResourceAssetLoader>().AsSingleton();
            return false;
        }
    }
}