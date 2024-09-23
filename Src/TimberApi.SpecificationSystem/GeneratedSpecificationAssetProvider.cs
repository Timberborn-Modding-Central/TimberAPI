using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationAssetProvider(
    GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository)
    : IAssetProvider
{
    public bool IsBuiltIn => false;

    public bool TryLoad<T>(string path, out OrderedAsset<T> orderedAsset) where T : Object
    {
        if (typeof(T) == typeof(TextAsset) &&
            generatedSpecificationAssetRepository.GeneratedSpecificationAssets.ContainsKey(path))
        {
            orderedAsset = generatedSpecificationAssetRepository.GeneratedSpecificationAssets[path].As<T>();

            return true;
        }

        orderedAsset = new OrderedAsset<T>();
        return false;
    }

    public IEnumerable<OrderedAsset<T>> LoadAll<T>(string path) where T : Object
    {
        if (typeof(T) != typeof(TextAsset)) return new List<OrderedAsset<T>>();

        return (IEnumerable<OrderedAsset<T>>)generatedSpecificationAssetRepository.GeneratedSpecificationAssets
            .Where(registeredSpecification => registeredSpecification.Key.StartsWith(path))
            .Select(registeredSpecification => registeredSpecification.Value);
    }

    public void Reset()
    {
        generatedSpecificationAssetRepository.Reset();
    }
}