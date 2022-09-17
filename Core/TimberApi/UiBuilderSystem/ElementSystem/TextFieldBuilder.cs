using TimberApi.AssetSystem;
using TimberApi.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;

namespace TimberApi.UiBuilderSystem.ElementSystem
{
    public class TextFieldBuilder : BaseElementBuilder<NineSliceTextField, TextFieldBuilder>
    {
        public TextFieldBuilder(VisualElementInitializer visualElementInitializer, IAssetLoader assetLoader, UiPresetFactory uiPresetFactory) : base(new NineSliceTextField(), visualElementInitializer,
            assetLoader, uiPresetFactory)
        {
        }

        protected override TextFieldBuilder BuilderInstance => this;

        public TextFieldBuilder SetMultiLine(bool isMultiLine)
        {
            Root.multiline = isMultiLine;
            return this;
        }
    }
}