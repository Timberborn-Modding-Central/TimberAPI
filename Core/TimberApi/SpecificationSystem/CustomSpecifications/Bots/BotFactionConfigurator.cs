using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Bots
{
    [Configurator(SceneEntrypoint.InGame)]
    internal class BotFactionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<BotSpecificationGenerator>().AsSingleton();
            containerDefinition.Bind<BotFactionService>().AsSingleton();
            containerDefinition.Bind<BotFactionSpecificationObjectDeserializer>().AsSingleton();
        }
    }
}