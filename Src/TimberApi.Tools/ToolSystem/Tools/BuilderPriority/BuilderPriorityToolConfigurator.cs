using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

[Context("Game")]
public class BuilderPriorityToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<BuilderPriorityToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<BuilderPriorityToolGenerator>().AsSingleton();
    }
}