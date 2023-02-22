using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.ToolGroupUISystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class ToolGroupUIConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ToolGroupButtonVisualiserService>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonVisualiser>().To<ToolGroupButtonRedVisualiser>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonVisualiser>().To<ToolGroupButtonBlueVisualiser>().AsSingleton();
            containerDefinition.MultiBind<IToolGroupButtonVisualiser>().To<ToolGroupButtonGreenVisualiser>().AsSingleton();
        }
    }
}