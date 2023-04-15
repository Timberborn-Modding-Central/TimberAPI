using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolGroupSystem.ToolGroups.ConstructionMode;
using TimberApi.ToolGroupSystem.ToolGroups.Default;
using TimberApi.ToolGroupSystem.ToolGroups.PlantingMode;
using TimberApi.ToolGroupSystem.ToolGroups.TreeCuttingArea;

namespace TimberApi.ToolGroupSystem
{
    [Configurator(SceneEntrypoint.InGame)]
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
        }
    }
}