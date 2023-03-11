using Timberborn.AssetSystem;
using Timberborn.SingletonSystem;
using UnityEngine.UIElements;

namespace TimberApi.BottomBarUISystem
{
    public class BottomBarUiService : ILoadableSingleton
    {
        private readonly IResourceAssetLoader _resourceAssetLoader;

        private StyleSheet _bottomBarStyleSheet = null!;

        public BottomBarUiService(IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        public void Load()
        {
            _bottomBarStyleSheet = _resourceAssetLoader.Load<StyleSheet>("UI/Views/Common/BottomBar/BottomBarStyle");
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
                classList = { "bottom-bar-panel__main-section-wrapper" }
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