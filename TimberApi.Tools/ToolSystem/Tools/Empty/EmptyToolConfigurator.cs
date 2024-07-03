using Bindito.Core;

namespace TimberApi.Tools.ToolSystem.Tools.Empty;

[Context("Game")]
public class EmptyToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<EmptyToolFactory>().AsSingleton();
    }
}