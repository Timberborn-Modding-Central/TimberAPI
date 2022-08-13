using TimberbornAPI.Common;

namespace TimberbornAPI.AssetLoaderSystem
{
    public interface IAssetRegistry
    {
        /// <summary>
        /// Adds assets to a scene that are placed in the assetLocation
        /// </summary>
        /// <param name="prefix">prefix to find mod related asset, same prefix can be used in different entry points</param>
        /// <param name="assetEntryPoint">In what scene does the asset need to be loaded</param>
        /// <param name="assetLocation">root location relative to where the DLL is placed</param>
        void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint, string[] assetLocation);

        /// <summary>
        /// Adds assets to a scene that are placed in the asset folder relative to the dll
        /// </summary>
        /// <param name="prefix">prefix to find mod related asset, same prefix can be used in different entry points</param>
        /// <param name="assetEntryPoint">In what scene does the asset need to be loaded</param>
        void AddSceneAssets(string prefix, SceneEntryPoint assetEntryPoint);

        /// <summary>
        /// Loads all assets for the given scene
        /// Not recommended to do this manually, this will effect all mods
        /// </summary>
        /// <param name="scene">timberborn scene</param>
        void LoadSceneAssets(SceneEntryPoint scene);

        /// <summary>
        /// Unloads all assets for the given scene
        /// Not recommended to do this manually, this will effect all mods
        /// </summary>
        /// <param name="scene">timberborn scene</param>
        void UnloadSceneAssets(SceneEntryPoint scene);

    }
}