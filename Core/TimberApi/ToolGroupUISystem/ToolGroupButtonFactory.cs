using System;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using Timberborn.Localization;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonFactory
    {
        private readonly EventBus _eventBus;

        private readonly ILoc _loc;

        private readonly IResourceAssetLoader _resourceAssetLoader;

        private readonly ToolButtonService _toolButtonService;

        private readonly ToolGroupManager _toolGroupManager;

        private readonly VisualElementLoader _visualElementLoader;

        public ToolGroupButtonFactory(
            EventBus eventBus,
            ToolGroupManager toolGroupManager,
            VisualElementLoader visualElementLoader,
            ToolButtonService toolButtonService,
            ILoc loc,
            IResourceAssetLoader resourceAssetLoader)
        {
            _eventBus = eventBus;
            _toolGroupManager = toolGroupManager;
            _visualElementLoader = visualElementLoader;
            _toolButtonService = toolButtonService;
            _loc = loc;
            _resourceAssetLoader = resourceAssetLoader;
        }

        public ToolGroupButton Create(ToolGroup toolGroup, Sprite toolGroupImage, string backgroundImage)
        {
            return Create(toolGroup, toolGroupImage, _resourceAssetLoader.Load<Sprite>(backgroundImage));
        }

        public ToolGroupButton Create(ToolGroup toolGroup, Sprite toolGroupImage, Sprite backgroundImage)
        {
            var visualElement = _visualElementLoader.LoadVisualElement("Common/BottomBar/ToolGroupButton");
            visualElement.Q<VisualElement>("ToolGroupButtonWrapper").Q<VisualElement>("").style.backgroundImage = new StyleBackground(backgroundImage);
            InitializeElement(visualElement, toolGroup, toolGroupImage);
            var toolGroupButton = new ToolGroupButton(_loc, toolGroup, visualElement, visualElement.Q<VisualElement>("ToolButtons"), visualElement.Q<VisualElement>("ToolGroupButtonWrapper"));
            _eventBus.Register(toolGroupButton);
            _toolButtonService.Add(toolGroupButton);
            return toolGroupButton;
        }

        private void InitializeElement(VisualElement root, ToolGroup toolGroup, Sprite toolGroupImage)
        {
            var button = root.Q<Button>("ToolGroupButton");
            var tooltip = root.Q<Label>("Tooltip");
            button.RegisterCallback((EventCallback<MouseEnterEvent>) (_ => tooltip.parent.ToggleDisplayStyle(true)));
            button.RegisterCallback((EventCallback<MouseLeaveEvent>) (_ => tooltip.parent.ToggleDisplayStyle(false)));
            button.clicked += (Action) (() => OnButtonClick(tooltip, toolGroup));
            button.style.backgroundImage = new StyleBackground(toolGroupImage);
            tooltip.parent.ToggleDisplayStyle(false);
            root.Q<VisualElement>("ToolButtons").ToggleDisplayStyle(false);
        }

        private void OnButtonClick(VisualElement tooltip, ToolGroup toolGroup)
        {
            if(_toolGroupManager.ActiveToolGroup == toolGroup)
            {
                _toolGroupManager.CloseToolGroup();
            }
            else
            {
                _toolGroupManager.SwitchToolGroup(toolGroup);
                tooltip.parent.ToggleDisplayStyle(false);
            }
        }
    }
}