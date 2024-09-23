using System;
using TimberApi.Tools.ToolGroupSystem;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using Timberborn.Localization;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Tools.ToolGroupUI;

public class ToolGroupButtonFactory(
    EventBus eventBus,
    ToolGroupManager toolGroupManager,
    VisualElementLoader visualElementLoader,
    ToolButtonService toolButtonService,
    ILoc loc,
    IAssetLoader assetLoader)
{
    public ToolGroupButton Create(ToolGroup toolGroup, Sprite toolGroupImage, string backgroundImage)
    {
        return Create(toolGroup, toolGroupImage, assetLoader.Load<Sprite>(backgroundImage));
    }

    public ToolGroupButton Create(ToolGroup toolGroup, Sprite toolGroupImage, Sprite backgroundImage)
    {
        var visualElement = visualElementLoader.LoadVisualElement("Common/BottomBar/ToolGroupButton");
        visualElement.Q<VisualElement>("ToolGroupButtonWrapper").Q<VisualElement>("").style.backgroundImage =
            new StyleBackground(backgroundImage);
        InitializeElement(visualElement, toolGroup, toolGroupImage);
        var toolGroupButton = new ToolGroupButton(loc,
            toolGroupManager,
            toolGroup,
            visualElement,
            visualElement.Q<VisualElement>("ToolButtons"),
            visualElement.Q<VisualElement>("ToolGroupButtonWrapper"));
        eventBus.Register(toolGroupButton);
        Add((IToolGroup)toolGroup, toolGroupButton);
        return toolGroupButton;
    }

    private void InitializeElement(VisualElement root, ToolGroup toolGroup, Sprite toolGroupImage)
    {
        var button = root.Q<Button>("ToolGroupButton");
        var tooltip = root.Q<Label>("Tooltip");
        button.RegisterCallback((EventCallback<MouseEnterEvent>)(_ => tooltip.parent.ToggleDisplayStyle(true)));
        button.RegisterCallback((EventCallback<MouseLeaveEvent>)(_ => tooltip.parent.ToggleDisplayStyle(false)));
        button.clicked += (Action)(() => OnButtonClick(tooltip, toolGroup));
        button.style.backgroundImage = new StyleBackground(toolGroupImage);
        tooltip.parent.ToggleDisplayStyle(false);
        root.Q<VisualElement>("ToolButtons").ToggleDisplayStyle(false);
    }

    private void OnButtonClick(VisualElement tooltip, ToolGroup toolGroup)
    {
        if (toolGroupManager.ActiveToolGroup == toolGroup)
        {
            toolGroupManager.CloseToolGroup();
        }
        else
        {
            toolGroupManager.SwitchToolGroup(toolGroup);
            tooltip.parent.ToggleDisplayStyle(false);
        }
    }

    private void Add(IToolGroup toolGroup, ToolGroupButton toolButton)
    {
        toolButtonService._toolGroupButtons.Add(toolButton);

        if (toolGroup.GroupId == null) toolButtonService._rootButtons.Add(toolButton);
    }
}