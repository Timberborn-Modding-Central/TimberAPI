using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;

namespace TimberbornAPI.UIBuilderSystem.ElementSystem
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

