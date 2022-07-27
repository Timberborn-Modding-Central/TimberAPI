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
    public class BuildingRecipeService : ILoadableSingleton
    {
        private readonly BuildingRecipeSpecificationDeserializer _buildingRecipeSpecificationObjectDeserializer;

        //private readonly FactionSpecificationService _factionSpecificationService;

        private readonly ISpecificationService _specificationService;

        private ImmutableArray<BuildingRecipeSpecification> _buildingSpecifications;

        //public GolemFactionService(FactionService factionService, ISpecificationService specificationService, FactionSpecificationService factionSpecificationService, GolemFactionSpecificationObjectDeserializer golemFactionSpecificationObjectDeserializer)
        public BuildingRecipeService(
            ISpecificationService specificationService,
            BuildingRecipeSpecificationDeserializer buildingRecipeSpecificationObjectDeserializer)
        {
            _specificationService = specificationService;
            _buildingRecipeSpecificationObjectDeserializer = buildingRecipeSpecificationObjectDeserializer;
            //_factionSpecificationService = factionSpecificationService;
            //_golemFactionSpecificationObjectDeserializer = golemFactionSpecificationObjectDeserializer;
        }

        public void Load()
        {
            Console.WriteLine($"service Load");
            _buildingSpecifications = _specificationService.GetSpecifications(_buildingRecipeSpecificationObjectDeserializer).ToImmutableArray();
            Console.WriteLine($"specs: {_buildingSpecifications.Count()}");
        }

        public IEnumerable<Recipe> GetRecipesByManufactory(Manufactory manufactory)
        {
            var prefab = manufactory.GetComponent<Prefab>();
            var prefabName = prefab.PrefabName;
            Console.WriteLine($"prefab name: {prefabName}");
            if(_buildingSpecifications == null)
            {
                Console.WriteLine($"_buildingSpecs null");
                return null;
            }
            var buildingSpec = _buildingSpecifications.Where(x => x?.BuildingId == prefabName)
                                                      .FirstOrDefault();

            if(buildingSpec == null)
            {
                Console.WriteLine($"building spec null");
                return null;
            }
            Console.WriteLine($"Has recipes. count: {buildingSpec.Recipes.Count}");
            return buildingSpec.Recipes;

            //var golemFactionSpecification = _buildingSpecifications.FirstOrDefault(specification => specification.Id.Equals(recipeId));
            //if (golemFactionSpecification is not null)
            //    return golemFactionSpecification.GolemId;

            //TimberAPIPlugin.Log.LogWarning("Golems for faction " + recipeId + " doesn't exists, falling back to " + _factionSpecificationService.StartingFaction.Id);
            //return _factionSpecificationService.StartingFaction.Id;
        }
    }
}
