using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

[Context("Game")]
public class PlantingToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<PlantingToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<PlantingToolGenerator>().AsSingleton();
    }
}