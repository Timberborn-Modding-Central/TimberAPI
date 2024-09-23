using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.TreeCuttingArea;

public class TreeCuttingAreaUnselectionToolFactory : IToolFactory
{
    private readonly TreeCuttingAreaUnselectionTool _treeCuttingAreaUnselectionTool;

    public TreeCuttingAreaUnselectionToolFactory(TreeCuttingAreaUnselectionTool treeCuttingAreaUnselectionTool)
    {
        _treeCuttingAreaUnselectionTool = treeCuttingAreaUnselectionTool;
    }

    public string Id => "TreeCuttingAreaUnselectionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _treeCuttingAreaUnselectionTool.ToolGroup = toolGroup;

        return _treeCuttingAreaUnselectionTool;
    }
}