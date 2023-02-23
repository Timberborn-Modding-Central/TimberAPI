using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
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
}