using Bindito.Core;

namespace TimberApi.Tools.ToolSystem;

[Context("Game")]
[Context("MapEditor")]
public class ToolSystemConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolService>().AsSingleton();
        containerDefinition.Bind<ToolFactoryService>().AsSingleton();
        containerDefinition.Bind<ToolSpecService>().AsSingleton();
    }
}