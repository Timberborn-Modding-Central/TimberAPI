using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowLeft : ArrowLeft<ArrowLeft>
    {
        protected override ArrowLeft BuilderInstance => this;
    }
    
    public abstract class ArrowLeft<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;

        protected string ImageClass = "api__button__arrow_left--normal";

        protected string SizeClass = "api__button__arrow_left--size-normal";
        
        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__arrow_left", "UI.Click")
                .AddBackgroundClass("api__button__arrow_left", "ui/images/buttons/arrow-left-hover", PseudoClass.Hover)
                .AddBackgroundClass("api__button__arrow_left--normal", "ui/images/buttons/arrow-left")
                .AddBackgroundClass("api__button__arrow_left--inverted", "ui/images/buttons/arrow-left-inverted")
                .AddBackgroundClass("api__button__arrow_left--active", "ui/images/buttons/arrow-left-active", PseudoClass.Active, PseudoClass.Hover)

                .AddClass("api__button__arrow_left--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_left--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_left--size-large", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                );
        }
        
        public TBuilder Small()
        {
            SizeClass = "api__button__arrow_left--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__arrow_left--size-large";
            return BuilderInstance;
        }
        
        public TBuilder SetSize(Length size)
        {
            ButtonBuilder.SetHeight(size);
            ButtonBuilder.SetWidth(size);
            return BuilderInstance;
        }

        public TBuilder Active()
        {
            ButtonBuilder.AddClass("api__button__arrow_left--active");
            return BuilderInstance;
        }

        public TBuilder Inverted()
        {
            ImageClass = "api__button__arrow_left--inverted";
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__arrow_left").Build();
        }
        

        public override Button Build()
        {
            return ButtonBuilder
                .AddClass(ImageClass)
                .AddClass(SizeClass)
                .Build();
        }
    }
}