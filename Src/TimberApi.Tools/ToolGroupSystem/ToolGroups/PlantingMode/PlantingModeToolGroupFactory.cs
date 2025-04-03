namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;

public class PlantingModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "PlantingModeToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec toolGroupSpec)
    {
        return new PlantingModeToolGroup(
            toolGroupSpec.Id,
            toolGroupSpec.GroupId,
            toolGroupSpec.Order,
            toolGroupSpec.Section,
            toolGroupSpec.NameLocKey,
            toolGroupSpec.DevMode,
            toolGroupSpec.Icon
        );
    }
}