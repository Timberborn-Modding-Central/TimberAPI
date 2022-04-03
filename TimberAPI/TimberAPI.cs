using TimberbornAPI.AssetLoaderSystem;
using TimberbornAPI.ContainerSystem;
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
        /// APIs for better integration between dependency injection and harmony
        /// Able to access all loaded dependency classes with a static instance
        /// </summary>
        public static IContainer DependencyContainer = new ContainerHolder();

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