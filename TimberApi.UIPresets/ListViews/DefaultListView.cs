using System;
using System.Collections;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.ListViews;

/// <summary>
/// The `ListView` requires the methods `SetItemSource`, `SetBindItem` & `SetMakeItem` to be set.
/// </summary>
public class DefaultListView : DefaultListView<DefaultListView>
{
    protected override DefaultListView BuilderInstance => this;
}

public abstract class DefaultListView<TBuilder> : BaseBuilder<TBuilder, ListView>
    where TBuilder : BaseBuilder<TBuilder, ListView>
{
    protected ListViewBuilder ListViewBuilder = null!;

    protected override ListView InitializeRoot()
    {
        ListViewBuilder = UIBuilder.Create<ListViewBuilder>()
            .AddClass("api__default-list-view");
        
        return ListViewBuilder.Build();
    }
    
    public TBuilder SetMakeItem(Func<VisualElement> makeItemFunc)
    {
        ListViewBuilder.SetMakeItem(makeItemFunc);
        return BuilderInstance;
    }

    public TBuilder SetItemSource(IList itemSource)
    {
        ListViewBuilder.SetItemSource(itemSource);
        return BuilderInstance;
    }

    public TBuilder SetBindItem(Action<VisualElement, int> bindItem)
    {
        ListViewBuilder.SetBindItem(bindItem);
        return BuilderInstance;
    }
    
    public TBuilder SetItemHeight(float height)
    {
        ListViewBuilder.SetItemHeight(height);
        return BuilderInstance;
    }

    public TBuilder SetSelectionType(SelectionType selectionType)
    {
        ListViewBuilder.SetSelectionType(selectionType);
        return BuilderInstance;
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddSelector(
                ".api__default-list-view .unity-scroll-view__content-and-vertical-scroll-container > .unity-scroller > .unity-slider",
                builder => builder
                    .Width(20)
                    .MinWidth(20)
            )
            .AddSelector(
                ".api__default-list-view .unity-scroll-view__content-and-vertical-scroll-container > .unity-scroller > .unity-slider .unity-base-slider__dragger",
                builder => builder
                    .MinHeight(58)
                    .Left(2)
            )
            .AddSelector(".api__default-list-view .scroll-view__nine-slice-dragger", builder => builder
                .NineSlicedBackgroundImage("UI/Images/Core/scroll-button-nine-slice", 14, 0.5f)
                .Width(100, Dimension.Unit.Percent)
                .Height(100, Dimension.Unit.Percent)
            )
            .AddSelector(".api__default-list-view .scroll-view__nine-slice-tracker", builder => builder
                .NineSlicedBackgroundImage("UI/Images/Core/scroll-bar-nine-slice", 16, 0, 16, 0, 0.5f)
                .Width(100, Dimension.Unit.Percent)
                .Height(100, Dimension.Unit.Percent)
            )
            .AddSelector(".api__default-list-view .scroll-view__nine-slice-dragger:hover", builder => builder
                .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/scroll-button-nine-slice-highlight",
                    UIBuilderSystem.StyleSheetSystem.StyleValueType.ResourcePath)
            )
            .AddSelector(
                ".api__default-list-view .unity-base-slider__drag-container:active .scroll-view__nine-slice-dragger",
                builder => builder
                    .Add(Property.NineSlicedBackgroundImage, "UI/Images/Core/scroll-button-nine-slice-highlight",
                        UIBuilderSystem.StyleSheetSystem.StyleValueType.ResourcePath)
            );
    }
}