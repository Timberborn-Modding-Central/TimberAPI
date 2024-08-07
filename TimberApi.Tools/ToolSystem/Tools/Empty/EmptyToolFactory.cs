using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Empty;

public class EmptyToolFactory : IToolFactory
{
    public string Id => "EmptyTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return new EmptyTool();
    }
}