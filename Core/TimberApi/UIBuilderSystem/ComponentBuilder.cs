using TimberApi.UiBuilderSystem.ElementBuilders;

namespace TimberApi.UiBuilderSystem
{
    public class ComponentBuilder
    {
        public ButtonBuilder CreateButton()
        {
            return new ButtonBuilder();
        }

        public ToggleBuilder CreateToggle()
        {
            return new ToggleBuilder();
        }

        public VisualElementBuilder CreateVisualElement()
        {
            return new VisualElementBuilder();
        }

        public ScrollViewBuilder CreateScrollView()
        {
            return new ScrollViewBuilder();
        }

        public LabelBuilder CreateLabel()
        {
            return new LabelBuilder();
        }

        public SliderBuilder CreateSlider()
        {
            return new SliderBuilder();
        }

        public SliderIntBuilder CreateSliderInt()
        {
            return new SliderIntBuilder();
        }

        public TextFieldBuilder CreateTextField()
        {
            return new TextFieldBuilder();
        }

        public ListViewBuilder CreateListView()
        {
            return new ListViewBuilder();
        }
    }
}