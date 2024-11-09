using System.Collections.Immutable;
using System.Linq;
using TimberApi.SingletonSystem;
using Timberborn.Buildings;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;

namespace TimberApi.BuildingSpecificationSystem;

/// <summary>
///     This service fetches BuildingSpecifications
/// </summary>
internal class BuildingSpecificationService(
    ISpecificationService specificationService,
    BuildingSpecificationObjectDeserializer buildingRecipeSpecificationObjectObjectDeserializer)
    : IEarlyLoadableSingleton
{
    private ImmutableArray<BuildingSpecification> _buildingSpecifications;

    /// <summary>
    ///     Fetches all BuildingSpecifications on load and stores them
    /// </summary>
    public void EarlyLoad()
    {
        _buildingSpecifications = specificationService.GetSpecifications(buildingRecipeSpecificationObjectObjectDeserializer).ToImmutableArray();
    }

    public BuildingSpecification? GetBuildingSpecificationByBuilding(Building building)
    {
        var prefab = building.GetComponentFast<Prefab>();
        var prefabName = prefab.PrefabName.ToLower();

        return _buildingSpecifications.FirstOrDefault(x => x?.BuildingId.ToLower() == prefabName);
    }
}