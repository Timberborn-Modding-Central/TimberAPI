using System;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using Timberborn.CoreUI;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.ListViews;

public abstract class DefaultListViewItemWrapper : DefaultListViewItemWrapper<DefaultListViewItemWrapper>
{
    protected override DefaultListViewItemWrapper BuilderInstance => this;
}

public abstract class DefaultListViewItemWrapper<TBuilder> : BaseBuilder<TBuilder, NineSliceVisualElement>
    where TBuilder : BaseBuilder<TBuilder, NineSliceVisualElement>
{
    protected VisualElementBuilder VisualElementBuilder = null!;
    
    protected override NineSliceVisualElement InitializeRoot()
    {
        VisualElementBuilder = UIBuilder.Create<VisualElementBuilder>()
            .AddClass("api__default-list-view__item")
            .AddClass("api__default-list-view__item-background");

        return VisualElementBuilder.Build();
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__default-list-view__item", builder => builder
                .Height(100, Dimension.Unit.Percent)
                .JustifyContent(JustifyContent.Center)
            )
            .AddNineSlicedBackground(".api__default-list-view__item-background:hover:enabled",
                "UI/Images/Core/scroll_tab", 15, 142, 15, 142, 0.5f)
            .AddNineSlicedBackground(".api__default-list-view__item-background:checked", "UI/Images/Core/scroll_tab",
                15, 142, 15, 142, 0.5f);
    }
    
    public TBuilder AddClass(string styleClass)
    {
        VisualElementBuilder.AddClass(styleClass);
        return BuilderInstance;
    }

    public TBuilder ModifyRoot(Action<VisualElementBuilder> visualElementBuilder)
    {
        visualElementBuilder.Invoke(VisualElementBuilder);
        return BuilderInstance;
    }
}