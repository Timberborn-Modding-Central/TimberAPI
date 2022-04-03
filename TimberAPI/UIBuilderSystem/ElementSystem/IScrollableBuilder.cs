using System;
using UnityEngine.UIElements;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
{
    public interface IScrollableBuilder<out TBuilder>
    {
        public TBuilder ModifyVerticalScroller(Action<Scroller> modifyScroller);

        public TBuilder ModifyHorizontalScroller(Action<Scroller> modifyScroller);
    }
}