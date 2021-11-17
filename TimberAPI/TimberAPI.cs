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
        public static IDependency Dependency = new Dependency();

        /// <summary>
        /// APIs for localization and language files
        /// </summary>
        public static ILocalization Localization = new Localization();

        /// <summary>
        /// APIs to load and fetch assets
        /// </summary>
        public static IAssetLoaderService AssetLoaderService = new AssetLoaderService();
    }
}