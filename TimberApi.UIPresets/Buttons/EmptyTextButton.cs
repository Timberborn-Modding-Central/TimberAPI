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

public class EmptyTextButton : EmptyTextButton<EmptyTextButton>
{
    protected override EmptyTextButton BuilderInstance => this;
}

public abstract class EmptyTextButton<TBuilder> : BaseBuilder<TBuilder, LocalizableButton>
    where TBuilder : BaseBuilder<TBuilder, LocalizableButton>
{
    protected LocalizableButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__button-empty--normal";

    public TBuilder SetLocKey(string locKey)
    {
        ButtonBuilder.SetLocKey(locKey);
        return BuilderInstance;
    }

    public TBuilder Red()
    {
        ImageClass = "api__button__button-empty--red";
        return BuilderInstance;
    }

    public TBuilder Batch()
    {
        ImageClass = "api__button__button-empty--batch";
        return BuilderInstance;
    }

    public TBuilder Inverted()
    {
        ImageClass = "api__button__button-empty--inverted";
        return BuilderInstance;
    }

    public TBuilder Active()
    {
        ButtonBuilder.AddClass("api__button__button-empty--active");
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

        return ButtonBuilder.AddClass("api__button__button-empty").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__button-empty", "UI.Click")
            .AddClass("api__button__button-empty", builder => builder.Add(Property.Color, "white", StyleValueType.Enum))
            .AddNineSlicedBackgroundHoverClass("api__button__button-empty--normal", "ui/images/buttons/empty",
                "ui/images/buttons/empty-hover", 16, 0.5f)
            .AddNineSlicedBackgroundHoverClass("api__button__button-empty--red", "ui/images/buttons/empty-red",
                "ui/images/buttons/empty-red-hover", 16, 0.5f)
            .AddNineSlicedBackgroundHoverClass("api__button__button-empty--inverted",
                "ui/images/buttons/empty-inverted", "ui/images/buttons/empty-hover", 16, 0.5f)
            .AddNineSlicedBackgroundHoverClass("api__button__button-empty--batch", "ui/images/buttons/empty-batch",
                "ui/images/buttons/empty-batch-hover", 16, 0.5f)
            .AddNineSlicedBackgroundClass("api__button__button-empty--active", "ui/images/buttons/empty-active", 16,
                0.5f, PseudoClass.Hover, PseudoClass.Active);
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