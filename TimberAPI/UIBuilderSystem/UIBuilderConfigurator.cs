using Bindito.Core;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilderConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBoxBuilder>().To<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilder>().To<UIBuilder>().AsSingleton();
            containerDefinition.Bind<ElementFactory>().To<ElementFactory>().AsSingleton();
            containerDefinition.Bind<ComponentBuilder>().AsSingleton();
            containerDefinition.Bind<UiPresetFactory>().AsSingleton();
        }
    }
}