using TimberApi.New.AssetSystem.Exceptions;
using UnityEngine;

namespace TimberApi.New.AssetSystem
{
    internal class ModAssetBundle
    {
        private readonly string _assetBundleName;
        private readonly string _assetBundlePath;

        private AssetBundle? _assetBundle;

        public ModAssetBundle(string assetBundleName, string assetBundlePath)
        {
            _assetBundlePath = assetBundlePath;
            _assetBundleName = assetBundleName;
        }

        public T Load<T>(string path) where T : Object
        {
            if (_assetBundle == null)
            {
                throw new ModAssetNotLoadedException(_assetBundleName);
            }

            return _assetBundle!.LoadAsset<T>(path);
        }

        public T[] LoadAll<T>() where T : Object
        {
            if (_assetBundle == null)
            {
                throw new ModAssetNotLoadedException(_assetBundleName);
            }

            return _assetBundle!.LoadAllAssets<T>();
        }

        public void LoadAssetBundle()
        {
            if (_assetBundle != null)
            {
                throw new ModAssetBundleAlreadyLoadedException(_assetBundleName);
            }

            _assetBundle = AssetBundle.LoadFromFile(_assetBundlePath);
        }

        public void UnloadAssetBundle()
        {
            if (_assetBundle == null)
            {
                throw new ModAssetBundleAlreadyUnloadedException(_assetBundleName);
            }

            _assetBundle.Unload(true);
            _assetBundle = null;
        }
    }
}