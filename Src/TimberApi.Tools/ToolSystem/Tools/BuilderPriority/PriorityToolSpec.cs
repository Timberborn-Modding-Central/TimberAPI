using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public record PriorityToolSpec : ComponentSpec
{
    [Serialize]
    public string Priority { get; init; }
}