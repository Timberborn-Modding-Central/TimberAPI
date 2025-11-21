

using System;
using System.Collections.Generic;
using System.Reflection;
using Timberborn.BlueprintSystem;

namespace TimberApi.SpecificationSystem;

#nullable disable
internal class GeneratedSpecLoader(
    GeneratedSpecAssetRepository generatedSpecAssetRepository,
    IEnumerable<ISpecGenerator> specificationGenerators,
    ISpecService specService)
{
    public void RegenerateSpecBlueprints()
    {
        foreach (var specificationGenerator in specificationGenerators)
        {
            generatedSpecAssetRepository.AddSpecRange(specificationGenerator.Generate());
        }

        // Reloads the spec service, because everything is cached now. This is unoptimized but it is how it is for now.
        // Might give problems with faction specs if they would have changed.
        var test = ((Dictionary<Type, List<Lazy<Blueprint>>>)specService.GetType()
            .GetField("_cachedBlueprints", BindingFlags.Instance | BindingFlags.NonPublic)!
            .GetValue(specService));
        
        test.Clear();
        specService.Load();
    }

}
