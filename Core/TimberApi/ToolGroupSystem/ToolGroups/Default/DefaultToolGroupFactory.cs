namespace TimberApi.ToolGroupSystem.ToolGroups.Default
{
    public class DefaultToolGroupFactory : IToolGroupFactory
    {
        public string Id => "DefaultToolGroup";

        public ApiToolGroup Create(ToolGroupSpecification toolGroupSpecification)
        {
            return new ApiToolGroup(
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