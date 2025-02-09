using System;
using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecAssetRepository
{
    private readonly Dictionary<string, GeneratedSpec> _cachedObjectSpecs = new();

    private readonly HashSet<string> _newCachedObjectSpecPaths = new();

    public readonly Dictionary<string, OrderedAsset> GeneratedSpecAssets = new();

    public void AddSpecRange(IEnumerable<GeneratedSpec> generatedSpecs)
    {
        try
        {
            foreach (var generatedSpec in generatedSpecs)
            {
                var spec = generatedSpec;

                if (generatedSpec.IsUnityObjectSpec)
                {
                    if (!_cachedObjectSpecs.TryGetValue(generatedSpec.FullPath, out spec))
                    {
                        spec = generatedSpec;
                        _cachedObjectSpecs.Add(generatedSpec.FullPath, generatedSpec);
                        _newCachedObjectSpecPaths.Add(generatedSpec.FullPath);
                    }
                    else if (_newCachedObjectSpecPaths.Contains(spec.FullPath))
                    {
                        throw new GeneratedObjectSpecAlreadyExistsException(spec.FullPath);
                    }
                }

                GeneratedSpecAssets[spec.FullPath] = CreateOrderedSpecAsset(spec);
            }
        }
        catch (Exception exception)
        {
            Debug.LogError("Something went wrong while adding generated specifications.");
            throw exception;
        }
    }

    public void Reset()
    {
        GeneratedSpecAssets.Clear();
        _newCachedObjectSpecPaths.Clear();
    }

    private static OrderedAsset CreateOrderedSpecAsset(GeneratedSpec spec)
    {
        var asset = new TextAsset(spec.Json)
        {
            name = spec.SpecName
        };

        return new OrderedAsset(-1, asset);
    }
}