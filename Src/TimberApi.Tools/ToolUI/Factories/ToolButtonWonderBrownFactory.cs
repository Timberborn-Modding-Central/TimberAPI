using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderBrownFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "WonderBrown";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.CreateHex(tool, toolGroupSpec.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}