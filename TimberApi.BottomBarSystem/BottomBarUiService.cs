using Timberborn.AssetSystem;
using Timberborn.SingletonSystem;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarUiService : ILoadableSingleton
    {
        private readonly IAssetLoader _assetLoader;

        private StyleSheet _bottomBarStyleSheet = null!;

        public BottomBarUiService(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public void Load()
        {
            _bottomBarStyleSheet = _assetLoader.Load<StyleSheet>("UI/Views/Common/BottomBar/BottomBarStyle");
        }

        public VisualElement CreateWrapper()
        {
            var wrapper = new VisualElement();
            wrapper.styleSheets.Add(_bottomBarStyleSheet);

            return wrapper;
        }

        public static VisualElement CreateSubSectionWrapper()
        {
            return new VisualElement
            {
                classList = { "bottom-bar-panel__sub-section-wrapper" }
            };
        }

        public static VisualElement CreateMainSectionWrapper()
        {
            return new VisualElement
            {
                classList = { "bottom-bar-panel__main-section-wrapper" },
                style = { justifyContent = Justify.Center }
            };
        }

        public static VisualElement CreateSection()
        {
            return new VisualElement
            {
                classList = { "bottom-bar-panel__section" }
            };
        }
    }
}