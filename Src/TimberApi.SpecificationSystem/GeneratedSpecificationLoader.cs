using System.Collections.Generic;
using TimberApi.SingletonSystem;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationLoader(
    GeneratedSpecAssetRepository generatedSpecAssetRepository,
    IEnumerable<ISpecGenerator> specificationGenerators)
    : ITimberApiPostLoadableSingleton
{
    public void PostLoad()
    {
        foreach (var specificationGenerator in specificationGenerators)
        {
            generatedSpecAssetRepository.AddSpecRange(specificationGenerator.Generate());
        }
    }
}