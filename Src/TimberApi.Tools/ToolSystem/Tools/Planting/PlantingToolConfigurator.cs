using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

[Context("Game")]
public class PlantingToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<PlantingToolFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<PlantingToolGenerator>().AsSingleton();
    }
}