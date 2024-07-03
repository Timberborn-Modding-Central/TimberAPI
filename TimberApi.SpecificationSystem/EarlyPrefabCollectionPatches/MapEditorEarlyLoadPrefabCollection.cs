using TimberApi.SingletonSystem;
using Timberborn.PrefabGroupSystem;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

/**
 * For making the specification generator faster in the lifecycle, we need all prefabs that is going to be loaded in the scene.
 * This requires the faction, so we need to load it as early as possible.
 * By doing this code that requires generated specification based on models don't need to do magic and can keep in their normal lifecycle. eg. BottomBarRework
 */
public class MapEditorEarlyLoadPrefabCollection : ITimberApiLoadableSingleton
{
    private readonly PrefabGroupService _prefabGroupService;

    public MapEditorEarlyLoadPrefabCollection(PrefabGroupService prefabGroupService)
    {
        _prefabGroupService = prefabGroupService;
    }

    public void Load()
    {
        EarlyLoadPatcher.BlockLoading = false;
        
        _prefabGroupService.Load();

        EarlyLoadPatcher.BlockLoading = true;
    }
}