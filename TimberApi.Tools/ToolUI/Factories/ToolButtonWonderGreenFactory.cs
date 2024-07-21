using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderGreenFactory : IToolButtonFactory
{
    public string Id => "WonderGreen";
    
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonWonderGreenFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }
    
    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-03");
    }
}