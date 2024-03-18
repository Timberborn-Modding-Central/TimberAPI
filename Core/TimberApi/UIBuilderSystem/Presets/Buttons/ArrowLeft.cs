using Timberborn.CoreUI;
using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.Presets.Buttons
{
    public class ArrowLeft : ArrowLeft<ArrowLeft>
    {
        protected override ArrowLeft BuilderInstance => this;
    }

    public abstract class ArrowLeft<TBuilder> : BaseBuilder<TBuilder, VisualElement>
        where TBuilder : BaseBuilder<TBuilder, VisualElement>
    {
    }
}
