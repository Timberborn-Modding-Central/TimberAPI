using Timberborn.BlueprintSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public record TimberApiToolGroupSpec : ToolGroupSpec
{
    [Serialize]
    public string Type { get; init; } = "ConstructionModeToolGroup";

    [Serialize]
    public string? GroupId { get; init; } = null;

    [Serialize]
    public string Layout { get; init; } = "Green";

    [Serialize]
    public string Section { get; init; } = "BottomBar";

    [Serialize]
    public bool DevMode { get; init; } = false;

    [Serialize]
    public bool Hidden { get; init; } = false;
}