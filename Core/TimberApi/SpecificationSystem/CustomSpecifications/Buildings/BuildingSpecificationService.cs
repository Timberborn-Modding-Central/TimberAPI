using System.Collections.Immutable;
using System.Linq;
using Timberborn.Buildings;
using Timberborn.Persistence;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.SpecificationSystem.CustomSpecifications.Buildings
{
    /// <summary>
    ///     This service fetches BuildingSpecifications
    /// </summary>
    internal class BuildingSpecificationService : ILoadableSingleton
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
        public void Load()
        {
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectObjectDeserializer).ToImmutableArray();
        }

        public BuildingSpecification? GetBuildingSpecificationByBuilding(Building building)
        {
            var prefab = building.GetComponent<Prefab>();
            string prefabName = prefab.PrefabName.ToLower();
            return _buildingSpecifications.FirstOrDefault(x => x?.BuildingId.ToLower() == prefabName);
        }
    }
}