using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.Default;

public class DefaultToolGroupFactory : IToolGroupFactory
{
    public string Id => "DefaultToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        var toolGroupExtensionSpec = toolGroupSpec.GetSpec<ToolGroupExtensionSpec>();
        
        return new ApiToolGroup(
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