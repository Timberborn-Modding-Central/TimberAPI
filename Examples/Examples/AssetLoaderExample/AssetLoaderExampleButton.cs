using TimberApi.AssetSystem;
using Timberborn.BottomBarSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.AssetLoaderExample
{
    public class AssetLoaderExampleButton : IBottomBarElementProvider
    {
        // Save the asset loader
        private readonly IAssetLoader _assetLoader;
        private readonly AssetLoaderExampleTool _assetLoaderExampleTool;
        private readonly ToolButtonFactory _toolButtonFactory;

        public AssetLoaderExampleButton(
            AssetLoaderExampleTool assetLoaderExampleTool,
            ToolButtonFactory toolButtonFactory,
            // Inject the asset loader
            IAssetLoader assetLoader)
        {
            _assetLoaderExampleTool = assetLoaderExampleTool;
            _toolButtonFactory = toolButtonFactory;
            _assetLoader = assetLoader;
        }

        public BottomBarElement GetElement()
        {
            return BottomBarElement
                .CreateSingleLevel(_toolButtonFactory
                .CreateGrouplessGreen(_assetLoaderExampleTool,
                    // Use the asset loader to load a sprite named present which is located in the icon file
                    _assetLoader.Load<Sprite>("TimberAPIExample/icons/present"))
                .Root);
        }
    }
}