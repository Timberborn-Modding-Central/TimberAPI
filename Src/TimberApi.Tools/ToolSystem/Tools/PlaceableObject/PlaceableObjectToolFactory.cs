using System.Linq;
using Timberborn.AreaSelectionSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.InputSystem;
using Timberborn.PrefabSystem;
using Timberborn.ToolSystem;
using Timberborn.UISound;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public class PlaceableObjectToolFactory(
    PrefabService prefabService,
    InputService inputService,
    PreviewPlacerFactory previewPlacerFactory,
    UISoundController uiSoundController,
    ToolUnlockingService toolUnlockingService,
    BlockObjectToolDescriber blockObjectToolDescriber,
    AreaPickerFactory areaPickerFactory,
    BlockObjectPlacerService blockObjectPlacerService) : IToolFactory
{
    public string Id => "PlaceableObjectTool";
    
    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        var placeableObjectToolSpec = toolSpec.GetSpec<PlaceableObjectToolSpec>();
        
        var prefab = prefabService.GetAll<PrefabSpec>().Single(o => o.IsNamed(placeableObjectToolSpec.PrefabName));
        var placeableBlockObject = prefab.GetComponentFast<PlaceableBlockObjectSpec>();

        placeableBlockObject._devModeTool = toolSpec.DevMode;
        placeableBlockObject._toolOrder = toolSpec.Order;
        
        var matchingPlacer = blockObjectPlacerService.GetMatchingPlacer(prefab.GetComponentFast<BlockObjectSpec>());
        var previewPlacer = previewPlacerFactory.Create(placeableBlockObject);
        
        return new BlockObjectTool(
            placeableBlockObject,
            toolGroup,
            inputService,
            areaPickerFactory,
            uiSoundController,
            toolUnlockingService,
            matchingPlacer,
            blockObjectToolDescriber,
            previewPlacer
        );
    }
}
