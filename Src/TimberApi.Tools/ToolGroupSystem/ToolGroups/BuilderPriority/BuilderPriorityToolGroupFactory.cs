namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.BuilderPriority;

public class BuilderPriorityToolGroupFactory : IToolGroupFactory
{
    public string Id => "BuilderPriorityToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return new BuilderPriorityToolGroup(
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