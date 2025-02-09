using System.Collections.Generic;
using TimberApi.SingletonSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecificationLoader(
    GeneratedSpecificationAssetRepository generatedSpecificationAssetRepository,
    IEnumerable<ISpecificationGenerator> specificationGenerators)
    : ITimberApiPostLoadableSingleton
{
    public void PostLoad()
    {
        foreach (var specificationGenerator in specificationGenerators)
        {
            generatedSpecificationAssetRepository.AddSpecificationRange(specificationGenerator.Generate());
        }
    }
}