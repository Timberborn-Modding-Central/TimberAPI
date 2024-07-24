using Bindito.Core;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;

namespace TimberApi.UIBuilderSystem
{
    [Context("MainMenu")]
    [Context("Game")]
    public class UIBuilderSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
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
