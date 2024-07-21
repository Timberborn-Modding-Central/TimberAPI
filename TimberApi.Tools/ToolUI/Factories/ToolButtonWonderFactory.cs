using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderFactory : IToolButtonFactory
{
    public string Id => "WonderDefault";
    
    private readonly ToolButtonFactory _toolButtonFactory;

    public ToolButtonWonderFactory(ToolButtonFactory toolButtonFactory)
    {
        _toolButtonFactory = toolButtonFactory;
    }
    
    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return _toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon);
    }
}