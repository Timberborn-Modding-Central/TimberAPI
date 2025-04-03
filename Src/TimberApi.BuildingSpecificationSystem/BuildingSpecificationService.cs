using System.Collections.Immutable;
using System.Linq;
using TimberApi.SingletonSystem;
using Timberborn.BlueprintSystem;
using Timberborn.Buildings;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;

namespace TimberApi.BuildingSpecificationSystem;

/// <summary>
///     This service fetches BuildingSpecifications
/// </summary>
internal class BuildingSpecificationService(
    ISpecService specificationService)
    : IEarlyLoadableSingleton
{
    private ImmutableArray<BuildingSpec> _buildingSpecifications;

    /// <summary>
    ///     Fetches all BuildingSpecifications on load and stores them
    /// </summary>
    public void EarlyLoad()
    {
        _buildingSpecifications = specificationService.GetSpecs<BuildingSpec>().ToImmutableArray();
    }

    public BuildingSpec? GetBuildingSpecificationByBuilding(Timberborn.Buildings.BuildingSpec building)
    {
        var prefab = building.GetComponentFast<PrefabSpec>();
        var prefabName = prefab.PrefabName.ToLower();

        return _buildingSpecifications.FirstOrDefault(x => x?.BuildingId.ToLower() == prefabName);
    }
}