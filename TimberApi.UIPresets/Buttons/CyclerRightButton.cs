using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.Buttons;

public class CyclerRightButton : CyclerRight<CyclerRightButton>
{
    protected override CyclerRightButton BuilderInstance => this;
}

public abstract class CyclerRight<TBuilder> : BaseBuilder<TBuilder, Button>
    where TBuilder : BaseBuilder<TBuilder, Button>
{
    protected ButtonBuilder ButtonBuilder = null!;

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

    protected override Button InitializeRoot()
    {
        ButtonBuilder = UIBuilder.Create<ButtonBuilder>();

        return ButtonBuilder.AddClass("api__button__cycler-right").Build();
    }

    public TBuilder ModifyRoot(Action<ButtonBuilder> buttonBuilder)
    {
        buttonBuilder.Invoke(ButtonBuilder);

        return BuilderInstance;
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClickSoundClass("api__button__cycler-right", "UI.Click")
            .AddBackgroundHoverClass("api__button__cycler-right", "ui/images/game/cycler-right",
                "ui/images/game/cycler-right-hover")
            .AddClass("api__button__cycler-right", builder => builder
                .Add(Property.Width, new Dimension(11, Dimension.Unit.Pixel))
                .Add(Property.Height, new Dimension(20, Dimension.Unit.Pixel))
            );
    }
}