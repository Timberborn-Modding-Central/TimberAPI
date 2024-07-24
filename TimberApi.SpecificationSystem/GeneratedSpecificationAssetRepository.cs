using System;
using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationAssetRepository
{
    private readonly Dictionary<string, GeneratedSpecification> _cachedObjectSpecifications = new();

    public readonly Dictionary<string, OrderedAsset<TextAsset>> GeneratedSpecificationAssets = new();

    private readonly HashSet<string> _newCachedObjectSpecificationPaths = new();

    public void AddSpecificationRange(IEnumerable<GeneratedSpecification> generatedSpecifications)
    {
        try
        {
            foreach (var generatedSpecification in generatedSpecifications)
            {
                var specification = generatedSpecification;

                if (generatedSpecification.ObjectSpecification)
                {
                    if (!_cachedObjectSpecifications.TryGetValue(generatedSpecification.FullPath, out specification))
                    {
                        specification = generatedSpecification;
                        _cachedObjectSpecifications.Add(generatedSpecification.FullPath, generatedSpecification);
                        _newCachedObjectSpecificationPaths.Add(generatedSpecification.FullPath);
                    }
                    else if (_newCachedObjectSpecificationPaths.Contains(specification.FullPath))
                    {
                        throw new GeneratedObjectSpecificationAlreadyExistsException(specification.FullPath);
                    }
                }

                GeneratedSpecificationAssets[specification.FullPath] = CreateOrderedSpecificationAsset(specification);
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
        GeneratedSpecificationAssets.Clear();
        _newCachedObjectSpecificationPaths.Clear();
    }

    private static OrderedAsset<TextAsset> CreateOrderedSpecificationAsset(GeneratedSpecification specification)
    {
        var asset = new TextAsset(specification.Json)
        {
            name = specification.SpecificationName
        };

        return new OrderedAsset<TextAsset>(-1, asset);
    }
}