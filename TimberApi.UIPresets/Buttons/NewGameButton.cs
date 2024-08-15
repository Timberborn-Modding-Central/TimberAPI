using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class NewGameButton : ButtonNewGame<NewGameButton>
{
    protected override NewGameButton BuilderInstance => this;
}

public abstract class ButtonNewGame<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
    where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
{
    protected LocalizableButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__button-new-game--easy";

    protected bool IsActive;

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
                .ClickSound("UI.Click")
                .Width(209)
                .Height(92)
                .FontSize(18)
                .Color(Color.white)
            )
            .AddClass("api__button__button-new-game", new[] { PseudoClass.Hover }, builder => builder
                .Color(Color.black)
            )
            .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--easy",
                "ui/images/buttons/difficulty/easy", "ui/images/buttons/difficulty/easy-hover", 64, 0.6f)
            .AddNineSlicedBackgroundClass("api__button__button-new-game--easy--active",
                "ui/images/buttons/difficulty/easy-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active)
            .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--normal",
                "ui/images/buttons/difficulty/normal", "ui/images/buttons/difficulty/normal-hover", 64, 0.6f)
            .AddNineSlicedBackgroundClass("api__button__button-new-game--normal--active",
                "ui/images/buttons/difficulty/normal-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active)
            .AddNineSlicedBackgroundHoverClass("api__button__button-new-game--hard",
                "ui/images/buttons/difficulty/hard", "ui/images/buttons/difficulty/hard-hover", 64, 0.6f)
            .AddNineSlicedBackgroundClass("api__button__button-new-game--hard--active",
                "ui/images/buttons/difficulty/hard-active", 64, 0.6f, PseudoClass.Hover, PseudoClass.Active);
    }

    public TBuilder ModifyRoot(Action<LocalizableButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    public override LocalizableButton Build()
    {
        if (IsActive) ButtonBuilder.AddClass(ImageClass + "--active");

        return ButtonBuilder
            .AddClass(ImageClass)
            .Build();
    }
}