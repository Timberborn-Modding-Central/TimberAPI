using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishableSelectionToolFactory(DemolishableSelectionTool demolishableSelectionTool) : IToolFactory
{
    public string Id => "DemolishableSelectionTool";

    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        demolishableSelectionTool.Initialize(toolGroup);
        return demolishableSelectionTool;
    }
}