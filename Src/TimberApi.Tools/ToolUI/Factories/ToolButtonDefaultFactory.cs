using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI.Factories;

public class ToolButtonDefaultFactory(ToolButtonFactory toolButtonFactory) : IToolButtonFactory
{
    public string Id => "Default";

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec)
    {
        return toolButtonFactory.Create(tool, toolGroupSpec.Icon);
    }
}