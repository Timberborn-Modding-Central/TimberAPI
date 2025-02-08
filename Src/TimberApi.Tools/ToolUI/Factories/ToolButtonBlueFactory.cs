using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonBlueFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "Blue";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.Create(tool, toolGroupSpec.Icon, "UI/Images/BottomBar/button-bg-02");
    }
}