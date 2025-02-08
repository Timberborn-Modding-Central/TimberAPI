using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolSystem.Tools.GenericTool;

public record GenericToolSpec : ComponentSpec
{
    [Serialize]
    public string ClassName { get; init; }
}