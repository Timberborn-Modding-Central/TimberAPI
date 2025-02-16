using TimberApi.SpecificationSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.TreeCuttingArea;

public class TreeCuttingAreaToolGroupFactory : IToolGroupFactory
{
    public string Id => "TreeCuttingAreaToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        var toolGroupExtensionSpec = toolGroupSpec.GetSpecOrDefault<ToolGroupExtensionSpec>();
        
        return new TreeCuttingAreaToolGroup(
            toolGroupSpec.Id,
            toolGroupExtensionSpec.GroupId,
            toolGroupSpec.Order,
            toolGroupExtensionSpec.Section,
            toolGroupSpec.NameLocKey,
            toolGroupExtensionSpec.DevMode,
            toolGroupSpec.Icon
        );
    }
}