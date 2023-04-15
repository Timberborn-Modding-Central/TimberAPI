using System.Linq;
using TimberApi.Common.Extensions;
using Timberborn.AreaSelectionSystem;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.Core;
using Timberborn.InputSystem;
using Timberborn.InventorySystem;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;
using Timberborn.PreviewSystem;
using Timberborn.ToolSystem;
using Timberborn.UISound;
using UnityEngine;

namespace TimberApi.ToolSystem.Tools.PlaceableObject
{
    public class PlaceableObjectToolFactory : BaseToolFactory<PlaceableObjectToolToolInformation>
    {
        public override string Id => "PlaceableObjectTool";

        private readonly ObjectCollectionService _objectCollectionService;

        private readonly BlockObjectToolDescriber _blockObjectToolDescriber;
        
        private readonly InputService _inputService;
        
        private readonly AreaPickerFactory _areaPickerFactory;
        
        private readonly PreviewPlacerFactory _previewPlacerFactory;
        
        private readonly UISoundController _uiSoundController;
        
        private readonly BlockObjectPlacerService _blockObjectPlacerService;
        
        private readonly MapEditorMode _mapEditorMode;
        
        public PlaceableObjectToolFactory(
            ObjectCollectionService objectCollectionService,
            BlockObjectToolDescriber blockObjectToolDescriber,
            InputService inputService,
            AreaPickerFactory areaPickerFactory,
            PreviewPlacerFactory previewPlacerFactory,
            UISoundController uiSoundController,
            BlockObjectPlacerService blockObjectPlacerService,
            MapEditorMode mapEditorMode)
        {
            _objectCollectionService = objectCollectionService;
            _blockObjectToolDescriber = blockObjectToolDescriber;
            _inputService = inputService;
            _areaPickerFactory = areaPickerFactory;
            _previewPlacerFactory = previewPlacerFactory;
            _uiSoundController = uiSoundController;
            _blockObjectPlacerService = blockObjectPlacerService;
            _mapEditorMode = mapEditorMode;
        }
        
        public override Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            var toolInformation = GetToolInformation(toolSpecification);
            var prefab = _objectCollectionService.GetAllMonoBehaviours<Prefab>().Single(o => o.IsNamed(toolInformation.PrefabName));
            var placeableBlockObject = prefab.GetComponentFast<PlaceableBlockObject>();

            placeableBlockObject.SetPrivateInstanceFieldValue("_devModeTool", toolSpecification.DevModeTool);
            placeableBlockObject.SetPrivateInstanceFieldValue("_toolOrder", toolSpecification.Order);

            var blockObjectTool = new BlockObjectTool(_blockObjectToolDescriber, _inputService, _areaPickerFactory, _previewPlacerFactory, _uiSoundController, _blockObjectPlacerService, _mapEditorMode);

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