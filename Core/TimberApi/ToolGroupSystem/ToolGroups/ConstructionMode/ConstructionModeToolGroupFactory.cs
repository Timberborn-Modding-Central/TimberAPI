namespace TimberApi.ToolGroupSystem.ToolGroups.ConstructionMode
{
    public class ConstructionModeToolGroupFactory : IToolGroupFactory
    {
        public string Id => "ConstructionModeToolGroup";

        public ApiToolGroup Create(ToolGroupSpecification toolGroupSpecification)
        {
            return new ConstructionModeToolGroup(
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