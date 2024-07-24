using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class CyclerLeftButton : CyclerLeft<CyclerLeftButton>
    {
        protected override CyclerLeftButton BuilderInstance => this;
    }
    
    public abstract class CyclerLeft<TBuilder> : BaseBuilder<TBuilder, Button>
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
            
            return ButtonBuilder.AddClass("api__button__cycler-left").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__cycler-left", "UI.Click")
                .AddBackgroundHoverClass("api__button__cycler-left", "ui/images/game/cycler-left", "ui/images/game/cycler-left-hover")
                .AddClass("api__button__cycler-left", builder => builder
                    .Add(Property.Width, new Dimension(11, Dimension.Unit.Pixel))
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                );
        }
    }
}