using Bindito.Core;
using HarmonyLib;
using TimberApi.Common.SingletonSystem.Singletons;
using Timberborn.AssetSystem;

namespace TimberApi.New.ResourceAssetSystem
{
    public class AssetSystemConfiguratorPatcher : ITimberApiLoadableSingleton
    {
        public void Load()
        {
            Harmony harmony = new Harmony("TimberApi.AssetLoaderPatcher");
            harmony.Patch(
                original: AccessTools.Method(typeof(AssetSystemConfigurator), nameof(AssetSystemConfigurator.Configure)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(AssetSystemConfiguratorPatcher), nameof(AssetSystemConfiguratorPatch)))
            );
        }

        private static bool AssetSystemConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IResourceAssetLoader>().To<ResourceAssetLoader>().AsSingleton();
            return false;
        }
    }
}