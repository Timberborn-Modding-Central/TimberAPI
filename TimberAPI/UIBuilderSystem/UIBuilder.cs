using Timberborn.CoreUI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using TimberbornAPI.UIBuilderSystem.PresetSystem;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilder
    {
        private readonly ComponentBuilder _componentBuilder;

        public UIBuilder(ComponentBuilder componentBuilder)
        {
            _componentBuilder = componentBuilder;
        }
        
        public UIBoxBuilder CreateBoxBuilder()
        {
            return new UIBoxBuilder(_componentBuilder);
        }
    }
}