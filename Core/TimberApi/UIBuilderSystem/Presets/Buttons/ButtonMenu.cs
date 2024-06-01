using TimberApi.StyleSheetSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ButtonMenu : ButtonMenu<ButtonMenu>
    {
        protected override ButtonMenu BuilderInstance => this;
    }
    
    public abstract class ButtonMenu<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
        where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
    {
        protected LocalizableButtonBuilder ButtonBuilder = null!;
        
        protected string SizeClass = "api__button__menu-button--size-normal";
        
        public TBuilder SetLocKey(string locKey)
        {
            ButtonBuilder.SetLocKey(locKey);
            return BuilderInstance;
        }
        
        public TBuilder Medium()
        {
            SizeClass = "api__button__menu-button--size-medium";
            return BuilderInstance;
        }
        
        public TBuilder SetWidth(Length width)
        {
            ButtonBuilder.SetWidth(width);
            return BuilderInstance;
        }
        
        public TBuilder SetHeight(Length height)
        {
            ButtonBuilder.SetHeight(height);
            return BuilderInstance;
        }
        
        protected override LocalizableButton InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<LocalizableButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__menu-button").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClass("api__button__menu-button", builder => builder
                    .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                    .AddNineSlicedBackgroundImage("ui/images/buttons/button", 0, 65, 0, 65, 0.5f)
                    .Add(Property.UnityFontStyle, "bold", StyleValueType.Enum)
                    .Add(Property.Color, "white", StyleValueType.Enum)
                )
                .AddClass("api__button__menu-button", new [] { PseudoClass.Hover }, builder => builder
                    .AddNineSlicedBackgroundImage("ui/images/buttons/button-hover", 0, 65, 0, 65, 0.5f)
                    .Add(Property.Color, "black", StyleValueType.Enum)
                )
                
                .AddClass("api__button__menu-button--size-normal", builder => builder
                    .Add(Property.Height, new Dimension(44, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(245, Dimension.Unit.Pixel))
                    .Add(Property.FontSize, new Dimension(14, Dimension.Unit.Pixel))
                )
                .AddClass("api__button__menu-button--size-medium", builder => builder
                    .Add(Property.Height, new Dimension(33, Dimension.Unit.Pixel))
                    .Add(Property.Width, new Dimension(245, Dimension.Unit.Pixel))
                    .Add(Property.FontSize, new Dimension(13, Dimension.Unit.Pixel))
                );
        }

        public override LocalizableButton Build()
        {
            return ButtonBuilder
                .AddClass(SizeClass)
                .Build();
        }
    }
}