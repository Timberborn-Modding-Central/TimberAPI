using System.Collections.Immutable;
using System.Linq;
using Timberborn.Buildings;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;

namespace BuildingSpecificationSystem;

/// <summary>
///     This service fetches BuildingSpecifications
/// </summary>
internal class BuildingSpecificationService(
    ISpecificationService specificationService,
    BuildingSpecificationObjectDeserializer buildingRecipeSpecificationObjectObjectDeserializer)
    : ILoadableSingleton
{
    private ImmutableArray<BuildingSpecification> _buildingSpecifications;

    /// <summary>
    ///     Fetches all BuildingSpecifications on load and stores them
    /// </summary>
    public void Load()
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