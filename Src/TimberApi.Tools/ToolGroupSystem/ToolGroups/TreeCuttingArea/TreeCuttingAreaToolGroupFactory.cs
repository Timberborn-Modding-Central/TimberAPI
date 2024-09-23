namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.TreeCuttingArea;

public class TreeCuttingAreaToolGroupFactory : IToolGroupFactory
{
    public string Id => "TreeCuttingAreaToolGroup";

    public IToolGroup Create(ToolGroupSpecification toolGroupSpecification)
    {
        return new TreeCuttingAreaToolGroup(
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