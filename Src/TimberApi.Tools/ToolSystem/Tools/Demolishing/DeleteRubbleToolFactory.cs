using Timberborn.RecoveredGoodSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DeleteRubbleToolFactory(RecoveredGoodStackDeletionTool recoveredGoodStackDeletionTool)
    : IToolFactory
{
    public string Id => "DeleteRecoveredGoodStackTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        recoveredGoodStackDeletionTool.Initialize(toolGroup);
        return recoveredGoodStackDeletionTool;
    }
}