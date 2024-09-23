using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderBrownFactory : IToolButtonFactory
{
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonWonderBrownFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }

    public string Id => "WonderBrown";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}