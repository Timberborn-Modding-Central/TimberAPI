using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonGrouplessBrownFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "GrouplessBrown";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.CreateGroupless(tool, toolGroupSpec.Icon,
            "UI/Images/BottomBar/subbutton-bg-01");
    }
}