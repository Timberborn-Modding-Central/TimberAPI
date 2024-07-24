using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class ArrowUpButton : ArrowUpButton<ArrowUpButton>
{
    protected override ArrowUpButton BuilderInstance => this;
}

public abstract class ArrowUpButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string ImageClass = "api__button__arrow_up-button--normal";

    protected string SizeClass = "api__button__arrow_up-button--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__arrow_up-button--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__arrow_up-button--size-large";
        return BuilderInstance;
    }

    public TBuilder SetSize(Length size)
    {
        ButtonBuilder.SetHeight(size);
        ButtonBuilder.SetWidth(size);
        return BuilderInstance;
    }

    public TBuilder Active()
    {
        ButtonBuilder.AddClass("api__button__arrow_up-button--active");
        return BuilderInstance;
    }

    public TBuilder Inverted()
    {
        ImageClass = "api__button__arrow_up-button--inverted";
        return BuilderInstance;
    }

    protected override Button InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<ButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__arrow_up-button").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__arrow_up-button", "UI.Click")
            .AddBackgroundClass("api__button__arrow_up-button", "ui/images/buttons/arrow-up-hover", PseudoClass.Hover)
            .AddBackgroundClass("api__button__arrow_up-button--normal", "ui/images/buttons/arrow-up")
            .AddBackgroundClass("api__button__arrow_up-button--inverted", "ui/images/buttons/arrow-up-inverted")
            .AddBackgroundClass("api__button__arrow_up-button--active", "ui/images/buttons/arrow-up-active",
                PseudoClass.Active, PseudoClass.Hover)
            .AddClass("api__button__arrow_up-button--size-normal", builder => builder
                .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
                .Add(Property.Width, new Dimension(20, Dimension.Unit.Pixel))
            )
            .AddClass("api__button__arrow_up-button--size-small", builder => builder
                .Add(Property.Height, new Dimension(18, Dimension.Unit.Pixel))
                .Add(Property.Width, new Dimension(18, Dimension.Unit.Pixel))
            )
            .AddClass("api__button__arrow_up-button--size-large", builder => builder
                .Add(Property.Height, new Dimension(24, Dimension.Unit.Pixel))
                .Add(Property.Width, new Dimension(24, Dimension.Unit.Pixel))
            );
    }

    public TBuilder ModifyRoot(Action<ButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    public override Button Build()
    {
        return ButtonBuilder
            .AddClass(ImageClass)
            .AddClass(SizeClass)
            .Build();
    }
}