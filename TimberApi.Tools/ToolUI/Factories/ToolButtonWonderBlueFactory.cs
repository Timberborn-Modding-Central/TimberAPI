using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderBlueFactory : IToolButtonFactory
{
    public string Id => "WonderBlue";
    
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonWonderBlueFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }
    
    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-02");
    }
}