using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ClampUp : ClampUp<ClampUp>
    {
        protected override ClampUp BuilderInstance => this;
    }
    
    public abstract class ClampUp<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        public TBuilder SetSize(Length size)
        {
            ButtonBuilder.SetHeight(size);
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        public TBuilder Active()
        {
            ButtonBuilder.AddClass("api__button__clamp-up--active");
            return BuilderInstance;
        }
        
        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__clamp-up").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__clamp-up", "UI.Click")
                .AddBackgroundHoverClass("api__button__clamp-up", "ui/images/game/clamp-up", "ui/images/game/clamp-up-hover")
                .AddBackgroundClass("api__button__clamp-up--active", "ui/images/game/clamp-up-active", PseudoClass.Hover, PseudoClass.Active)
                .AddClass("api__button__clamp-up", builder => builder
                    .Add(Property.Width, new Dimension(94, Dimension.Unit.Pixel))
                    .Add(Property.Height, new Dimension(16, Dimension.Unit.Pixel))
                );
        }
    }
}