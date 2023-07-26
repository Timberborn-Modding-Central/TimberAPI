using System;
using System.Diagnostics;
using System.Linq;
using TimberApi.AssetSystem.Exceptions;
using TimberApi.ShaderSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace TimberApi.AssetSystem
{
    internal class AssetLoader : IAssetLoader, ILoadableSingleton
    {
        private readonly ISpecificationService _specificationService;

        private readonly AssetSpecificationDeserializer _assetSpecificationDeserializer;
        
        private readonly AssetRepository _assetRepository;

        private readonly ShaderService _shaderService;

        private AssetSpecification _assetSpecification = null!;

        public AssetLoader(AssetRepository assetRepository, ShaderService shaderService, ISpecificationService specificationService, AssetSpecificationDeserializer assetSpecificationDeserializer)
        {
            _assetRepository = assetRepository;
            _shaderService = shaderService;
            _specificationService = specificationService;
            _assetSpecificationDeserializer = assetSpecificationDeserializer;
        }
        
        public void Load()
        {
            _assetSpecification = _specificationService.GetSpecifications(_assetSpecificationDeserializer).Single();
        }

        public T Load<T>(string path) where T : Object
        {
            var assetPath = RemoveDirectoryPrefixes(path);
            var slicedPath = assetPath.Split("/");
            var prefix = slicedPath.First();
            var newPath = string.Join("/", slicedPath.Skip(1));
            return Load<T>(prefix, newPath);
        }

        public T Load<T>(string prefix, string path) where T : Object
        {
            var slicedPath = path.Split("/");
            var name = slicedPath[^1];
            return Load<T>(prefix, string.Join('/', slicedPath.SkipLast(1)), name);
        }

        public T Load<T>(string prefix, string pathToFile, string name) where T : Object
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }

            var asset = assetFolder.GetAssetBundleAtPath(pathToFile).Load<T>(name) ??
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
            var slicedPath = path.Split("/");
            var prefix = slicedPath.First();
            var newPath = string.Join("/", slicedPath.Skip(1));
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
        
        private string RemoveDirectoryPrefixes(string path)
        {
            foreach (var directoryPrefix in _assetSpecification.IgnoreDirectoryPrefixes)
            {
                path = path.Replace(directoryPrefix, "");
            }

            return path;
        }
    }
}