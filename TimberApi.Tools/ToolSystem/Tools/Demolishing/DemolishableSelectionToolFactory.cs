using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishableSelectionToolFactory : IToolFactory
{
    private readonly DemolishableSelectionTool _demolishableSelectionTool;

    public DemolishableSelectionToolFactory(DemolishableSelectionTool demolishableSelectionTool)
    {
        _demolishableSelectionTool = demolishableSelectionTool;
    }

    public string Id => "DemolishableSelectionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _demolishableSelectionTool.Initialize(toolGroup);
        return _demolishableSelectionTool;
    }
}