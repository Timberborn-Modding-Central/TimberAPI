using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.UiBuilderSystem.PresetSystem;

namespace TimberApi.UiBuilderSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class UIBuilderConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBoxBuilder>().To<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilder>().To<UIBuilder>().AsSingleton();
            containerDefinition.Bind<ComponentBuilder>().AsSingleton();
            containerDefinition.Bind<UiPresetFactory>().AsSingleton();
        }
    }
}