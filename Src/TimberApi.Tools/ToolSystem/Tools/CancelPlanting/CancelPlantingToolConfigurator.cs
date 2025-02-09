using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

[Context("Game")]
public class CancelPlantingToolConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<CancelPlantingToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<CancelPlantingToolGenerator>().AsSingleton();
    }
}