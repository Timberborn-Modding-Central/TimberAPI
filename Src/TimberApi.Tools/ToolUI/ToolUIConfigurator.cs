using Bindito.Core;

namespace TimberApi.Tools.ToolUI;

[Context("Game")]
[Context("MapEditor")]
public class ToolUIConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolButtonFactory>().AsSingleton();
    }
}