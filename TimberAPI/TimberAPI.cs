using TimberbornAPI.AssetLoaderSystem;
using TimberbornAPI.DependencySystem;
using TimberbornAPI.LocalizationSystem;
using TimberbornAPI.ObjectCollectionSystem;

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
        public static IDependencyRegistry DependencyRegistry = new DependencyRegistry();

        /// <summary>
        /// APIs for localization and language files
        /// </summary>
        public static ILocalization Localization = new Localization();

        /// <summary>
        /// APIs to load and fetch assets
        /// </summary>
        public static IAssetRegistry AssetRegistry = new AssetRegistry();

        /// <summary>
        /// APIs for ObjectCollection
        /// </summary>
        public static ICustomObjectCollection CustomObjectCollection = new CustomObjectCollection();
    }
}