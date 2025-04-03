using Bindito.Core;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;

namespace TimberApi.UIBuilderSystem;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class UIBuilderSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<LabelBuilder>().AsTransient();
        Bind<LocalizableLabelBuilder>().AsTransient();
        
        Bind<SliderIntBuilder>().AsTransient();
        Bind<LocalizableSliderIntBuilder>().AsTransient();

        Bind<SliderBuilder>().AsTransient();
        Bind<LocalizableSliderBuilder>().AsTransient();
        
        Bind<MinMaxSliderBuilder>().AsTransient();
        Bind<LocalizableMinMaxSliderBuilder>().AsTransient();
        
        Bind<ToggleBuilder>().AsTransient();
        Bind<LocalizableToggleBuilder>().AsTransient();

        Bind<DropDownBuilder>().AsTransient();
        
        
        Bind<ButtonBuilder>().AsTransient();
        Bind<LocalizableButtonBuilder>().AsTransient();
        Bind<VisualElementBuilder>().AsTransient();
        Bind<ScrollViewBuilder>().AsTransient();
        Bind<ListViewBuilder>().AsTransient();
        Bind<TextFieldBuilder>().AsTransient();

        Bind<UIBuilder>().AsSingleton();
        Bind<BuilderStyleSheetCache>().AsSingleton();
    }
}