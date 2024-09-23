using Timberborn.BlockObjectTools;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class EntityBlockObjectDeletionToolFactory(EntityBlockObjectDeletionTool entityBlockObjectDeletionTool)
    : IToolFactory
{
    public string Id => "EntityBlockObjectDeletionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        entityBlockObjectDeletionTool.Initialize(toolGroup);
        return entityBlockObjectDeletionTool;
    }
}