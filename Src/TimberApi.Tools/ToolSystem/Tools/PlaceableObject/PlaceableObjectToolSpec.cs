using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public record PlaceableObjectToolSpec : ComponentSpec
{
    [Serialize]
    public string PrefabName { get; init; }
}