using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TimberApi.SingletonSystem;
using TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;
using Timberborn.BlueprintSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.MainMenuPanels;
using Timberborn.SoundSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TimberApi.SpecificationSystem;

internal class GeneratedSpecLoader(
    GeneratedSpecAssetRepository generatedSpecAssetRepository,
    IEnumerable<ISpecGenerator> specificationGenerators,
    FactionSpecService factionSpecificationService,
    ISpecService specService)
    : ITimberApiPostLoadableSingleton
{
    public void PostLoad()
    {
        foreach (var specificationGenerator in specificationGenerators)
        {
            generatedSpecAssetRepository.AddSpecRange(specificationGenerator.Generate());
        }

        // Reloads the spec service, because everything is cached now. This is unoptimized but it is how it is for now.
        // Might give problems with faction specs if they would have changed.
        specService.GetType()
            .GetField("_cachedBlueprints",BindingFlags.Instance|BindingFlags.NonPublic)!
            .SetValue(specService,new Dictionary<Type, List<Lazy<Blueprint>>>());
        
        EarlyLoadPatcher.BlockLoading = false;

        specService.Load();
        factionSpecificationService.Load();
        
        EarlyLoadPatcher.BlockLoading = true;
    }
}