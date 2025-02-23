using System.Collections.Immutable;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;
using Timberborn.LocalizationSerialization;

namespace TimberApi.Tools.ToolSystem;

public record ToolSpec : OptionalComponentSpec
{
    [Serialize]
    public string Id { get; init; }

    [Serialize(true)]
    public string? GroupId { get; init; } = null;

    [Serialize(true)]
    public ImmutableArray<string>? Scenes { get; init; } = ["Game"];

    [Serialize(true)]
    public string? Section { get; init; } = "BottomBar";

    [Serialize]
    public string Type { get; init; }

    [Serialize(true)]
    public string? Layout { get; init; } = "Default";

    [Serialize]
    public int Order { get; init; }

    [Serialize]
    public string Icon { get; init; }

    [Serialize(false, "NameLocKey")]
    public LocalizedText Name { get; init; }
    
    [Serialize]
    public string NameLocKey { get; init; }

    [Serialize(false, "DescriptionLocKey")]
    public LocalizedText Description { get; init; }
    
    [Serialize]
    public string DescriptionLocKey { get; init; }

    [Serialize(true)]
    public bool Hidden { get; init; } = false;

    [Serialize(true)]
    public bool DevMode { get; init; } = false;
}