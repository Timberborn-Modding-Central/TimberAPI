using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.CustomElements;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
using LocalizableButtonBuilder = TimberApi.UIBuilderSystem.ElementBuilders.LocalizableButtonBuilder;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class WideButton : WideButton<WideButton>
{
    protected override WideButton BuilderInstance => this;
}

public abstract class WideButton<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
    where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
{
    protected LocalizableButtonBuilder ButtonBuilder = null!;

    public TBuilder SetLocKey(string locKey)
    {
        ButtonBuilder.SetLocKey(locKey);
        return BuilderInstance;
    }

    public TBuilder SetWidth(Length size)
    {
        ButtonBuilder.SetWidth(size);
        return BuilderInstance;
    }

    public TBuilder SetHeight(Length size)
    {
        ButtonBuilder.SetHeight(size);
        return BuilderInstance;
    }

    public TBuilder Active()
    {
        ButtonBuilder.AddClass("api__button__wide-button--active");
        return BuilderInstance;
    }

    protected override LocalizableButton InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<LocalizableButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__wide-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__button__wide-button", builder => builder
                .NineSlicedBackgroundImage("ui/images/buttons/wide", 20, 0.5f)
                .Color(Color.white)
                .ClickSound("UI.Click")
                .Height(32)
                .MinWidth(130)
            )
            .AddClass("api__button__wide-button", new[] { PseudoClass.Hover }, builder => builder
                .NineSlicedBackgroundImage("ui/images/buttons/wide-hover", 20, 0.5f)
                .Color(Color.black)
            )
            .AddNineSlicedBackgroundClass("api__button__wide-button--active", "ui/images/buttons/wide-active", 20, 0.5f,
                PseudoClass.Hover, PseudoClass.Active);
    }

    public TBuilder ModifyRoot(Action<LocalizableButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }
}