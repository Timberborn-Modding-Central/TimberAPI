using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationAssetProvider : IAssetProvider
{
    private readonly GeneratedSpecificationAssetRepository _generatedSpecificationAssetRepository;

    public GeneratedSpecificationAssetProvider(GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository)
    {
        _generatedSpecificationAssetRepository = generatedSpecificationAssetRepository;
    }

    public bool IsBuiltIn => false;

    public bool TryLoad<T>(string path, out OrderedAsset<T> orderedAsset) where T : Object
    {
        if (typeof(T) == typeof(TextAsset))
        {
            Debug.LogWarning("WOOO");
        }

        orderedAsset = new OrderedAsset<T>();
        return false;
    }

    public IEnumerable<OrderedAsset<T>> LoadAll<T>(string path) where T : Object
    {
        if (typeof(T) != typeof(TextAsset))
        {
            return new List<OrderedAsset<T>>();
        }

        return (IEnumerable<OrderedAsset<T>>)_generatedSpecificationAssetRepository.GeneratedSpecificationAssets
            .Where(registeredSpecification => registeredSpecification.Key.StartsWith(path))
            .Select(registeredSpecification => registeredSpecification.Value);
    }

    public void Reset()
    {
        Debug.LogWarning("Clearing generated cache");
        _generatedSpecificationAssetRepository.Reset();
    }
}