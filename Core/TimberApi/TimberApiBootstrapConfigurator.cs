using Bindito.Core;
using TimberApi.AssetSystem;
using TimberApi.HarmonyPatcherSystem;
using TimberApi.SpecificationSystem.CustomSpecifications.Golems;

namespace TimberApi
{
    internal class BootstrapConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            PreLoadSystems();

            containerDefinition.Bind<TimberApi>().AsSingleton();
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
            containerDefinition.Install(new GolemFactionPatchConfigurator());
        }

        private static void PreLoadSystems()
        {
            new HarmonyPatcherActivator().PatchAll();
        }
    }
}