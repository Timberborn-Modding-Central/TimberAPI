using Timberborn.AssetSystem;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilder
    {
        private readonly IResourceAssetLoader _resourceAssetLoader;
        
        private readonly ComponentBuilder _componentBuilder;

        public UIBuilder(ComponentBuilder componentBuilder, IResourceAssetLoader resourceAssetLoader)
        {
            _componentBuilder = componentBuilder;
            _resourceAssetLoader = resourceAssetLoader;
        }
        
        public UIBoxBuilder CreateBoxBuilder()
        {
            return new UIBoxBuilder(_componentBuilder, _resourceAssetLoader);
        }
        
        public ComponentBuilder CreateComponentBuilder()
        {
            return _componentBuilder;
        }
    }
}