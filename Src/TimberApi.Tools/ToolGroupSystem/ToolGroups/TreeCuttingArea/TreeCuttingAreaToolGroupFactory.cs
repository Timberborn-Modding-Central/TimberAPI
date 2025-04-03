namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.TreeCuttingArea;

public class TreeCuttingAreaToolGroupFactory : IToolGroupFactory
{
    public string Id => "TreeCuttingAreaToolGroup";

    public IToolGroup Create(TimberApiToolGroupSpec toolGroupSpec)
    {
        return new TreeCuttingAreaToolGroup(
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