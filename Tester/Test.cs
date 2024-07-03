using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.SoakedEffects;
using UnityEngine;

namespace Tester;

public class Test : ILoadableSingleton
{
    private IEnumerable<IAssetProvider> _assetProviders;
    
    private readonly IAssetLoader _assetLoader;

    private readonly ISpecificationService _specificationService;

    private readonly NeedAffectedBySoakednessSpecificationDeserializer _deserializer;

    public Test(IAssetLoader assetLoader, ISpecificationService specificationService, IEnumerable<IAssetProvider> assetProviders)
    {
        _assetLoader = assetLoader;
        _specificationService = specificationService;
        _assetProviders = assetProviders;
        _deserializer = new NeedAffectedBySoakednessSpecificationDeserializer();
    }
    
    public void Load()
    {
        ((AssetLoader)_assetLoader)._assetProviders = _assetProviders.ToImmutableArray();
        
        var specifications = _assetLoader.LoadAll<TextAsset>("specifications/needsaffectedbysoakedness");

        foreach (var specification in specifications)
        {
            Debug.LogError(specification.Asset.text);
        }

        foreach (var specification in _specificationService.GetSpecifications(_deserializer))
        {
            Debug.LogError(specification.PointsPerHour);
        }
    }
}