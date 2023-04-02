using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;
using TimberApi.ToolSystem.Tools.CursorTool;
using TimberApi.ToolSystem.Tools.PlaceableObjectTool;
using TimberApi.ToolSystem.Tools.PlantingTool;

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
            containerDefinition.MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<PlantingToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<CursorToolFactory>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<PlantingToolGenerator>().AsSingleton();
            containerDefinition.MultiBind<IObjectSpecificationGenerator>().To<CursorToolGenerator>().AsSingleton();
        }
    }
}