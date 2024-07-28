using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using Timberborn.CoreUI;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using LocalizableButtonBuilder = TimberApi.UIBuilderSystem.ElementBuilders.LocalizableButtonBuilder;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

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
                .AddNineSlicedBackgroundImage("ui/images/buttons/wide", 20, 0.5f)
                .Add(Property.Color, "white", StyleValueType.Enum)
                .Add(Property.ClickSound, "UI.Click", StyleValueType.String)
                .Add(Property.Height, new Dimension(32, Dimension.Unit.Pixel))
                .Add(Property.MinWidth, new Dimension(130, Dimension.Unit.Pixel))
            )
            .AddClass("api__button__wide-button", new[] { PseudoClass.Hover }, builder => builder
                .AddNineSlicedBackgroundImage("ui/images/buttons/wide-hover", 20, 0.5f)
                .Add(Property.Color, "black", StyleValueType.Enum)
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