using System;
using TimberApi.Extensions;
using Timberborn.Persistence;

namespace TimberApi.BuildingSpecificationSystem;

internal class BuildingSpecificationObjectDeserializer(BuildingCostObjectDeserializer buildingCostObjectDeserializer)
    : IObjectSerializer<BuildingSpecification>
{
    private readonly ListKey<BuildingCost> _buildingCosts = new("BuildingCosts");
    private readonly PropertyKey<string> _buildingIdKey = new("BuildingId");

    private readonly PropertyKey<int> _powerInputKey = new("PowerInput");

    private readonly PropertyKey<int> _powerOutputKey = new("PowerOutput");

    private readonly ListKey<string> _recipeIdsKey = new("RecipeIds");

    private readonly PropertyKey<int> _scienceCostKey = new("ScienceCost");

    /// <summary>
    ///     This class only deserializes specification jsons, so this is not used
    /// </summary>
    /// <param name="value"></param>
    /// <param name="objectSaver"></param>
    public void Serialize(BuildingSpecification value, IObjectSaver objectSaver)
    {
        throw new NotSupportedException();
    }

    public Obsoletable<BuildingSpecification> Deserialize(IObjectLoader objectLoader)
    {
        var buildingId = objectLoader.Get(_buildingIdKey);
        var scienceCost = objectLoader.GetValueOrNullable(_scienceCostKey);
        var powerInput = objectLoader.GetValueOrNullable(_powerInputKey);
        var powerOutput = objectLoader.GetValueOrNullable(_powerOutputKey);
        var recipeIds = objectLoader.GetValueOrEmpty(_recipeIdsKey);
        var buildingCosts = objectLoader.GetValueOrEmpty(_buildingCosts, buildingCostObjectDeserializer);

        return new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);
    }
}