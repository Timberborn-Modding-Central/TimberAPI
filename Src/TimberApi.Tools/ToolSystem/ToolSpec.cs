using System.Collections.Generic;
using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolSystem;

public record ToolSpec : ComponentSpec
{
    [Serialize]
    public string Id { get; init; }

    [Serialize]
    public string? GroupId { get; init; }
    
    [Serialize]
    public HashSet<string> Scenes { get; init; }

    [Serialize]
    public string Section { get; init; }

    [Serialize]
    public string Type { get; init; }

    [Serialize]
    public string Layout { get; init; }

    [Serialize]
    public int Order { get; init; }

    [Serialize]
    public string Icon { get; init; }

    [Serialize("NameLocKey")]
    public string Name { get; init; }

    [Serialize("DescriptionLocKey")]
    public string Description { get; init; }

    [Serialize]
    public bool Hidden { get; init; }

    [Serialize]
    public bool DevMode { get; init; }
}