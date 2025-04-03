using System.Collections.Immutable;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;
using Timberborn.LocalizationSerialization;

namespace TimberApi.Tools.ToolSystem;

public record ToolSpec : OptionalComponentSpec
{
    [Serialize]
    public string Id { get; init; }

    [Serialize]
    public string? GroupId { get; init; } = null;

    [Serialize]
    public ImmutableArray<string> Scenes { get; init; } = ["Game"];

    [Serialize]
    public string Section { get; init; } = "BottomBar";

    [Serialize]
    public string Type { get; init; }

    [Serialize]
    public string Layout { get; init; } = "Default";

    [Serialize]
    public int Order { get; init; }

    [Serialize]
    public string Icon { get; init; }

    [Serialize("NameLocKey")]
    public LocalizedText Name { get; init; }

    [Serialize]
    public string NameLocKey { get; init; }

    [Serialize("DescriptionLocKey")]
    public LocalizedText Description { get; init; }

    [Serialize]
    public string DescriptionLocKey { get; init; }

    [Serialize]
    public bool Hidden { get; init; } = false;

    [Serialize]
    public bool DevMode { get; init; } = false;
}