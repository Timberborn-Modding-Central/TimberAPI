using TimberApi.AssetSystem;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.ResourceAssetSystem
{
    internal class ResourceAssetLoader : IResourceAssetLoader
    {
        private readonly IAssetLoader _assetLoader;

        public ResourceAssetLoader(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path) ?? _assetLoader.Load<T>(path);
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path) ?? _assetLoader.LoadAll<T>(path);
        }
    }
}