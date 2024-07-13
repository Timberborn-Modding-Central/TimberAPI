using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class DemolishableSelectionToolFactory : IToolFactory
{
    public string Id => "DemolishableSelectionTool";

    private readonly DemolishableSelectionTool _demolishableSelectionTool;

    public DemolishableSelectionToolFactory(DemolishableSelectionTool demolishableSelectionTool)
    {
        _demolishableSelectionTool = demolishableSelectionTool;
    }
        
    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _demolishableSelectionTool.Initialize(toolGroup);
        return _demolishableSelectionTool;
    }
}