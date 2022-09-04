using System;
using UnityEngine.UIElements;

namespace TimberApi.Internal.UiBuilderSystem.ElementSystem
{
    public interface IScrollableBuilder<out TBuilder>
    {
        public TBuilder ModifyVerticalScroller(Action<Scroller> modifyScroller);

        public TBuilder ModifyHorizontalScroller(Action<Scroller> modifyScroller);
    }
}