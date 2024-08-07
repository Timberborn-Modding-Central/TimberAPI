using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonRedFactory : IToolButtonFactory
{
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonRedFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }

    public string Id => "Red";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.Create(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-01");
    }
}