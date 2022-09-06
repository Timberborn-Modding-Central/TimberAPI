using Bindito.Core;
using TimberApi.New.Common;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;

namespace TimberApi.New.UiBuilderSystem
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