using Bindito.Core;
using TimberApi.New.AssetSystem;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.LocalizationSystem;
using TimberApi.New.ResourceAssetSystem;
using TimberApi.New.SceneSystem;
using TimberApi.New.SpecificationSystem;
using TimberApi.New.SpecificationSystem.CustomSpecifications.Golems;

namespace TimberApi.New
{
    internal class BootstrapConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApi>().AsSingleton();
            containerDefinition.Bind<SceneListener>().AsSingleton();
            containerDefinition.Install(new ConfiguratorSystemConfigurator());
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
            containerDefinition.Install(new SpecificationGlobalConfigurator());
            containerDefinition.Install(new GolemFactionPatchConfigurator());
            containerDefinition.Install(new ResourceAssetSystemConfigurator());
            containerDefinition.Install(new LocalizationConfigurator());
        }
    }
}