using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

public class TreeCuttingAreaSelectionToolFactory : IToolFactory
{
    private readonly TreeCuttingAreaSelectionTool _treeCuttingAreaSelectionTool;

    public TreeCuttingAreaSelectionToolFactory(TreeCuttingAreaSelectionTool treeCuttingAreaSelectionTool)
    {
        _treeCuttingAreaSelectionTool = treeCuttingAreaSelectionTool;
    }

    public string Id => "TreeCuttingAreaSelectionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _treeCuttingAreaSelectionTool.ToolGroup = toolGroup;

        return _treeCuttingAreaSelectionTool;
    }
}