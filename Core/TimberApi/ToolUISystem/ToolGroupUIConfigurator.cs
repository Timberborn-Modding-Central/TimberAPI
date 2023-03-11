using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolUISystem.Factories;

namespace TimberApi.ToolUISystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolGroupUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolButtonFactoryService>().AsSingleton();
            containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonBlueFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonRedFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonGreenFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolButtonFactory>().To<ToolButtonBrownFactory>().AsSingleton();
        }
    }
}