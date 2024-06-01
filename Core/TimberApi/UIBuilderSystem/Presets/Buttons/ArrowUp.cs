using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowUp : ArrowUp<ArrowUp>
    {
        protected override ArrowUp BuilderInstance => this;
    }
    
    public abstract class ArrowUp<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string ImageClass = "api__button__arrow_up--normal";

        protected string SizeClass = "api__button__arrow_up--size-normal";
        
        public TBuilder Small()
        {
            SizeClass = "api__button__arrow_up--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__arrow_up--size-large";
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
            ButtonBuilder.AddClass("api__button__arrow_up--active");
            return BuilderInstance;
        }

        public TBuilder Inverted()
        {
            ImageClass = "api__button__arrow_up--inverted";
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<ButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__arrow_up").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__arrow_up", "UI.Click")
                .AddBackgroundClass("api__button__arrow_up", "ui/images/buttons/arrow-up-hover", PseudoClass.Hover)
                .AddBackgroundClass("api__button__arrow_up--normal", "ui/images/buttons/arrow-up")
                .AddBackgroundClass("api__button__arrow_up--inverted", "ui/images/buttons/arrow-up-inverted")
                .AddBackgroundClass("api__button__arrow_up--active", "ui/images/buttons/arrow-up-active", PseudoClass.Active, PseudoClass.Hover)

                .AddClass("api__button__arrow_up--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_up--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_up--size-large", builder => builder
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