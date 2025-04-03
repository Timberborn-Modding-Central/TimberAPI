namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.ConstructionMode;

public class ConstructionModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "ConstructionModeToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec toolGroupSpec)
    {
        return new ConstructionModeToolGroup(
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