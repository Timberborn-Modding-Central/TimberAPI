using Bindito.Core;
using TimberApi.SpecificationSystem;
using TimberApi.Tools.ToolGroupSystem.ToolGroups.BuilderPriority;
using TimberApi.Tools.ToolGroupSystem.ToolGroups.ConstructionMode;
using TimberApi.Tools.ToolGroupSystem.ToolGroups.Default;
using TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;
using TimberApi.Tools.ToolGroupSystem.ToolGroups.TreeCuttingArea;

namespace TimberApi.Tools.ToolGroupSystem;

[Context("Game")]
[Context("MapEditor")]
public class ToolGroupConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<ToolGroupSpecificationService>().AsSingleton();
        containerDefinition.Bind<ToolGroupSpecificationDeserializer>().AsSingleton();
        containerDefinition.Bind<ToolGroupService>().AsSingleton();
        containerDefinition.Bind<ToolGroupFactoryService>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupFactory>().To<ConstructionModeToolGroupFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupFactory>().To<DefaultToolGroupFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupFactory>().To<PlantingModeToolGroupFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupFactory>().To<TreeCuttingAreaToolGroupFactory>().AsSingleton();
        containerDefinition.MultiBind<IToolGroupFactory>().To<BuilderPriorityToolGroupFactory>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<TimberbornGroupGenerator>().AsSingleton();
    }
}