using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishableUnselectionToolFactory(DemolishableUnselectionTool demolishableUnselectionTool) : IToolFactory
{
    public string Id => "DemolishableUnselectionTool";

    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        demolishableUnselectionTool.Initialize(toolGroup);
        return demolishableUnselectionTool;
    }
}