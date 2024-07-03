namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.Default;

public class DefaultToolGroupFactory : IToolGroupFactory
{
    public string Id => "DefaultToolGroup";

    public IToolGroup Create(ToolGroupSpecification toolGroupSpecification)
    {
        return new ApiToolGroup(
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