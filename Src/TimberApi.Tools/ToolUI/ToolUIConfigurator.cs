using Bindito.Core;

namespace TimberApi.Tools.ToolUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolUIConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolButtonFactory>().AsSingleton();
    }
}