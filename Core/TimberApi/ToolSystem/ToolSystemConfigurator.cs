using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;
using TimberApi.ToolSystem.Tools.BuilderPriority;
using TimberApi.ToolSystem.Tools.CancelPlanting;
using TimberApi.ToolSystem.Tools.Cursor;
using TimberApi.ToolSystem.Tools.Demolishing;
using TimberApi.ToolSystem.Tools.PlaceableObject;
using TimberApi.ToolSystem.Tools.Planting;
using TimberApi.ToolSystem.Tools.SettingBox;
using TimberApi.ToolSystem.Tools.TreeCuttingArea;

namespace TimberApi.ToolSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolService>().AsSingleton();
            containerDefinition.Bind<ToolIconService>().AsSingleton();
            containerDefinition.Bind<ToolSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<ToolFactoryService>().AsSingleton();
            containerDefinition.Bind<ToolSpecificationService>().AsSingleton();

            containerDefinition.MultiBind<IToolFactory>().To<EntityBlockObjectDeletionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<BuildingDeconstructionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<DemolishableUnselectionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<DemolishableSelectionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<PlantingToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<CursorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<BuilderPriorityToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<TreeCuttingAreaSelectionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<TreeCuttingAreaUnselectionToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<CancelPlantingToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<SettingBoxToolFactory>().AsSingleton();

            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlantingToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<CursorToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<BuilderPriorityToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<TreeCuttingAreaToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<CancelPlantingToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<DemolishingToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<SettingBoxToolGenerator>().AsSingleton();
        }
    }
}