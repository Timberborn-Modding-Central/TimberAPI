using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonGrouplessBrownFactory : IToolButtonFactory
{
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonGrouplessBrownFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }

    public string Id => "GrouplessBrown";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/subbutton-bg-01");
    }
}