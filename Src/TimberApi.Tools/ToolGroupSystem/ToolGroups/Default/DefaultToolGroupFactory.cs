namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.Default;

public class DefaultToolGroupFactory : IToolGroupFactory
{
    public string Id => "DefaultToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return new ApiToolGroup(
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