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
public class ToolGroupConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<ToolGroupSpecService>().AsSingleton();
        Bind<ToolGroupService>().AsSingleton();
        Bind<ToolGroupFactoryService>().AsSingleton();
        MultiBind<IToolGroupFactory>().To<ConstructionModeToolGroupFactory>().AsSingleton();
        MultiBind<IToolGroupFactory>().To<DefaultToolGroupFactory>().AsSingleton();
        MultiBind<IToolGroupFactory>().To<PlantingModeToolGroupFactory>().AsSingleton();
        MultiBind<IToolGroupFactory>().To<TreeCuttingAreaToolGroupFactory>().AsSingleton();
        MultiBind<IToolGroupFactory>().To<BuilderPriorityToolGroupFactory>().AsSingleton();
        MultiBind<ISpecGenerator>().To<TimberbornGroupGenerator>().AsSingleton();
        MultiBind<ISpecGenerator>().To<ToolGroupSpecConvertGenerator>().AsSingleton();
    }
}