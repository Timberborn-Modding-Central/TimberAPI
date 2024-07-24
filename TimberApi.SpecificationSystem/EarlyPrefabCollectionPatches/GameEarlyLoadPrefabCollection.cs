using TimberApi.SingletonSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.GameScene;
using Timberborn.PrefabGroupSystem;
using Timberborn.WorldPersistence;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

/**
 * For making the specification generator faster in the lifecycle, we need all prefabs that is going to be loaded in the scene.
 * This requires the faction, so we need to load it as early as possible.
 * By doing this code that requires generated specification based on models don't need to do magic and can keep in their normal lifecycle. eg. BottomBarRework
 */
public class GameEarlyLoadPrefabCollection : ITimberApiLoadableSingleton
{
    private readonly FactionService _factionService;
    private readonly FactionSpecificationService _factionSpecificationService;

    private readonly PrefabGroupService _prefabGroupService;

    private readonly IWorldSaveSupplier _worldSaveSupplier;

    public GameEarlyLoadPrefabCollection(FactionService factionService, IWorldSaveSupplier worldSaveSupplier,
        PrefabGroupService prefabGroupService, FactionSpecificationService factionSpecificationService)
    {
        _factionService = factionService;
        _worldSaveSupplier = worldSaveSupplier;
        _prefabGroupService = prefabGroupService;
        _factionSpecificationService = factionSpecificationService;
    }

    public void Load()
    {
        EarlyLoadPatcher.BlockLoading = false;

        ((GameSceneWorldSaveSupplier)_worldSaveSupplier).Load();
        _factionSpecificationService.Load();
        _factionService.Load();
        _prefabGroupService.Load();

        EarlyLoadPatcher.BlockLoading = true;
    }
}