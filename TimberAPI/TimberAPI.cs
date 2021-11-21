using TimberbornAPI.AssetLoader;
using TimberbornAPI.DependencySystem;
using TimberbornAPI.LocalizationSystem;

namespace TimberbornAPI
{
    /// <summary>
    /// Provides simplified APIs for writing mods.
    /// </summary>
    public static class TimberAPI
    {
        /// <summary>
        /// APIs for dependency injection and management
        /// </summary>
        public static IDependencyRegistry DependecyRegistry = new DependencyRegistry();

        /// <summary>
        /// APIs for localization and language files
        /// </summary>
        public static ILocalization Localization = new Localization();

        /// <summary>
        /// APIs to load and fetch assets
        /// </summary>
        public static IAssetRegistry AssetRegistry = new AssetRegistry();
        
        /// <summary>
        /// APIs for modifying in game objects
        /// </summary>
        public static IGameObjectModifierRegistry GameObjectModifierRegistry = new GameObjectModifierRegistry();
    }
}