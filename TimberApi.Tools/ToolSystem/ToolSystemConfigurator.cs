using Bindito.Core;

namespace TimberApi.Tools.ToolSystem;

[Context("Game")]
[Context("MapEditor")]
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