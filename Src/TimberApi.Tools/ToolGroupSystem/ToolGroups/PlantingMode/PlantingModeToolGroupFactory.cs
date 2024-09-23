namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;

public class PlantingModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "PlantingModeToolGroup";

    public IToolGroup Create(ToolGroupSpecification toolGroupSpecification)
    {
        return new PlantingModeToolGroup(
            toolGroupSpecification.Id,
            toolGroupSpecification.GroupId,
            toolGroupSpecification.Order,
            toolGroupSpecification.Section,
            toolGroupSpecification.NameLocKey,
            toolGroupSpecification.DevMode,
            toolGroupSpecification.Icon
        );
    }
}