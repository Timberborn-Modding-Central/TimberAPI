using TimberApi.Internal.ConfiguratorSystem;
using TimberApi.Internal.SingletonSystem.Singletons;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetSceneLoader : ITimberApiLoadableSingleton
    {
        private readonly AssetBundleLoader _assetBundleLoader;

        public AssetSceneLoader(AssetBundleLoader assetBundleLoader)
        {
            _assetBundleLoader = assetBundleLoader;
        }

        public void Load()
        {
            if (ConfiguratorPatcher.PreviousScene != 0)
            {
                _assetBundleLoader.UnloadAll(ConfiguratorPatcher.PreviousScene);
            }
            _assetBundleLoader.LoadAll(ConfiguratorPatcher.CurrentScene);
        }
    }
}