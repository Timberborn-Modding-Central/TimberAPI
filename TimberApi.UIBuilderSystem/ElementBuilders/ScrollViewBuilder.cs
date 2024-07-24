using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace TimberApi.UIBuilderSystem.ElementBuilders
{
    public class ScrollViewBuilder : BaseElementBuilder<ScrollViewBuilder, ScrollView>
    {
        protected override ScrollViewBuilder BuilderInstance => this;

        public ScrollViewBuilder ModifyVerticalScroller(Action<Scroller> modifyScroller)
        {
            modifyScroller.Invoke(Root.verticalScroller);
            return this;
        }

        public ScrollViewBuilder ModifyHorizontalScroller(Action<Scroller> modifyScroller)
        {
            modifyScroller.Invoke(Root.horizontalScroller);
            return this;
        }

        public ScrollViewBuilder AddChildren(IEnumerable<VisualElement> children)
        {
            foreach (VisualElement visualElement in children)
            {
                Root.Add(visualElement);
            }

            return this;
        }

        public ScrollViewBuilder AddChild(VisualElement element)
        {
            Root.Add(element);
            return this;
        }

        protected override ScrollView InitializeRoot()
        {
            return new ScrollView();
        }
    }
}