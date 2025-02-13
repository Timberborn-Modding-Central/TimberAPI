using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public record ToolGroupExtensionSpec : ComponentSpec
{
    [Serialize]
    public string Type { get; init; }

    [Serialize]
    public string? GroupId { get; init; }

    [Serialize]
    public string Layout { get; init; }

    [Serialize]
    public string Section { get; init; }

    [Serialize]
    public bool DevMode { get; init; }

    [Serialize]
    public bool Hidden { get; init; }
}
