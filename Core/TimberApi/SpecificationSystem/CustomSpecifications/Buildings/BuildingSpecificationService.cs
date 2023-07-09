using System.Collections.Immutable;
using System.Linq;
using TimberApi.Common.SingletonSystem;
using Timberborn.Buildings;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    /// <summary>
    ///     This service fetches BuildingSpecifications
    /// </summary>
    public class BuildingSpecificationService : IObjectSpecificationLoadableSingleton
    {
        private readonly BuildingSpecificationObjectDeserializer _buildingRecipeSpecificationObjectObjectDeserializer;
        private readonly ISpecificationService _specificationService;
        private ImmutableArray<BuildingSpecification> _buildingSpecifications;

        public BuildingSpecificationService(
            ISpecificationService specificationService,
            BuildingSpecificationObjectDeserializer buildingRecipeSpecificationObjectObjectDeserializer)
        {
            _specificationService = specificationService;
            _buildingRecipeSpecificationObjectObjectDeserializer = buildingRecipeSpecificationObjectObjectDeserializer;
        }

        /// <summary>
        ///     Fetches all BuildingSpecifications on load and stores them
        /// </summary>
        public void SpecificationLoad()
        {
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectObjectDeserializer).ToImmutableArray();
        }

        public BuildingSpecification? GetBuildingSpecificationByBuilding(Building building)
        {
            var prefab = building.GetComponentFast<Prefab>();
            string prefabName = prefab.PrefabName.ToLower();
            return _buildingSpecifications.FirstOrDefault(x => x?.BuildingId.ToLower() == prefabName);
        }
    }
}