using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Timberborn.EntitySystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;

namespace TimberbornAPI.SpecificationSystem.Buildings
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

        public void Load()
        {
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectDeserializer).ToImmutableArray();
        }

        public IEnumerable<Recipe> GetRecipesByManufactory(Manufactory manufactory)
        {
            var prefab = manufactory.GetComponent<Prefab>();
            var prefabName = prefab.PrefabName;
            if(_buildingSpecifications == null)
            {
                return null;
            }
            var buildingSpec = _buildingSpecifications.Where(x => x?.BuildingId == prefabName)
                                                      .FirstOrDefault();

            if(buildingSpec == null)
            {;
                return null;
            }
            if(buildingSpec.Recipes == null)
            {
                return null;
            }
            return buildingSpec.Recipes;
        }

        public Building GetBuildingByBuilding(Timberborn.Buildings.Building building)
        {
            var prefab = building.GetComponent<Prefab>();
            var prefabName = prefab.PrefabName;
            if (_buildingSpecifications == null)
            {
                return null;
            }
            var buildingSpec = _buildingSpecifications.Where(x => x?.BuildingId == prefabName)
                                                      .FirstOrDefault();

            if (buildingSpec == null)
            {
                return null;
            }
            if (buildingSpec.Building == null)
            {
                return null;
            }
            return buildingSpec.Building;
        }
    }
}
