using TimberApi.Common.SingletonSystem.Singletons;

namespace TimberApi.New.AssetSystem
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
            // if (ConfiguratorPatcher.PreviousScene != 0)
            // {
            //     _assetBundleLoader.UnloadAll(ConfiguratorPatcher.PreviousScene);
            // }
            // _assetBundleLoader.LoadAll(ConfiguratorPatcher.CurrentScene);
        }
    }
}