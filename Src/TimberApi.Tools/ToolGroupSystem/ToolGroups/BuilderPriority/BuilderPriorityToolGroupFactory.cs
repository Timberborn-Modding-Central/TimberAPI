using TimberApi.SpecificationSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.BuilderPriority;

public class BuilderPriorityToolGroupFactory : IToolGroupFactory
{
    public string Id => "BuilderPriorityToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        var toolGroupExtensionSpec = toolGroupSpec.GetSpecOrDefault<ToolGroupExtensionSpec>();
        
        
        return new BuilderPriorityToolGroup(
            toolGroupSpec.Id,
            toolGroupExtensionSpec?.GroupId,
            toolGroupSpec.Order,
            toolGroupExtensionSpec!.Section,
            toolGroupSpec.NameLocKey,
            toolGroupExtensionSpec.DevMode,
            toolGroupSpec.Icon
        );
    }
}