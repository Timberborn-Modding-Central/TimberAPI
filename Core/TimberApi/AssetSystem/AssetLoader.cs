using System;
using System.Linq;
using TimberApi.AssetSystem.Exceptions;
using TimberApi.ShaderSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.AssetSystem
{
    internal class AssetLoader : IAssetLoader
    {
        private readonly AssetRepository _assetRepository;

        private readonly ShaderService _shaderService;

        public AssetLoader(AssetRepository assetRepository, ShaderService shaderService)
        {
            _assetRepository = assetRepository;
            _shaderService = shaderService;
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

            T asset = assetFolder.GetAssetBundleAtPath(pathToFile).Load<T>(name) ??
                      throw new InvalidOperationException(
                          $"Failed to load asset ({prefix}/{pathToFile}/{name}). Asset name does not exists inside bundle");

            switch (asset)
            {
                case GameObject gameObject:
                    _shaderService.ApplyShaders(gameObject);
                    break;
                case Material material:
                    _shaderService.ApplyShaders(material);
                    break;
            }

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