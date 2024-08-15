using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

namespace TimberApi.UIPresets.Buttons;

public class GameButton : ButtonGame<GameButton>
{
    protected override GameButton BuilderInstance => this;
}

public abstract class ButtonGame<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
    where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
{
    protected LocalizableButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__game-button--normal";

    public TBuilder District()
    {
        ImageClass = "api__button__game-button--district";
        return BuilderInstance;
    }

    public TBuilder Highlight()
    {
        ImageClass = "api__button__game-button--highlight";
        return BuilderInstance;
    }

    public TBuilder Destructive()
    {
        ImageClass = "api__button__game-button--destructive";
        return BuilderInstance;
    }

    public TBuilder Active()
    {
        ButtonBuilder.AddClass("api__button__game-button--active");
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

        return ButtonBuilder.AddClass("api__button__game-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__button__game-button", builder => builder
                .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                .Add(Property.Color, "white", StyleValueType.Enum)
            )
            .AddNineSlicedBackgroundClass("api__button__game-button", "ui/images/buttons/button-game-hover", 24, 0.5f,
                PseudoClass.Hover)
            .AddNineSlicedBackgroundClass("api__button__game-button--normal", "ui/images/buttons/button-game", 24, 0.5f)
            .AddNineSlicedBackgroundClass("api__button__game-button--highlight",
                "ui/images/buttons/button-game-highlight", 24, 0.5f)
            .AddNineSlicedBackgroundClass("api__button__game-button--district",
                "ui/images/buttons/button-game-district", 24, 0.5f)
            .AddNineSlicedBackgroundClass("api__button__game-button--destructive",
                "ui/images/buttons/button-game-disabled", 24, 0.5f)
            .AddNineSlicedBackgroundClass("api__button__game-button--active", "ui/images/buttons/button-game-active",
                24, 0.5f, PseudoClass.Hover, PseudoClass.Active);
    }

    public TBuilder ModifyRoot(Action<LocalizableButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    public override LocalizableButton Build()
    {
        return ButtonBuilder
            .AddClass(ImageClass)
            .Build();
    }
}