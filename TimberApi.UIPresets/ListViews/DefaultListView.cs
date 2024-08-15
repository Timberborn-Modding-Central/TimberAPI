using System;
using System.Collections;
using TimberApi.UIBuilderSystem;
using TimberApi.UIBuilderSystem.ElementBuilders;
using TimberApi.UIBuilderSystem.StyleSheetSystem.Extensions;
using TimberApi.UIBuilderSystem.StyleSheetSystem.PropertyEnums;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
using StyleSheetBuilder = TimberApi.UIBuilderSystem.StyleSheetSystem.StyleSheetBuilder;

namespace TimberApi.UIPresets.ListViews;

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
        ListViewBuilder = UIBuilder.Create<ListViewBuilder>();

        return ListViewBuilder.AddClass("api__default-list-view").Build();
    }
    
    public TBuilder SetMakeItem(Func<VisualElement> visualElement)
    {
        ListViewBuilder.SetMakeItem(visualElement);
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

    public TBuilder SetSelectionType(SelectionType selectionType)
    {
        ListViewBuilder.SetSelectionType(selectionType);
        return BuilderInstance;
    }

    protected override void InitializeStyleSheet(StyleSheetBuilder styleSheetBuilder)
    {
        styleSheetBuilder
            .AddClass("api__default-list-view", builder => builder
                .FlexGrow(1)
                .AlignItems(AlignItems.Center)
                .JustifyContent(JustifyContent.Center)
                .MarginLeft(15)
                .MarginRight(15)
            )
            .AddSelector("*", builder => builder
                .BackgroundColor(Color.black)
            )
            .AddSelector(".api__default-list-view > .unity-scroll-view > .unity-scroll-view__content-viewport", builder => builder
                .AlignItems(AlignItems.Center)
                .JustifyContent(JustifyContent.Center)
                .FlexGrow(0)
            )
            .AddSelector(".api__default-list-view > .unity-scroll-view > .unity-scroll-view__content-viewport > .unity-scroll-view__content-container", builder => builder
                .Width(100, Dimension.Unit.Percent)
            );
    }
}