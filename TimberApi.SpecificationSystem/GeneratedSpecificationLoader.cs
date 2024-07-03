using System.Collections.Generic;
using TimberApi.SingletonSystem;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationLoader : ITimberApiLoadableSingleton
{
    private readonly GeneratedSpecificationAssetRepository _generatedSpecificationAssetRepository;
    
    private readonly IEnumerable<ISpecificationGenerator> _specificationGenerators;

    public GeneratedSpecificationLoader(GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository, IEnumerable<ISpecificationGenerator> specificationGenerators)
    {
        _specificationGenerators = specificationGenerators;
        _generatedSpecificationAssetRepository = generatedSpecificationAssetRepository;
    }

    public void Load()
    {
        foreach (var specificationGenerator in _specificationGenerators)
        {
            _generatedSpecificationAssetRepository.AddSpecificationRange(specificationGenerator.Generate());
        }
    }
}