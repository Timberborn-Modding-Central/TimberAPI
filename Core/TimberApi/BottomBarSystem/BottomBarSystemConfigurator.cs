using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace TimberApi.BottomBarSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class BottomBarSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // containerDefinition.Bind<BottomBarPanel>().AsSingleton();
            // containerDefinition.Bind<BottomBarUiService>().AsSingleton();
            // containerDefinition.Bind<BottomBarService>().AsSingleton();
            // containerDefinition.Bind<ToolGroupButtonPatcher>().AsSingleton();
            // containerDefinition.Bind<BottomBarToolGroupSpecificationDeserializer>().AsSingleton();
        }
    }
}