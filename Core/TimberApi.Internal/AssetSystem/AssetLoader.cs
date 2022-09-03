using System;
using System.Linq;
using TimberApi.Core2.ModAssetSystem;
using TimberApi.Internal.AssetShaderSystem;
using TimberApi.Internal.AssetSystem.Exceptions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetLoader : IAssetLoader
    {
        private readonly AssetRepository _assetRepository;

        private readonly AssetShaderFixer _shaderFixer;

        public AssetLoader(AssetRepository assetRepository, AssetShaderFixer shaderFixer)
        {
            _assetRepository = assetRepository;
            _shaderFixer = shaderFixer;
        }

        public T Load<T>(string path) where T : Object
        {
            string[] slicedPath = path.Split("/");
            string prefix = slicedPath.First();
            string newPath = string.Join("/", slicedPath.Skip(1));
            return Load<T>(prefix, newPath);
        }

        public T Load<T>(string prefix, string path) where T : Object
        {
            string[] slicedPath = path.Split("/");
            string name = slicedPath[^1];
            return Load<T>(prefix, string.Join('/', slicedPath.SkipLast(1)), name);
        }

        public T Load<T>(string prefix, string pathToFile, string name) where T : Object
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }

            T asset = assetFolder.GetAssetBundleAtPath(pathToFile).Load<T>(name) ?? throw new InvalidOperationException($"Failed to load asset at {prefix}/{pathToFile}/{name}. Asset name does not exists inside bundle");

            if(asset is not GameObject gameObject)
            {
                return asset;
            }

            _shaderFixer.FixShaders(gameObject);
            return asset;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            string[] slicedPath = path.Split("/");
            string prefix = slicedPath.First();
            string newPath = string.Join("/", slicedPath.Skip(1));
            return LoadAll<T>(prefix, newPath);
        }

        public T[] LoadAll<T>(string prefix, string pathToFile) where T : Object
        {
            if (!_assetRepository.TryGetByPrefix(prefix.ToLower(), out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }

            return assetFolder.GetAssetBundleAtPath(pathToFile).LoadAll<T>();
        }
    }
}