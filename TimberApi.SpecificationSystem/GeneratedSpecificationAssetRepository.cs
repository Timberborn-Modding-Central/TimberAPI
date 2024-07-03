using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Common;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationAssetRepository
{
    private readonly List<GeneratedSpecification> _cachedObjectSpecifications = new ();
    
    public readonly Dictionary<string, OrderedAsset<TextAsset>> GeneratedSpecificationAssets = new();
    
    public void AddSpecificationRange(IEnumerable<GeneratedSpecification> generatedSpecifications)
    {
        try
        {
            var specifications = generatedSpecifications.ToList();
            
            var generatedSpecificationAssets = specifications.ToDictionary(
                specification => specification.FullPath,
                CreateOrderedSpecificationAsset
            );
            
            GeneratedSpecificationAssets.AddRange(generatedSpecificationAssets);
            
            // Prefab generated specifications should only be done once, since prefabs will keep their changed values.
            _cachedObjectSpecifications.AddRange(specifications.Where(generatedSpecification => generatedSpecification.ObjectSpecification));
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
        
        AddSpecificationRange(_cachedObjectSpecifications);
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