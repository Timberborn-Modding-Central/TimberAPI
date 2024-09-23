using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

public class TreeCuttingAreaUnselectionToolFactory(TreeCuttingAreaUnselectionTool treeCuttingAreaUnselectionTool)
    : IToolFactory
{
    public string Id => "TreeCuttingAreaUnselectionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        treeCuttingAreaUnselectionTool.ToolGroup = toolGroup;

        return treeCuttingAreaUnselectionTool;
    }
}