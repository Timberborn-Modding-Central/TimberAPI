using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonGrouplessGreenFactory : IToolButtonFactory
{
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonGrouplessGreenFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }

    public string Id => "GrouplessGreen";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-03");
    }
}