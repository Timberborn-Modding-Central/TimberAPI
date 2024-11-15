using Bindito.Core;
using TimberApi.SpecificationSystem;
using TimberApi.Tools.ToolSystem.Tools.Planting;

namespace TimberApi.Tools.ToolSystem.Tools.GenericTool;

[Context("Game")]
public class GenericToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<GenericToolFactory>().AsSingleton();
    }
}