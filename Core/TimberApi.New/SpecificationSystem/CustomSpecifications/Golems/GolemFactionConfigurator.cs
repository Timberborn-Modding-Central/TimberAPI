using Bindito.Core;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Golems
{
    [Configurator(SceneEntrypoint.InGame)]
    internal class GolemFactionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ISpecificationGenerator>().To<GolemSpecificationGenerator>().AsSingleton();
            containerDefinition.Bind<GolemFactionService>().AsSingleton();
            containerDefinition.Bind<GolemFactionSpecificationObjectDeserializer>().AsSingleton();
        }
    }

    internal class GolemFactionPatchConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<GolemFactionPatcher>().AsSingleton();
        }
    }
}