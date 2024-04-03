using UnityEngine.UIElements;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class VisualElementBuilder : BaseElementBuilder<VisualElementBuilder, VisualElement>
    {
        protected override VisualElementBuilder BuilderInstance => this;
        protected override VisualElement InitializeRoot()
        {
            return new VisualElement();
        }
    }
}