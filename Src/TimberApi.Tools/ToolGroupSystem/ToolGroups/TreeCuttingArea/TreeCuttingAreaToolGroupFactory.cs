namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.TreeCuttingArea;

public class TreeCuttingAreaToolGroupFactory : IToolGroupFactory
{
    public string Id => "TreeCuttingAreaToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return new TreeCuttingAreaToolGroup(
            timberApiToolGroupSpec.Id,
            timberApiToolGroupSpec.GroupId,
            timberApiToolGroupSpec.Order,
            timberApiToolGroupSpec.Section,
            timberApiToolGroupSpec.NameLocKey,
            timberApiToolGroupSpec.DevMode,
            timberApiToolGroupSpec.Icon
        );
    }
}