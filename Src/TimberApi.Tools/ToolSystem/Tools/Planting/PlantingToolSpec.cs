using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

public record PlantingToolSpec : ComponentSpec
{
    [Serialize]
    public string PrefabName { get; init; }
}