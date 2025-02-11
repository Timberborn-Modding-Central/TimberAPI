using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

[Context("Game")]
public class DemolishingToolConfigurator : Configurator
{
    protected override void Configure()
    {
        MultiBind<IToolFactory>().To<DemolishableUnselectionToolFactory>().AsSingleton();
        MultiBind<IToolFactory>().To<DemolishableSelectionToolFactory>().AsSingleton();
        MultiBind<IToolFactory>().To<EntityBlockObjectDeletionToolFactory>().AsSingleton();
        MultiBind<IToolFactory>().To<BuildingDeconstructionToolFactory>().AsSingleton();
        MultiBind<IToolFactory>().To<DeleteRubbleToolFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<DemolishingToolGenerator>().AsSingleton();
    }
}