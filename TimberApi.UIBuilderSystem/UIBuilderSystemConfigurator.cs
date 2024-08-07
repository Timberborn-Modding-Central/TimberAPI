using Bindito.Core;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;

namespace TimberApi.UIBuilderSystem;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class UIBuilderSystemConfigurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<LabelBuilder>().AsTransient();
        containerDefinition.Bind<LocalizableLabelBuilder>().AsTransient();
        
        containerDefinition.Bind<SliderIntBuilder>().AsTransient();
        containerDefinition.Bind<LocalizableSliderIntBuilder>().AsTransient();

        containerDefinition.Bind<SliderBuilder>().AsTransient();
        containerDefinition.Bind<LocalizableSliderBuilder>().AsTransient();
        
        containerDefinition.Bind<ToggleBuilder>().AsTransient();
        containerDefinition.Bind<LocalizableToggleBuilder>().AsTransient();

        
        containerDefinition.Bind<ButtonBuilder>().AsTransient();
        containerDefinition.Bind<LocalizableButtonBuilder>().AsTransient();
        containerDefinition.Bind<VisualElementBuilder>().AsTransient();
        containerDefinition.Bind<ScrollViewBuilder>().AsTransient();
        containerDefinition.Bind<ListViewBuilder>().AsTransient();
        containerDefinition.Bind<TextFieldBuilder>().AsTransient();

        containerDefinition.Bind<StyleSheetBuilder>().AsTransient();
        containerDefinition.Bind<UIBuilder>().AsSingleton();
        containerDefinition.Bind<BuilderStyleSheetCache>().AsSingleton();
    }
}