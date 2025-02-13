using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem.ToolGroups.PlantingMode;

public class PlantingModeToolGroupFactory : IToolGroupFactory
{
    public string Id => "PlantingModeToolGroup";

    public IToolGroup Create(ToolGroupSpec toolGroupSpec)
    {
        var toolGroupExtensionSpec = toolGroupSpec.GetSpec<ToolGroupExtensionSpec>();
        
        return new PlantingModeToolGroup(
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