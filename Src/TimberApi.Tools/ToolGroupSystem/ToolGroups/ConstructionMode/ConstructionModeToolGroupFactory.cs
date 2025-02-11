namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.ConstructionMode;

public class ConstructionModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "ConstructionModeToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return new ConstructionModeToolGroup(
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