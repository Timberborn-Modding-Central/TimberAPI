using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonGrouplessGreenFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "GrouplessGreen";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon,
            "UI/Images/BottomBar/button-bg-03");
    }
}