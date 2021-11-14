using TimberbornAPI.AssetLoader;
using TimberbornAPI.Dependency;
using TimberbornAPI.Localizations;

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
        public static IDependencies Dependencies = new Dependencies();

        /// <summary>
        /// APIs for localization and language files
        /// </summary>
        public static ILocalization Localization = new Localization();

        /// <summary>
        /// APIs to load and fetch assets
        /// </summary>
        public static IAssetLoaderSystem AssetLoaderSystem = new AssetLoaderSystem();
    }
}