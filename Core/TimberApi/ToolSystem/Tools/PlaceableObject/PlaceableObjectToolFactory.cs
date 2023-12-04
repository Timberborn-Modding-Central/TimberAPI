using System.Linq;
using Timberborn.AreaSelectionSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.Core;
using Timberborn.InputSystem;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;
using Timberborn.PreviewSystem;
using Timberborn.ToolSystem;
using Timberborn.UISound;

namespace TimberApi.ToolSystem.Tools.PlaceableObject
{
    public class PlaceableObjectToolFactory : BaseToolFactory<PlaceableObjectToolToolInformation>
    {
        private readonly AreaPickerFactory _areaPickerFactory;

        private readonly BlockObjectPlacerService _blockObjectPlacerService;

        private readonly BlockObjectToolDescriber _blockObjectToolDescriber;

        private readonly InputService _inputService;

        private readonly MapEditorMode _mapEditorMode;

        private readonly ObjectCollectionService _objectCollectionService;

        private readonly PreviewPlacerFactory _previewPlacerFactory;

        private readonly UISoundController _uiSoundController;

        private readonly ToolUnlockingService _toolUnlockingService;

        public PlaceableObjectToolFactory(
            ObjectCollectionService objectCollectionService,
            BlockObjectToolDescriber blockObjectToolDescriber,
            InputService inputService,
            AreaPickerFactory areaPickerFactory,
            PreviewPlacerFactory previewPlacerFactory,
            UISoundController uiSoundController,
            BlockObjectPlacerService blockObjectPlacerService,
            MapEditorMode mapEditorMode,
            ToolUnlockingService toolUnlockingService)
        {
            _objectCollectionService = objectCollectionService;
            _blockObjectToolDescriber = blockObjectToolDescriber;
            _inputService = inputService;
            _areaPickerFactory = areaPickerFactory;
            _previewPlacerFactory = previewPlacerFactory;
            _uiSoundController = uiSoundController;
            _blockObjectPlacerService = blockObjectPlacerService;
            _mapEditorMode = mapEditorMode;
            _toolUnlockingService = toolUnlockingService;
        }

        public override string Id => "PlaceableObjectTool";
        
        protected override Tool CreateTool(ToolSpecification toolSpecification, PlaceableObjectToolToolInformation toolInformation, ToolGroup? toolGroup)
        {
            var prefab = _objectCollectionService.GetAllMonoBehaviours<Prefab>().Single(o => o.IsNamed(toolInformation.PrefabName));
            var placeableBlockObject = prefab.GetComponentFast<PlaceableBlockObject>();
            
            placeableBlockObject._devModeTool = toolSpecification.DevMode;
            placeableBlockObject._toolOrder = toolSpecification.Order;

            var blockObjectTool = new BlockObjectTool(
                _blockObjectToolDescriber, 
                _inputService, 
                _areaPickerFactory, 
                _previewPlacerFactory, 
                _uiSoundController, 
                _blockObjectPlacerService,
                _mapEditorMode,
                _toolUnlockingService);

            if(toolGroup == null)
            {
                blockObjectTool.Initialize(placeableBlockObject);
            }
            else
            {
                blockObjectTool.Initialize(placeableBlockObject, toolGroup);
            }

            return blockObjectTool;
        }

        protected override PlaceableObjectToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new PlaceableObjectToolToolInformation(objectLoader.Get(new PropertyKey<string>("PrefabName")));
        }
    }
}