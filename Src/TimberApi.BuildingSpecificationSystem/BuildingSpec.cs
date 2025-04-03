using System.Collections.Immutable;
using Timberborn.BlueprintSystem;

namespace TimberApi.BuildingSpecificationSystem;

/// <summary>
///     Represents the various settings that can be changed
///     on Buildings using TimberAPI
/// </summary>
internal record BuildingSpec() : ComponentSpec
{
    [Serialize]
    public string BuildingId { get; init; }

    [Serialize(true)]
    public int? PowerInput { get; init; }

    [Serialize(true)]
    public int? PowerOutput { get; init; }

    [Serialize(true)]
    public ImmutableArray<string> RecipeIds { get; init; }

    [Serialize(true)]
    public int? ScienceCost { get; init; }

    [Serialize(true)]
    public ImmutableArray<BuildingCost> BuildingCosts { get; init; }
}