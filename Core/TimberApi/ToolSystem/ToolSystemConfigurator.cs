using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.ToolSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolService>().AsSingleton();
            containerDefinition.Bind<ToolIconService>().AsSingleton();
            containerDefinition.Bind<ToolSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<ToolFactoryService>().AsSingleton();
            containerDefinition.Bind<ToolSpecificationService>().AsSingleton();
        }
    }
}