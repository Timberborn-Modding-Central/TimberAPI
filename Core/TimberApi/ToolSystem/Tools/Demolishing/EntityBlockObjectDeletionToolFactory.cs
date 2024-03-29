using Timberborn.BlockObjectTools;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Demolishing
{
    public class EntityBlockObjectDeletionToolFactory : IToolFactory
    {
        public string Id => "EntityBlockObjectDeletionTool";

        private readonly EntityBlockObjectDeletionTool _entityBlockObjectDeletionTool;

        public EntityBlockObjectDeletionToolFactory(EntityBlockObjectDeletionTool entityBlockObjectDeletionTool)
        {
            _entityBlockObjectDeletionTool = entityBlockObjectDeletionTool;
        }
        
        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _entityBlockObjectDeletionTool.Initialize(toolGroup);
            return _entityBlockObjectDeletionTool;
        }
    }
}