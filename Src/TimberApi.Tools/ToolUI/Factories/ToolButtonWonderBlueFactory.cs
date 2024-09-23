using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderBlueFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "WonderBlue";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-02");
    }
}