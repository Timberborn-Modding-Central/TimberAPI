using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

[Context("Game")]
public class CancelPlantingToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<CancelPlantingToolFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<CancelPlantingToolGenerator>().AsSingleton();
    }
}