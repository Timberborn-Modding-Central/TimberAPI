using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;
using StyleValueType = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleValueType;

namespace TimberApi.UIPresets.Buttons;

public class MenuButton : ButtonMenu<MenuButton>
{
    protected override MenuButton BuilderInstance => this;
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
                .ClickSound("UI.Click")
                .NineSlicedBackgroundImage("ui/images/buttons/button", 0, 65, 0, 65, 0.5f)
                .UnityFontStyle(UnityFontStyle.Bold)
                .Color(Color.white)
            )
            .AddClass("api__button__menu-button", new[] { PseudoClass.Hover }, builder => builder
                .NineSlicedBackgroundImage("ui/images/buttons/button-hover", 0, 65, 0, 65, 0.5f)
                .Color(Color.black)
            )
            .AddClass("api__button__menu-button--size-normal", builder => builder
                .Height(44)
                .Width(245)
                .FontSize(14)
            )
            .AddClass("api__button__menu-button--size-medium", builder => builder
                .Height(33)
                .Width(245)
                .FontSize(13)
            );
    }

    public TBuilder ModifyRoot(Action<LocalizableButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    public override LocalizableButton Build()
    {
        return ButtonBuilder
            .AddClass(SizeClass)
            .Build();
    }
}