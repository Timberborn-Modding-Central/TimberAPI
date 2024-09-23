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

public class ToolButtonFactory(
    EventBus eventBus,
    ToolManager toolManager,
    DevModeManager devModeManager,
    VisualElementLoader visualElementLoader,
    ToolButtonService toolButtonService,
    ToolGroupManager toolGroupManager,
    MapEditorMode mapEditorMode,
    IAssetLoader assetLoader)
{
    public ToolButton Create(Tool tool, string toolImagePath)
    {
        var toolImage = assetLoader.Load<Sprite>(toolImagePath);
        return Create(tool, toolImage);
    }
    
    public ToolButton Create(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = assetLoader.Load<Sprite>(toolImagePath);
        return Create(tool, toolImage, backgroundImage);
    }

    public ToolButton Create(Tool tool, Sprite toolImage)
    {
        var root = visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButton");
        return Create(tool, toolImage, root);
    }

    public ToolButton Create(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButton");

        root.Q<VisualElement>("Background").style.backgroundImage =
            new StyleBackground(assetLoader.Load<Sprite>(backgroundImage));
        return Create(tool, toolImage, root);
    }
    
    public ToolButton CreateGroupless(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = assetLoader.Load<Sprite>(toolImagePath);

        return CreateGroupless(tool, toolImage, backgroundImage);
    }

    public ToolButton CreateGroupless(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = visualElementLoader.LoadVisualElement("Common/BottomBar/GrouplessToolButton");

        root.Children().First().style.backgroundImage = new StyleBackground(assetLoader.Load<Sprite>(backgroundImage));
        return Create(tool, toolImage, root);
    }

    public ToolButton CreateHex(Tool tool, string toolImagePath)
    {
        var toolImage = assetLoader.Load<Sprite>(toolImagePath);
        return CreateHex(tool, toolImage);
    }    
    
    public ToolButton CreateHex(Tool tool, string toolImagePath, string backgroundImage)
    {
        var toolImage = assetLoader.Load<Sprite>(toolImagePath);
        return CreateHex(tool, toolImage, backgroundImage);
    }    
    
    public ToolButton CreateHex(Tool tool, Sprite toolImage)
    {
        var content = visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButtonHex");
        return Create(tool, toolImage, content);
    }

    public ToolButton CreateHex(Tool tool, Sprite toolImage, string backgroundImage)
    {
        var root = visualElementLoader.LoadVisualElement("Common/BottomBar/ToolButtonHex");
        root.Children().First().style.backgroundImage = new StyleBackground(assetLoader.Load<Sprite>(backgroundImage));

        return Create(tool, toolImage, root);
    }


    public ToolButton Create(Tool tool, Sprite toolImage, VisualElement root)
    {
        root.Q<VisualElement>("ToolImage").style.backgroundImage = new StyleBackground(toolImage);
        var button = new ToolButton(toolManager, devModeManager, toolGroupManager, mapEditorMode, tool, root,
            root.Q<Button>());
        eventBus.Register(button);
        toolButtonService.Add(button);
        return button;
    }
}