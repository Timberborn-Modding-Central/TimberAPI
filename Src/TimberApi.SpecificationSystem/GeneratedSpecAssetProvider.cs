using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecAssetProvider(
    GeneratedSpecAssetRepository generatedSpecAssetRepository)
    : IAssetProvider
{
    public bool IsBuiltIn => false;

    public bool TryLoad<T>(string path, Type type, out OrderedAsset orderedAsset)  where T : Object
    {
        if (type == typeof(TextAsset) && generatedSpecAssetRepository.GeneratedSpecAssets.TryGetValue(path, out var asset))
        {
            orderedAsset = asset;

            return true;
        }

        orderedAsset = new OrderedAsset();
        return false;
    }

    public IEnumerable<OrderedAsset> LoadAll<T>(string path) where T : Object
    {
        if (typeof(T) != typeof(TextAsset)) return new List<OrderedAsset>();

        return generatedSpecAssetRepository.GeneratedSpecAssets
            .Where(registeredSpecification => registeredSpecification.Key.StartsWith(path))
            .Select(registeredSpecification => registeredSpecification.Value);
    }

    public void Reset()
    {
        generatedSpecAssetRepository.Reset();
    }
}