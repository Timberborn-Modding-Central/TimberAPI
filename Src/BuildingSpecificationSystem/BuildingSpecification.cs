using System.Collections.Generic;
using System.Collections.Immutable;

namespace BuildingSpecificationSystem;

/// <summary>
///     Represents the various settings that can be changed
///     on Buildings using TimberAPI
/// </summary>
internal class BuildingSpecification(
    string buildingId,
    int? scienceCost,
    int? powerInput,
    int? powerOutput,
    IEnumerable<string> recipeIds,
    IEnumerable<BuildingCost> buildingCosts)
{
    public string BuildingId = buildingId;

    public int? PowerInput = powerInput;

    public int? PowerOutput = powerOutput;

    public ImmutableArray<string> RecipeIds = recipeIds.ToImmutableArray();

    public int? ScienceCost { get; set; } = scienceCost;

    public ImmutableArray<BuildingCost> BuildingCosts { get; set; } = buildingCosts.ToImmutableArray();
}