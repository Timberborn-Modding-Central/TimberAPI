using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class ClampDownButton : ClampDown<ClampDownButton>
    {
        protected override ClampDownButton BuilderInstance => this;
    }
    
    public abstract class ClampDown<TBuilder> : BaseBuilder<TBuilder, Button>
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
            ButtonBuilder.AddClass("api__button__clamp-down--active");
            return BuilderInstance;
        }
        
        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__clamp-down").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__clamp-down", "UI.Click")
                .AddBackgroundHoverClass("api__button__clamp-down", "ui/images/game/clamp-down", "ui/images/game/clamp-down-hover")
                .AddBackgroundClass("api__button__clamp-down--active", "ui/images/game/clamp-down-active", PseudoClass.Hover, PseudoClass.Active)
                .AddClass("api__button__clamp-down", builder => builder
                    .Add(Property.Width, new Dimension(67, Dimension.Unit.Pixel))
                    .Add(Property.Height, new Dimension(13, Dimension.Unit.Pixel))
                );
        }
    }
}