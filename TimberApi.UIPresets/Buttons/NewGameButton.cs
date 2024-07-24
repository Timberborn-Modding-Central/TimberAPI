using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons
{
    public class NewGameButton : ButtonNewGame<NewGameButton>
    {
        protected override NewGameButton BuilderInstance => this;
    }
    
    public abstract class ButtonNewGame<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
        where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
    {
        protected LocalizableButtonBuilder ButtonBuilder = null!;
        
        protected string ImageClass = "api__button__button-new-game--easy";

        protected bool IsActive = false;
        
        public TBuilder Active()
        {
            IsActive = true;
            return BuilderInstance;
        }
        
        public TBuilder Easy()
        {
            ImageClass = "api__button__button-new-game--easy";
            return BuilderInstance;
        }
        
        public TBuilder Normal()
        {
            ImageClass = "api__button__button-new-game--normal";
            return BuilderInstance;
        }
        
        public TBuilder Hard()
        {
            ImageClass = "api__button__button-new-game--hard";
            return BuilderInstance;
        }
        
        public TBuilder SetLocKey(string locKey)
        {
            ButtonBuilder.SetLocKey(locKey);
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
        
        public TBuilder SetFontSize(Length size)
        {
            ButtonBuilder.SetFontSize(size);
            return BuilderInstance;
        }
        
        public TBuilder SetFontStyle(FontStyle style)
        {
            ButtonBuilder.SetFontStyle(style);
            return BuilderInstance;
        }
        
        public TBuilder SetColor(StyleColor color)
        {
            ButtonBuilder.SetColor(color);
            return BuilderInstance;
        }
        
        protected override LocalizableButton InitializeRoot()
        {
            ButtonBuilder = UIBuilder.Create<LocalizableButtonBuilder>();
            
            return ButtonBuilder.AddClass("api__button__button-new-game").Build();
        }

        protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
        {
            styleSheetBuilder
                .AddClass("api__button__button-new-game", builder => builder
                    .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                    .Add(Property.Width, new Dimension(209, Dimension.Unit.Pixel))
                    .Add(Property.Height, new Dimension(92, Dimension.Unit.Pixel))
                    .Add(Property.FontSize, new Dimension(18, Dimension.Unit.Pixel))
                    .Add(Property.Color, "white", StyleValueType.Enum)
                )
                .AddClass("api__button__button-new-game", new [] { PseudoClass.Hover }, builder => builder
                    .Add(Property.Color, "black", StyleValueType.Enum)
                )
                .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--easy", "ui/images/buttons/difficulty/easy", "ui/images/buttons/difficulty/easy-hover", 64, 0.6f)
                .AddNineSlicedBackgroundClass("api__button__button-new-game--easy--active", "ui/images/buttons/difficulty/easy-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active)
            
                .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--normal", "ui/images/buttons/difficulty/normal", "ui/images/buttons/difficulty/normal-hover", 64, 0.6f)
                .AddNineSlicedBackgroundClass("api__button__button-new-game--normal--active", "ui/images/buttons/difficulty/normal-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active)

                .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--hard", "ui/images/buttons/difficulty/hard", "ui/images/buttons/difficulty/hard-hover", 64, 0.6f)
                .AddNineSlicedBackgroundClass("api__button__button-new-game--hard--active", "ui/images/buttons/difficulty/hard-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active);
        }

        public override LocalizableButton Build()
        {
            if (IsActive)
            {
                ButtonBuilder.AddClass(ImageClass + "--active");
            }
            
            return ButtonBuilder
                .AddClass(ImageClass)
                .Build();
        }
    }
}