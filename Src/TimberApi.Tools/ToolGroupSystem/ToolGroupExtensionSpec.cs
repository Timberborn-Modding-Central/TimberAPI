using Timberborn.BlueprintSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public record TimberApiToolGroupSpec : ToolGroupSpec
{
    public TimberApiToolGroupSpec()
    {
        Section = "Testing";
    }
    
    [Serialize(true)]
    public string? Type { get; init; } = "ConstructionModeToolGroup";

    [Serialize(true)]
    public string? GroupId { get; init; } = null;

    [Serialize(true)]
    public string? Layout { get; init; } = "Green";

    [Serialize(true)]
    public string? Section { get; init; } = "BottomBar";

    [Serialize(true)]
    public bool DevMode { get; init; } = false;

    [Serialize(true)]
    public bool Hidden { get; init; } = false;
}