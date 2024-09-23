using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.CoreUI;
using Timberborn.Debugging;
using Timberborn.MapStateSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Tools.ToolUI;

public class ToolButtonFactory
{
    private readonly IAssetLoader _assetLoader;

    private readonly DevModeManager _devModeManager;
    private readonly EventBus _eventBus;

    private readonly MapEditorMode _mapEditorMode;

    private readonly ToolButtonService _toolButtonService;

    private readonly ToolGroupManager _toolGroupManager;

    private readonly ToolManager _toolManager;

    private readonly VisualElementLoader _visualElementLoader;

    public ToolButtonFactory(
        EventBus eventBus,
        ToolManager toolManager,
        DevModeManager devModeManager,
        VisualElementLoader visualElementLoader,
        ToolButtonService toolButtonService,
        ToolGroupManager toolGroupManager,
        MapEditorMode mapEditorMode,
        IAssetLoader assetLoader)
    {
        _eventBus = eventBus;
        _toolManager = toolManager;
        _devModeManager = devModeManager;
        _visualElementLoader = visualElementLoader;
        _toolButtonService = toolButtonService;
        _toolGroupManager = toolGroupManager;
        _mapEditorMode = mapEditorMode;
        _assetLoader = assetLoader;
    }
    
    public ToolButton Create(Tool tool, string toolImagePath)
    {
        var toolImage = _assetLoader.Load<Sprite>(toolImagePath);
        return Create(tool, toolImage);
    }
    
    public ToolButton Create(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = _assetLoader.Load<Sprite>(toolImagePath);
        return Create(tool, toolImage, backgroundImage);
    }

    public ToolButton Create(Tool tool, Sprite toolImage)
    {
        var root = _visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButton");
        return Create(tool, toolImage, root);
    }

    public ToolButton Create(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = _visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButton");

        root.Q<VisualElement>("Background").style.backgroundImage =
            new StyleBackground(_assetLoader.Load<Sprite>(backgroundImage));
        return Create(tool, toolImage, root);
    }
    
    public ToolButton CreateGroupless(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = _assetLoader.Load<Sprite>(toolImagePath);

        return CreateGroupless(tool, toolImage, backgroundImage);
    }

    public ToolButton CreateGroupless(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = _visualElementLoader.LoadVisualElement("Common/BottomBar/GrouplessToolButton");

        root.Children().First().style.backgroundImage = new StyleBackground(_assetLoader.Load<Sprite>(backgroundImage));
        return Create(tool, toolImage, root);
    }

    public ToolButton CreateHex(Tool tool, string toolImagePath)
    {
        var toolImage = _assetLoader.Load<Sprite>(toolImagePath);
        return CreateHex(tool, toolImage);
    }    
    
    public ToolButton CreateHex(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = _assetLoader.Load<Sprite>(toolImagePath);
        return CreateHex(tool, toolImage, backgroundImage);
    }    
    
    public ToolButton CreateHex(Tool tool, Sprite toolImage)
    {
        var content = _visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButtonHex");
        return Create(tool, toolImage, content);
    }

    public ToolButton CreateHex(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = _visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButtonHex");
        root.Children().First().style.backgroundImage = new StyleBackground(_assetLoader.Load<Sprite>(backgroundImage));

        return Create(tool, toolImage, root);
    }


    public ToolButton Create(Tool tool, Sprite toolImage, VisualElement root)
    {
        root.Q<VisualElement>("ToolImage").style.backgroundImage = new StyleBackground(toolImage);
        var button = new ToolButton(_toolManager, _devModeManager, _toolGroupManager, _mapEditorMode, tool, root,
            root.Q<Button>());
        _eventBus.Register(button);
        _toolButtonService.Add(button);
        return button;
    }
}