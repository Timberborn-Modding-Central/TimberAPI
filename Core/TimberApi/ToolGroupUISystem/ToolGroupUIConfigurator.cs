using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolGroupUISystem.Factories;

namespace TimberApi.ToolGroupUISystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolGroupUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolGroupButtonFactoryService>().AsSingleton();
            containerDefinition.Bind<ToolGroupButtonFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonRedFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBrownFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonBlueFactory>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonFactory>().To<ToolGroupButtonGreenFactory>().AsSingleton();
        }
    }
}