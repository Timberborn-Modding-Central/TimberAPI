using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowDown : ArrowDown<ArrowDown>
    {
        protected override ArrowDown BuilderInstance => this;
    }
    
    public abstract class ArrowDown<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder Builder = null!;
        
        private string _imageClass = "api__button__arrow_down--normal";

        private string _sizeClass = "api__button__arrow_down--size-normal";
        
        public TBuilder Small()
        {
            _sizeClass = "api__button__arrow_down--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            _sizeClass = "api__button__arrow_down--size-large";
            return BuilderInstance;
        }
        
        public TBuilder SetSize(Length size)
        {
            Builder.SetHeight(size);
            Builder.SetWidth(size);
            return BuilderInstance;
        }

        public TBuilder Active()
        {
            Builder.AddClass("api__button__arrow_down--active");
            return BuilderInstance;
        }

        public TBuilder Inverted()
        {
            _imageClass = "api__button__arrow_down--inverted";
            return BuilderInstance;
        }

        protected override Button InitializeRoot()
        {
            Builder = UIBuilder.Create<ButtonBuilder>();
            
            return Builder.AddClass("api__button__arrow_down").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddBackgroundClass("api__button__arrow_down", "ui/images/buttons/arrow-down-hover", PseudoClass.Hover)
                .AddBackgroundClass("api__button__arrow_down--normal", "ui/images/buttons/arrow-down")
                .AddBackgroundClass("api__button__arrow_down--inverted", "ui/images/buttons/arrow-down-inverted")
                .AddBackgroundClass("api__button__arrow_down--active", "ui/images/buttons/arrow-down-active", PseudoClass.Active, PseudoClass.Hover)

                .AddClass("api__button__arrow_down--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_down--size-small", builder => builder
                    .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__arrow_down--size-large", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                );
        }

        public override Button Build()
        {
            return UIBuilder.Create<ButtonBuilder>().Build();
        }
    }
}