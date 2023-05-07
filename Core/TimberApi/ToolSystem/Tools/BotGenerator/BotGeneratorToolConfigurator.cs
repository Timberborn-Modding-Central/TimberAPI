using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi.ToolSystem.Tools.BotGenerator
{
    [Configurator(SceneEntrypoint.InGame)]
    public class BotGeneratorToolConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IToolFactory>().To<BotGeneratorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<BotGeneratorToolGenerator>().AsSingleton();
        }
    }
}