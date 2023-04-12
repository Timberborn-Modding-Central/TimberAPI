using System;
using HarmonyLib;
using TimberApi.Common.Extensions;
using TimberApi.DependencyContainerSystem;
using Timberborn.AreaSelectionSystem;
using Timberborn.BuilderPrioritySystemUI;
using Timberborn.CoreUI;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using Timberborn.UISound;
using UnityEngine;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolFactory : BaseToolFactory<BuilderPriorityToolToolInformation>, ILoadableSingleton
    {
        private readonly AreaBlockObjectPickerFactory _areaBlockObjectPickerFactory;
        
        private readonly InputService _inputService;
        
        private readonly BlockObjectSelectionDrawerFactory _blockObjectSelectionDrawerFactory;
        
        private readonly CursorService _cursorService;
        
        private readonly ILoc _loc;
        
        private readonly BuilderPrioritizableHighlighter _builderPrioritizableHighlighter;

        private object _builderPrioritizableHighlighter2;

        private readonly UISoundController _uiSoundController;
        
        private readonly Colors _colors;
        
        public BuilderPriorityToolFactory(
            AreaBlockObjectPickerFactory areaBlockObjectPickerFactory,
            InputService inputService,
            BlockObjectSelectionDrawerFactory blockObjectSelectionDrawerFactory,
            CursorService cursorService,
            ILoc loc,
            BuilderPrioritizableHighlighter builderPrioritizableHighlighter,
            UISoundController uiSoundController,
            Colors colors)
        {
            _areaBlockObjectPickerFactory = areaBlockObjectPickerFactory;
            _inputService = inputService;
            _blockObjectSelectionDrawerFactory = blockObjectSelectionDrawerFactory;
            _cursorService = cursorService;
            _loc = loc;
            _builderPrioritizableHighlighter = builderPrioritizableHighlighter;
            _uiSoundController = uiSoundController;
            _colors = colors;
        }
    
        public override string Id => "PriorityTool";
    
        public override Tool Create(ToolSpecification toolSpecification)
        {
            throw new NotSupportedException("PlantingTool requires a ToolGroup");
        }
    
        public override Tool Create(ToolSpecification toolSpecification, ToolGroup toolGroup)
        {
            var toolInformation = GetToolInformation(toolSpecification);

            TypeExtensions.CreateInstance<object>(_builderPrioritizableHighlighter2.GetType());
    
            var builderPriorityTool = new BuilderPriorityTool(_areaBlockObjectPickerFactory, _inputService, _blockObjectSelectionDrawerFactory, _cursorService, _loc, _builderPrioritizableHighlighter2, _uiSoundController);
            builderPriorityTool.Initialize(toolInformation.Priority, _colors.PriorityHiglightColor, _colors.PriorityActionColor, _colors.PriorityTileColor, _colors.PrioritySideColor, toolGroup);
            
            return builderPriorityTool;
        }
    
        protected override BuilderPriorityToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new BuilderPriorityToolToolInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
        }

        public void Load()
        {
            _builderPrioritizableHighlighter2 = DependencyContainer.GetInstance(AccessTools.TypeByName("Timberborn.BuilderPrioritySystemUI.BuilderPrioritizableHighlighter"));
        }
    }
}