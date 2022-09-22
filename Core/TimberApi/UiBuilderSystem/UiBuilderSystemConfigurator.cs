using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.UiBuilderSystem.PresetSystem;

namespace TimberApi.UiBuilderSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class UiBuilderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilder>().AsSingleton();
            containerDefinition.Bind<ComponentBuilder>().AsSingleton();
            containerDefinition.Bind<UiPresetFactory>().AsSingleton();
        }
    }
}