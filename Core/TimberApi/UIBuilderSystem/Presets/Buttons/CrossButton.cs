using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class CrossButton : CrossButton<CrossButton>
    {
        protected override CrossButton BuilderInstance => this;
    }
    
    public abstract class CrossButton<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string ImageClass = "api__button__cross-button--normal";

        protected string SizeClass = "api__button__cross-button--size-normal";
        
        public TBuilder Small()
        {
            SizeClass = "api__button__cross-button--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__cross-button--size-large";
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
            ButtonBuilder.AddClass("api__button__cross-button--active");
            return BuilderInstance;
        }

        public TBuilder Inverted()
        {
            ImageClass = "api__button__cross-button--inverted";
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__cross-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__cross-button", "UI.Click")
                .AddBackgroundClass("api__button__cross-button", "ui/images/buttons/cross-hover", PseudoClass.Hover)
                .AddBackgroundClass("api__button__cross-button--normal", "ui/images/buttons/cross")
                .AddBackgroundClass("api__button__cross-button--inverted", "ui/images/buttons/cross-inverted")
                .AddBackgroundClass("api__button__cross-button--active", "ui/images/buttons/cross-active", PseudoClass.Active, PseudoClass.Hover)

                .AddClass("api__button__cross-button--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cross-button--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cross-button--size-large", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                );
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