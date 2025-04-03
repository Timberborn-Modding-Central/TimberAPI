namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.Default;

public class DefaultToolGroupFactory : IToolGroupFactory
{
    public string Id => "DefaultToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec toolGroupSpec)
    {
        return new ApiToolGroup(
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