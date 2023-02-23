using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;
using TimberApi.ToolSystem.Factories.PlaceableObjectTool;
using TimberApi.ToolSystem.Tools.PlaceableObjectTool;

namespace TimberApi.ToolSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<ToolFactoryRepository>().AsSingleton();
            containerDefinition.Bind<ToolSpecificationRepository>().AsSingleton();
            containerDefinition.MultiBind<IToolFactory>().To<PlaceableObjectToolFactory>().AsSingleton();
            containerDefinition.MultiBind<ISpecificationGenerator>().To<PlaceableObjectToolGenerator>().AsSingleton();
        }
    }
}