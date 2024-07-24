using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class CloseButton : CloseButton<CloseButton>
    {
        protected override CloseButton BuilderInstance => this;
    }
    
    public abstract class CloseButton<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        public TBuilder SetSize(Length size)
        {
            ButtonBuilder.SetHeight(size);
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__close-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__close-button", "UI.Cancel")
                .AddBackgroundHoverClass("api__button__close-button", "ui/images/buttons/close", "ui/images/buttons/close_hover")
                .AddClass("api__button__close-button", builder => builder
                    .Add(Property.Height, new Dimension(40, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(40, Dimension.Unit.Pixel))
                );
        }
    }
}