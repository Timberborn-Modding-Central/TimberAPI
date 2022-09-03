using TimberApi.Internal.ConfiguratorSystem;
using TimberApi.Internal.SingletonSystem.Singletons;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetScenePatcher : ITimberApiLoadableSingleton
    {
        private readonly AssetBundleLoader _assetBundleLoader;

        public AssetScenePatcher(AssetBundleLoader assetBundleLoader)
        {
            _assetBundleLoader = assetBundleLoader;
        }

        public void Load()
        {
            if (ConfiguratorPatcher.PreviousScene != 0)
            {
                _assetBundleLoader.UnloadAll(ConfiguratorPatcher.CurrentScene);
            }
            _assetBundleLoader.LoadAll(ConfiguratorPatcher.CurrentScene);
        }
    }
}