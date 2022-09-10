using TimberApi.Common.SingletonSystem.Singletons;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.AssetSystem
{
    internal class AssetSceneLoader : ITimberApiLoadableSingleton
    {
        private readonly AssetBundleLoader _assetBundleLoader;

        public AssetSceneLoader(AssetBundleLoader assetBundleLoader)
        {
            _assetBundleLoader = assetBundleLoader;
        }

        public void Load()
        {
            if (TimberApiSceneManager.PreviousScene != 0)
            {
                _assetBundleLoader.UnloadAll(TimberApiSceneManager.PreviousScene);
            }

            _assetBundleLoader.LoadAll(TimberApiSceneManager.CurrentScene);
        }
    }
}