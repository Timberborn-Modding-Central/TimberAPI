using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

[Context("Game")]
public class DemolishingToolConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.MultiBind<IToolFactory>().To<DemolishableUnselectionToolFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolFactory>().To<DemolishableSelectionToolFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolFactory>().To<EntityBlockObjectDeletionToolFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolFactory>().To<BuildingDeconstructionToolFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolFactory>().To<DeleteRubbleToolFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<DemolishingToolGenerator>().AsSingleton();
    }
}