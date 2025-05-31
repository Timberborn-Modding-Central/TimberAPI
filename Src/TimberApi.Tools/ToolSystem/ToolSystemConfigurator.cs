using Bindito.Core;

namespace TimberApi.Tools.ToolSystem;

[Context("Game")]
// [Context("MapEditor")]
public class ToolSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolService>().AsSingleton();
        Bind<ToolFactoryService>().AsSingleton();
        Bind<ToolSpecService>().AsSingleton();
    }
}