using System.Linq;
using Timberborn.AreaSelectionSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.InputSystem;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;
using Timberborn.PreviewSystem;
using Timberborn.ToolSystem;
using Timberborn.UISound;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public class PlaceableObjectToolFactory : BaseToolFactory<PlaceableObjectToolToolInformation>
{
    private readonly AreaPickerFactory _areaPickerFactory;

    private readonly BlockObjectPlacerService _blockObjectPlacerService;

    private readonly BlockObjectToolDescriber _blockObjectToolDescriber;

    private readonly InputService _inputService;
    private readonly PrefabService _prefabService;

    private readonly PreviewPlacerFactory _previewPlacerFactory;

    private readonly ToolUnlockingService _toolUnlockingService;

    private readonly UISoundController _uiSoundController;

    public PlaceableObjectToolFactory(
        PrefabService prefabService, InputService inputService, PreviewPlacerFactory previewPlacerFactory,
        UISoundController uiSoundController, ToolUnlockingService toolUnlockingService,
        BlockObjectToolDescriber blockObjectToolDescriber, AreaPickerFactory areaPickerFactory,
        BlockObjectPlacerService blockObjectPlacerService)
    {
        _prefabService = prefabService;
        _inputService = inputService;
        _previewPlacerFactory = previewPlacerFactory;
        _uiSoundController = uiSoundController;
        _toolUnlockingService = toolUnlockingService;
        _blockObjectToolDescriber = blockObjectToolDescriber;
        _areaPickerFactory = areaPickerFactory;
        _blockObjectPlacerService = blockObjectPlacerService;
    }

    public override string Id => "PlaceableObjectTool";

    protected override Tool CreateTool(ToolSpecification toolSpecification,
        PlaceableObjectToolToolInformation toolInformation, ToolGroup? toolGroup)
    {
        var prefab = _prefabService.GetAllMonoBehaviours<Prefab>()
            .Single(o => o.IsNamed(toolInformation.PrefabName));
        var placeableBlockObject = prefab.GetComponentFast<PlaceableBlockObject>();

        placeableBlockObject._devModeTool = toolSpecification.DevMode;
        placeableBlockObject._toolOrder = toolSpecification.Order;

        var blockObjectTool = new BlockObjectTool(
            _inputService,
            _areaPickerFactory,
            _previewPlacerFactory,
            _uiSoundController,
            _toolUnlockingService,
            _blockObjectToolDescriber
        );

        var matchingPlacer = _blockObjectPlacerService.GetMatchingPlacer(prefab.GetComponentFast<BlockObject>());

        blockObjectTool.Initialize(placeableBlockObject, matchingPlacer, toolGroup);

        return blockObjectTool;
    }

    protected override PlaceableObjectToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
    {
        return new PlaceableObjectToolToolInformation(objectLoader.Get(new PropertyKey<string>("PrefabName")));
    }
}