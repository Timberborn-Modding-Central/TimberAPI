using System.Collections.Generic;
using TimberApi.SingletonSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationLoader : ITimberApiPostLoadableSingleton
{
    private readonly GeneratedSpecificationAssetRepository _generatedSpecificationAssetRepository;
    
    private readonly IEnumerable<ISpecificationGenerator> _specificationGenerators;

    public GeneratedSpecificationLoader(GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository, IEnumerable<ISpecificationGenerator> specificationGenerators)
    {
        _specificationGenerators = specificationGenerators;
        _generatedSpecificationAssetRepository = generatedSpecificationAssetRepository;
    }

    public void PostLoad()
    {
        Debug.LogWarning("Starting generators");
        foreach (var specificationGenerator in _specificationGenerators)
        {
            _generatedSpecificationAssetRepository.AddSpecificationRange(specificationGenerator.Generate());
        }
    }
}