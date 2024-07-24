using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class CyclerMainRightButton : CyclerMainRight<CyclerMainRightButton>
    {
        protected override CyclerMainRightButton BuilderInstance => this;
    }
    
    public abstract class CyclerMainRight<TBuilder> : BaseBuilder<TBuilder, Button>
        where TBuilder : BaseBuilder<TBuilder, Button>
    {
        protected ButtonBuilder ButtonBuilder = null!;
        
        protected string SizeClass = "api__button__cycler-main-right--size-normal";
        
        public TBuilder Small()
        {
            SizeClass = "api__button__cycler-main-right--size-small";
            return BuilderInstance;
        }
        
        public TBuilder Large()
        {
            SizeClass = "api__button__cycler-main-right--size-large";
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
            
            return ButtonBuilder.AddClass("api__button__cycler-main-right").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClickSoundClass("api__button__cycler-main-right", "UI.Click")
                .AddBackgroundHoverClass("api__button__cycler-main-right", "ui/images/buttons/cycler_right", "ui/images/buttons/cycler_right_hover")
                .AddClass("api__button__cycler-main-right--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cycler-main-right--size-small", builder => builder
                    .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__cycler-main-right--size-large", builder => builder
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