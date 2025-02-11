using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

[Context("Game")]
public class BuilderPriorityToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<BuilderPriorityToolFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<BuilderPriorityToolGenerator>().AsSingleton();
    }
}