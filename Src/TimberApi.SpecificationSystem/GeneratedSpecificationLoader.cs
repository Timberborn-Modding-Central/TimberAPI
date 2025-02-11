using System.Collections.Generic;
using TimberApi.SingletonSystem;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecLoader(
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