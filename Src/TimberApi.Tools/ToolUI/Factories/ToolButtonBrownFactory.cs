using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonBrownFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "Brown";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.Create(tool, toolGroupSpec.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}