namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;

public class PlantingModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "PlantingModeToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec timberApiToolGroupSpec)
    {
        return new PlantingModeToolGroup(
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