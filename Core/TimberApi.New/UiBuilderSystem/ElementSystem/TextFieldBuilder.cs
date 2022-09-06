using TimberApi.New.ModAssetSystem;
using TimberApi.New.UiBuilderSystem.PresetSystem;
using Timberborn.CoreUI;

namespace TimberApi.New.UiBuilderSystem.ElementSystem
{
    public class TextFieldBuilder : BaseElementBuilder<NineSliceTextField, TextFieldBuilder>
    {
        protected override TextFieldBuilder BuilderInstance => this;

        public TextFieldBuilder(
            VisualElementInitializer visualElementInitializer,
            IAssetLoader assetLoader,
            UiPresetFactory uiPresetFactory)
            : base(new NineSliceTextField(), visualElementInitializer, assetLoader, uiPresetFactory)
        {
            
        }
        
        public TextFieldBuilder SetMultiLine(bool isMultiLine)
        {
            Root.multiline = isMultiLine;
            return this;
        }
    }
}
