using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

public class TreeCuttingAreaSelectionToolFactory(TreeCuttingAreaSelectionTool treeCuttingAreaSelectionTool)
    : IToolFactory
{
    public string Id => "TreeCuttingAreaSelectionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        treeCuttingAreaSelectionTool.ToolGroup = toolGroup;

        return treeCuttingAreaSelectionTool;
    }
}