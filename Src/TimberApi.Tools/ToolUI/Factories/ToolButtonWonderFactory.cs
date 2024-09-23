using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonWonderFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "WonderDefault";

    public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
    {
        return toolButtonFactory.CreateHex(tool, toolGroupSpecification.Icon);
    }
}