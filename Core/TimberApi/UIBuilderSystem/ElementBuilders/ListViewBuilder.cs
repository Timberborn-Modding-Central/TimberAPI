using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class ListViewBuilder : BaseElementBuilder<ListView, ListViewBuilder>, IScrollableBuilder<ListViewBuilder>
    {
        protected override ListViewBuilder BuilderInstance => this;

        [SuppressMessage("Member Access", "Publicizer001:Accessing a member that was not originally public")]
        public ListViewBuilder ModifyVerticalScroller(Action<Scroller> modifyScroller)
        {
            modifyScroller.Invoke(Root.scrollView.verticalScroller);
            return this;
        }

        [SuppressMessage("Member Access", "Publicizer001:Accessing a member that was not originally public")]
        public ListViewBuilder ModifyHorizontalScroller(Action<Scroller> modifyScroller)
        {
            modifyScroller.Invoke(Root.scrollView.horizontalScroller);
            return this;
        }

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

        public ListViewBuilder SetSelectionChange(Action<IEnumerable<object>> selectionChange)
        {
            Root.onSelectionChange += selectionChange;
            return this;
        }

        public ListViewBuilder SetSelectionType(SelectionType selectionType)
        {
            Root.selectionType = selectionType;
            return this;
        }
    }
}