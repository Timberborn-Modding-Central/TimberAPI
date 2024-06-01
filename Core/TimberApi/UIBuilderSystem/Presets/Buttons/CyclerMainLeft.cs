using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class CyclerMainLeft : CyclerMainLeft<CyclerMainLeft>
    {
        protected override CyclerMainLeft BuilderInstance => this;
    }
    
    public abstract class CyclerMainLeft<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string SizeClass = "api__button__cycler-main-left--size-normal";
        
        public TBuilder Small()
        {
            SizeClass = "api__button__cycler-main-left--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__cycler-main-left--size-large";
            return BuilderInstance;
        }
        
        public TBuilder SetSize(Length size)
        {
            ButtonBuilder.SetHeight(size);
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__cycler-main-left").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__cycler-main-left", "UI.Click")
                .AddBackgroundHoverClass("api__button__cycler-main-left", "ui/images/buttons/cycler_left", "ui/images/buttons/cycler_left_hover")
                .AddClass("api__button__cycler-main-left--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cycler-main-left--size-small", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cycler-main-left--size-large", builder => builder
                    .Add(Property.Height, new Dimension(26, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(26, Dimension.Unit.Pixel))
                );
        }

        public override Button Build()
        {
            return ButtonBuilder
                .AddClass(SizeClass)
                .Build();
        }
    }
}