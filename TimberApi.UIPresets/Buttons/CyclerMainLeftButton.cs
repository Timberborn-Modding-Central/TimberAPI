using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class CyclerMainLeftButton : CyclerMainLeftButton<CyclerMainLeftButton>
{
    protected override CyclerMainLeftButton BuilderInstance => this;
}

public abstract class CyclerMainLeftButton<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

    protected string SizeClass = "api__button__cycler-main-left--size-normal";

    public TBuilder Small()
    {
        SizeClass = "api__button__cycler-main-left--size-small";
        return BuilderInstance;
    }

    public TBuilder Large()
    {
        SizeClass = "api__button__cycler-main-left--size-large";
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

        return ButtonBuilder.AddClass("api__button__cycler-main-left").Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__cycler-main-left", "UI.Click")
            .AddBackgroundHoverClass("api__button__cycler-main-left", "ui/images/buttons/cycler_left",
                "ui/images/buttons/cycler_left_hover")
            .AddClass("api__button__cycler-main-left--size-normal", builder => builder
                .Height(24)
                .Width(24)
            )
            .AddClass("api__button__cycler-main-left--size-small", builder => builder
                .Height(20)
                .Width(20)
            )
            .AddClass("api__button__cycler-main-left--size-large", builder => builder
                .Height(26)
                .Width(26)
            );
    }

    public override Button Build()
    {
        return ButtonBuilder
            .AddClass(SizeClass)
            .Build();
    }
    
    public TBuilder AddClass(string styleClass)
    {
        ButtonBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<ButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);
        return BuilderInstance;
    }
}