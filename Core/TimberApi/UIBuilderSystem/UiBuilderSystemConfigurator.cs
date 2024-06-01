using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using TimberApi.UiBuilderSystem.Presets.Buttons;

namespace TimberApi.UiBuilderSystem
{
    [Configurator(SceneEntrypoint.All)]
    public class UiBuilderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilderOld>().AsSingleton();
            
            containerDefinition.Bind<LabelBuilder>().AsTransient();
            containerDefinition.Bind<SliderBuilder>().AsTransient();

            containerDefinition.Bind<ButtonBuilder>().AsTransient();
            containerDefinition.Bind<LocalizableButtonBuilder>().AsTransient();
            containerDefinition.Bind<VisualElementBuilder>().AsTransient();
            
            containerDefinition.Bind<ScrollViewBuilder>().AsTransient();
            containerDefinition.Bind<StyleSheetBuilder>().AsTransient();
            containerDefinition.Bind<UIBuilder>().AsSingleton();
            containerDefinition.Bind<BuilderStyleSheetCache>().AsSingleton();
        }
    }
}
