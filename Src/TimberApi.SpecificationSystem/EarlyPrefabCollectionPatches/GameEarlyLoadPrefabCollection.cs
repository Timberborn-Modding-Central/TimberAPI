using TimberApi.SingletonSystem;
using Timberborn.AssetSystem;
using Timberborn.BlueprintSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.GameScene;
using Timberborn.PrefabGroupSystem;
using Timberborn.SingletonSystem;
using Timberborn.SoundSystem;
using Timberborn.WorldPersistence;
using UnityEngine;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

/**
 * For making the specification generator faster in the lifecycle, we need all prefabs that is going to be loaded in the scene.
 * This requires the faction, so we need to load it as early as possible.
 * By doing this code that requires generated specification based on models don't need to do magic and can keep in their normal lifecycle. eg. BottomBarRework
 */
public class GameEarlyLoadPrefabCollection(
    FactionService factionService,
    IWorldSaveSupplier worldSaveSupplier,
    PrefabGroupService prefabGroupService,
    FactionSpecService factionSpecificationService,
    ISpecService specService)
    : ITimberApiLoadableSingleton
{
    public void Load()
    {
        Debug.LogError("I Should be first");
        EarlyLoadPatcher.BlockLoading = false;
        
        ((GameSceneWorldSaveSupplier)worldSaveSupplier).Load();
        specService.Load();
        factionSpecificationService.Load();
        factionService.Load();
        prefabGroupService.Load();
        
        EarlyLoadPatcher.BlockLoading = true;
        Debug.LogError("Finished early load");
    }
}