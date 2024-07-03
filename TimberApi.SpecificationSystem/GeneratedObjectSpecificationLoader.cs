using System.Collections.Generic;
using TimberApi.SingletonSystem;
using Timberborn.PrefabGroupSystem;

namespace TimberApi.SpecificationSystem;

internal class GeneratedObjectSpecificationLoader : ITimberApiLoadableSingleton
{
    private readonly GeneratedSpecificationAssetRepository _generatedSpecificationAssetRepository;

    private readonly IEnumerable<IObjectSpecificationGenerator> _specificationGenerators;

    private readonly PrefabGroupService _prefabGroupService;

    public GeneratedObjectSpecificationLoader(
        GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository,
        IEnumerable<IObjectSpecificationGenerator> specificationGenerators, 
        PrefabGroupService prefabGroupService)
    {
        _specificationGenerators = specificationGenerators;
        _prefabGroupService = prefabGroupService;
        _generatedSpecificationAssetRepository = generatedSpecificationAssetRepository;
    }

    public void Load()
    {
        foreach (var specificationGenerator in _specificationGenerators)
        {
            _generatedSpecificationAssetRepository.AddSpecificationRange(specificationGenerator.Generate(_prefabGroupService));
        }
    }
}