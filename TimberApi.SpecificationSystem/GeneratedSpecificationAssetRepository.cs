using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Common;
using Timberborn.PrefabGroupSystem;
using Timberborn.PrefabSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationAssetRepository
{
    private readonly List<IGeneratedSpecification> _cachedObjectSpecifications = new ();
    
    public readonly Dictionary<string, OrderedAsset<TextAsset>> GeneratedSpecificationAssets = new();
    
    public void AddSpecificationRange(IEnumerable<IGeneratedSpecification> generatedSpecifications)
    {
        try
        {
            var specifications = generatedSpecifications.ToList();
            
            var generatedSpecificationAssets = specifications.ToDictionary(
                specification => specification.FullPath,
                CreateOrderedSpecificationAsset
            );
            
            GeneratedSpecificationAssets.AddRange(generatedSpecificationAssets);

            if (specifications.Any(generatedSpecification => generatedSpecification.ObjectSpecification))
            {
                _cachedObjectSpecifications.AddRange(specifications);
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
        
        AddSpecificationRange(_cachedObjectSpecifications);
    }

    private static OrderedAsset<TextAsset> CreateOrderedSpecificationAsset(IGeneratedSpecification specification)
    {
        var asset = new TextAsset(specification.Json)
        {
            name = specification.SpecificationName
        };

        return new OrderedAsset<TextAsset>(-1, asset);
    }
}