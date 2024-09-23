using System.Linq;
using Timberborn.AreaSelectionSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.InputSystem;
using Timberborn.Persistence;
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
    BlockObjectPlacerService blockObjectPlacerService)
    : BaseToolFactory<PlaceableObjectToolToolInformation>
{
    public override string Id => "PlaceableObjectTool";

    protected override Tool CreateTool(ToolSpecification toolSpecification,
        PlaceableObjectToolToolInformation toolInformation, ToolGroup? toolGroup)
    {
        var prefab = prefabService.GetAll<Prefab>().Single(o => o.IsNamed(toolInformation.PrefabName));
        var placeableBlockObject = prefab.GetComponentFast<PlaceableBlockObject>();

        placeableBlockObject._devModeTool = toolSpecification.DevMode;
        placeableBlockObject._toolOrder = toolSpecification.Order;
        
        var matchingPlacer = blockObjectPlacerService.GetMatchingPlacer(prefab.GetComponentFast<BlockObject>());
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

    protected override PlaceableObjectToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
    {
        return new PlaceableObjectToolToolInformation(objectLoader.Get(new PropertyKey<string>("PrefabName")));
    }
}
