using Timberborn.RecoveredGoodSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DeleteRubbleToolFactory : IToolFactory
{
    public string Id => "DeleteRecoveredGoodStackTool";

    private readonly RecoveredGoodStackDeletionTool _recoveredGoodStackDeletionTool;

    public DeleteRubbleToolFactory(RecoveredGoodStackDeletionTool recoveredGoodStackDeletionTool)
    {
        _recoveredGoodStackDeletionTool = recoveredGoodStackDeletionTool;
    }
        
    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _recoveredGoodStackDeletionTool.Initialize(toolGroup);
        return _recoveredGoodStackDeletionTool;
    }
}