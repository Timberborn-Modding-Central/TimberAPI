using System;
using System.Collections;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders;

public class ListViewBuilder : BaseElementBuilder<ListViewBuilder, ListView>
{
    protected override ListViewBuilder BuilderInstance => this;

    public ListViewBuilder SetMakeItem(Func<VisualElement> visualElement)
    {
        Root.makeItem = visualElement;
        return this;
    }

    public ListViewBuilder SetItemSource(IList itemSource)
    {
        Root.itemsSource = itemSource;
        return this;
    }

    public ListViewBuilder SetBindItem(Action<VisualElement, int> bindItem)
    {
        Root.bindItem = bindItem;
        return this;
    }

    public ListViewBuilder SetSelectionType(SelectionType selectionType)
    {
        Root.selectionType = selectionType;
        return this;
    }
    
    public ListViewBuilder SetItemHeight(float height)
    {
        Root.fixedItemHeight = height;
        return this;
    }

    protected override ListView InitializeRoot()
    {
        return new ListView();
    }
}