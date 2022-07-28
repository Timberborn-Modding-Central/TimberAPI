using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.EntitySystem;
using Timberborn.MechanicalSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;
using Timberborn.Workshops;
using UnityEngine;

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

        /// <summary>
        /// Fetches all BuildingSpecifications on load and stores them
        /// </summary>
        public void Load()
        {
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectDeserializer)
                                                           .ToImmutableArray();
        }

        /// <summary>
        /// Fetches all Recipes from loaded BuildingSpecifications that
        /// have the same prefab name as given <paramref name="manufactory"/>
        /// </summary>
        /// <param name="manufactory"></param>
        /// <returns></returns>
        public IEnumerable<Recipe> GetRecipesByManufactory(Manufactory manufactory)
        {
            var buildingSpec = GetBuildingSpecifications(manufactory).FirstOrDefault();
            if (buildingSpec == null || buildingSpec.Recipes == null)
            {
                return null;
            }
            return buildingSpec.Recipes;
        }

        /// <summary>
        /// Fetches all Recipes from loaded BuildingSpecifications that
        /// have the same prefab name as given <paramref name="building"/>
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        public Building GetBuildingByBuilding(Timberborn.Buildings.Building building)
        {
            var buildingSpec = GetBuildingSpecifications(building).FirstOrDefault();
            if (buildingSpec == null || buildingSpec.Building == null)
            {
                return null;
            }
            return buildingSpec.Building;
        }

        /// <summary>
        /// Fetches all Recipes from loaded BuildingSpecifications that
        /// have the same prefab name as given <paramref name="mechanicalNodeSpecification"/>
        /// </summary>
        /// <param name="mechanicalNodeSpecification"></param>
        /// <returns></returns>
        public MechanicalNode GetMechanicalNodeByMechanicalNodeSpecification(
            MechanicalNodeSpecification mechanicalNodeSpecification)
        {
            var buildingSpec = GetBuildingSpecifications(mechanicalNodeSpecification).FirstOrDefault();
            if (buildingSpec == null || buildingSpec.MechanicalNode == null)
            {
                return null;
            }

            return buildingSpec.MechanicalNode;
        }

        /// <summary>
        /// Helper function that gets all specification that have the same
        /// prefab name as given <paramref name="gameObject"/>
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private IEnumerable<BuildingSpecification> GetBuildingSpecifications(MonoBehaviour gameObject)
        {
            var prefab = gameObject.GetComponent<Prefab>();
            var prefabName = prefab.PrefabName;
            if (_buildingSpecifications == null)
            {
                return new ImmutableArray<BuildingSpecification>();
            }
            return _buildingSpecifications.Where(x => x?.BuildingId == prefabName);
        }
    }
}
