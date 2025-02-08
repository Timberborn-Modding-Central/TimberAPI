using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonRedFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "Red";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.Create(tool, toolGroupSpec.Icon, "UI/Images/BottomBar/button-bg-01");
    }
}