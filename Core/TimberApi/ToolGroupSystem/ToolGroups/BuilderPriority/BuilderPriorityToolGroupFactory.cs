namespace TimberApi.ToolGroupSystem.ToolGroups.BuilderPriority
{
    public class BuilderPriorityToolGroupFactory : IToolGroupFactory
    {
        public string Id => "BuilderPriorityToolGroup";

        public IToolGroup Create(ToolGroupSpecification toolGroupSpecification)
        {
            return new BuilderPriorityToolGroup(
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