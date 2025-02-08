namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.BuilderPriority;

public class BuilderPriorityToolGroupFactory : IToolGroupFactory
{
    public string Id => "BuilderPriorityToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        return new BuilderPriorityToolGroup(
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