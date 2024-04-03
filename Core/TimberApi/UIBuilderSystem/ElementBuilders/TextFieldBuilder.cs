using Timberborn.CoreUI;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class TextFieldBuilder : BaseElementBuilder<TextFieldBuilder, NineSliceTextField>
    {
        protected override TextFieldBuilder BuilderInstance => this;

        public TextFieldBuilder SetMultiLine(bool isMultiLine)
        {
            Root.multiline = isMultiLine;
            return this;
        }

        protected override NineSliceTextField InitializeRoot()
        {
            return new NineSliceTextField();
        }
    }
}
