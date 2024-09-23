using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderBrownFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "WonderBrown";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}