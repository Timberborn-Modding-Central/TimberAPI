using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Bootstrapper;
using Timberborn.Persistence;
using Timberborn.PrefabGroupSystem;
using Timberborn.SingletonSystem;
using Timberborn.SoakedEffects;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Tester;

public class Test : ILoadableSingleton
{
    private IEnumerable<IAssetProvider> _assetProviders;
    
    private readonly IAssetLoader _assetLoader;

    private readonly ISpecificationService _specificationService;

    private readonly NeedAffectedBySoakednessSpecificationDeserializer _deserializer;

    private readonly PrefabGroupSpecificationDeserializer _prefabGroupSpecificationDeserializer;

    public Test(IAssetLoader assetLoader, ISpecificationService specificationService, IEnumerable<IAssetProvider> assetProviders, PrefabGroupSpecificationDeserializer prefabGroupSpecificationDeserializer)
    {
        _assetLoader = assetLoader;
        _specificationService = specificationService;
        _assetProviders = assetProviders;
        _prefabGroupSpecificationDeserializer = prefabGroupSpecificationDeserializer;
        _deserializer = new NeedAffectedBySoakednessSpecificationDeserializer();
    }
    
    public void Load()
    {
        ((AssetLoader)_assetLoader)._assetProviders = _assetProviders.ToImmutableArray();
        
        var specifications = _assetLoader.LoadAll<TextAsset>("specifications/tools");

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