using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

[Context("Game")]
public class TreeCuttingAreaToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<ISpecificationGenerator>().To<TreeCuttingAreaToolGenerator>().AsSingleton();
    }
}