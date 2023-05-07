namespace TimberApi.ToolGroupSystem.ToolGroups.ConstructionMode
{
    public class ConstructionModeToolGroupFactory : IToolGroupFactory
    {
        public string Id => "ConstructionModeToolGroup";

        public IToolGroup Create(ToolGroupSpecification toolGroupSpecification)
        {
            return new ConstructionModeToolGroup(
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
}