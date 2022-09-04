using Bindito.Core;
using TimberApi.Core2.Common;
using TimberApi.Core2.ConfiguratorSystem;
using TimberApi.Internal.UiBuilderSystem.PresetSystem;

namespace TimberApi.Internal.UiBuilderSystem
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