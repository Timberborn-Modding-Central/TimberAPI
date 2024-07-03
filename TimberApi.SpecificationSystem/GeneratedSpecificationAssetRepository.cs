using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Common;
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
                specification => new OrderedAsset<TextAsset>(-1, new TextAsset(specification.Json))
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
}