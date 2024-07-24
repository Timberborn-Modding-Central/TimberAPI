using Timberborn.BlockObjectTools;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class EntityBlockObjectDeletionToolFactory : IToolFactory
{
    private readonly EntityBlockObjectDeletionTool _entityBlockObjectDeletionTool;

    public EntityBlockObjectDeletionToolFactory(EntityBlockObjectDeletionTool entityBlockObjectDeletionTool)
    {
        _entityBlockObjectDeletionTool = entityBlockObjectDeletionTool;
    }

    public string Id => "EntityBlockObjectDeletionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _entityBlockObjectDeletionTool.Initialize(toolGroup);
        return _entityBlockObjectDeletionTool;
    }
}