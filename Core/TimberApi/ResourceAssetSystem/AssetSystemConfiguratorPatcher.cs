using Bindito.Core;
using HarmonyLib;
using TimberApi.HarmonyPatcherSystem;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.ResourceAssetSystem
{
    internal class AssetSystemConfiguratorPatcher : BaseHarmonyPatcher
    {
        public override string UniqueId => "TimberApi.AssetLoaderPatcher";

        public override void Apply(Harmony harmony)
        {
            harmony.Patch(
                GetMethodInfo<AssetSystemConfigurator>(nameof(AssetSystemConfigurator.Configure)),
                GetHarmonyMethod(nameof(AssetSystemConfiguratorPatch))
            );
        }

        private static bool AssetSystemConfiguratorPatch(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IResourceAssetLoader>().To<ResourceAssetLoader>().AsSingleton();
            return false;
        }
    }
}