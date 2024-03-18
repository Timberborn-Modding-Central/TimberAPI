using Timberborn.CoreUI;

namespace TimberApi.UiBuilderSystem.ElementBuilders
{
    public class TextFieldBuilder : BaseElementBuilder<NineSliceTextField, TextFieldBuilder>
    {
        protected override TextFieldBuilder BuilderInstance => this;

        public TextFieldBuilder SetMultiLine(bool isMultiLine)
        {
            Root.multiline = isMultiLine;
            return this;
        }
    }
}
