namespace TimberApi.ToolGroupSystem.ToolGroups.PlantingMode
{
    public class PlantingModeToolGroupFactory : IToolGroupFactory
    {
        public string Id => "PlantingModeToolGroup";

        public ApiToolGroup Create(ToolGroupSpecification toolGroupSpecification)
        {
            return new PlantingModeToolGroup(
                toolGroupSpecification.Id,
                toolGroupSpecification.GroupId,
                toolGroupSpecification.Section,
                toolGroupSpecification.NameLocKey,
                toolGroupSpecification.DevMode,
                toolGroupSpecification.Icon
            );
        }
    }
}