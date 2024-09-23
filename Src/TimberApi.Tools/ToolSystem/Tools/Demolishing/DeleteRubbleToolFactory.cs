using Timberborn.RecoveredGoodSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DeleteRubbleToolFactory : IToolFactory
{
    private readonly RecoveredGoodStackDeletionTool _recoveredGoodStackDeletionTool;

    public DeleteRubbleToolFactory(RecoveredGoodStackDeletionTool recoveredGoodStackDeletionTool)
    {
        _recoveredGoodStackDeletionTool = recoveredGoodStackDeletionTool;
    }

    public string Id => "DeleteRecoveredGoodStackTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _recoveredGoodStackDeletionTool.Initialize(toolGroup);
        return _recoveredGoodStackDeletionTool;
    }
}