using TimberApi.SingletonSystem;
using Timberborn.BlueprintSystem;
using Timberborn.FactionSystem;
using Timberborn.GameFactionSystem;
using Timberborn.GameScene;
using Timberborn.TemplateCollectionSystem;
using Timberborn.WorldPersistence;

namespace TimberApi.SpecificationSystem.EarlyPrefabCollectionPatches;

/**
 * For making the specification generator faster in the lifecycle, we need all prefabs that is going to be loaded in the scene.
 * This requires the faction, so we need to load it as early as possible.
 * By doing this code that requires generated specification based on models don't need to do magic and can keep in their normal lifecycle. eg. BottomBarRework
 */
public class GameEarlyLoadPrefabCollection(
    FactionService factionService,
    ISerializedWorldSupplier worldEntitiesLoader,
    TemplateCollectionService templateCollectionService,
    FactionSpecService factionSpecificationService,
    ISpecService specService)
    : ITimberApiLoadableSingleton
{
    public void Load()
    {
        EarlyLoadPatcher.BlockLoading = false;
        
        ((GameSceneSerializedWorldSupplier)worldEntitiesLoader).Load();
        
        ((SpecService)specService).Load();
        factionSpecificationService.Load();
        factionService.Load();
         
        templateCollectionService.Load();
        
        EarlyLoadPatcher.BlockLoading = true;
    }
}