using System.Linq;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.InputSystem;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace BluePrint;

public class BlueprintService
{
    private readonly BlueprintRepository _blueprintRepository;

    private readonly BlueprintPreviewPlacerFactory _blueprintPreviewPlacerFactory;

    private readonly BlockObjectPlacerService _blockObjectPlacerService;

    private readonly PrefabNameMapper _prefabNameMapper;
    
    public BlueprintService(BlueprintRepository blueprintRepository, BlueprintPreviewPlacerFactory blueprintPreviewPlacerFactory, BlockObjectPlacerService blockObjectPlacerService, PrefabNameMapper prefabNameMapper)
    {
        _blueprintRepository = blueprintRepository;
        _blueprintPreviewPlacerFactory = blueprintPreviewPlacerFactory;
        _blockObjectPlacerService = blockObjectPlacerService;
        _prefabNameMapper = prefabNameMapper;
    }

    public BlueprintPreviewPlacer LoadBlueprint()
    {
        var blueprint = _blueprintRepository.Get();

        return _blueprintPreviewPlacerFactory.Create(blueprint);
    }
    
    public void PlaceBlueprint(BlueprintPreviewPlacer blueprintPreviewPlacer, Vector3Int coordinate)
    {
        var placements = blueprintPreviewPlacer.GetBuildableCoordinates(coordinate).ToArray();
        
        for (var i = 0; i < placements.Length; i++)
        {
            var prefab = _prefabNameMapper.GetPrefab(blueprintPreviewPlacer.Blueprint.BlueprintItems[i].TemplateName).GetComponentFast<BlockObject>();
            
            var blockObjectPlacer = _blockObjectPlacerService.GetMatchingPlacer(prefab);
            
            blockObjectPlacer.Place(prefab, placements[i]);
        }
    }
}