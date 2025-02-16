using TimberApi.SpecificationSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.ConstructionMode;

public class ConstructionModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "ConstructionModeToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        var toolGroupExtensionSpec = toolGroupSpec.GetSpecOrDefault<ToolGroupExtensionSpec>();
        
        return new ConstructionModeToolGroup(
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