using Timberborn.BlueprintSystem;
using Timberborn.PrioritySystem;

namespace TimberApi.Tools.ToolSystem.Tools.BuilderPriority;

public record BuilderPriorityToolSpec : ComponentSpec
{
    [Serialize]
    public Priority Priority { get; init; }
}