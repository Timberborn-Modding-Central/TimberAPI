using TimberApi.SingletonSystem;
using Timberborn.BlueprintSystem;
using Timberborn.PrefabGroupSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

/**
 * For making the specification generator faster in the lifecycle, we need all prefabs that is going to be loaded in the scene.
 * This requires the faction, so we need to load it as early as possible.
 * By doing this code that requires generated specification based on models don't need to do magic and can keep in their normal lifecycle. eg. BottomBarRework
 */
public class MapEditorEarlyLoadPrefabCollection(PrefabGroupService prefabGroupService, ISpecService specService) : ITimberApiLoadableSingleton
{
    public void Load()
    {
        EarlyLoadPatcher.BlockLoading = false;

        specService.Load();
        prefabGroupService.Load();

        EarlyLoadPatcher.BlockLoading = true;
    }
}