﻿using System.Collections.Immutable;
using System.Linq;
using Timberborn.EntitySystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    /// <summary>
    /// This service fetches BuildingSpecifications
    /// </summary>
    public class BuildingSpecificationService : ILoadableSingleton
    {
        private readonly BuildingSpecificationDeserializer _buildingRecipeSpecificationObjectDeserializer;
        private readonly ISpecificationService _specificationService;
        private ImmutableArray<BuildingSpecification> _buildingSpecifications;

        public BuildingSpecificationService(
            ISpecificationService specificationService,
            BuildingSpecificationDeserializer buildingRecipeSpecificationObjectDeserializer)
        {
            _specificationService = specificationService;
            _buildingRecipeSpecificationObjectDeserializer = buildingRecipeSpecificationObjectDeserializer;
        }

        /// <summary>
        /// Fetches all BuildingSpecifications on load and stores them
        /// </summary>
        public void Load()
        {
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectDeserializer).ToImmutableArray();
        }

        public BuildingSpecification? GetBuildingSpecificationByBuilding(Timberborn.Buildings.Building building)
        {
            var prefab = building.GetComponent<Prefab>();
            string prefabName = prefab.PrefabName.ToLower();
            return _buildingSpecifications.FirstOrDefault(x => x?.BuildingId.ToLower() == prefabName);
        }
    }
}
