using Bindito.Core;
using TimberApi.AssetSystem;
using TimberApi.ConfiguratorSystem;
using TimberApi.LocalizationSystem;
using TimberApi.ResourceAssetSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.CustomSpecifications.Golems;

namespace TimberApi
{
    internal class BootstrapConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApi>().AsSingleton();
            containerDefinition.Bind<SceneListener>().AsSingleton();
            containerDefinition.Install(new ConfiguratorSystemConfigurator());
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
            containerDefinition.Install(new SpecificationSystemGlobalConfigurator());
            containerDefinition.Install(new GolemFactionPatchConfigurator());
            containerDefinition.Install(new ResourceAssetSystemConfigurator());
            containerDefinition.Install(new LocalizationSystemConfigurator());
        }
    }
}