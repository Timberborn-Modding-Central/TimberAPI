using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingSpecificationDeserializer : IObjectSerializer<BuildingSpecification>
    {
        private PropertyKey<string> _buildingIdKey = new PropertyKey<string>("BuildingId");
        private PropertyKey<Building> _buildingKey = new PropertyKey<Building>("Building");
        private ListKey<Recipe> _recipesKey = new ListKey<Recipe>("Recipes");
        private PropertyKey<MechanicalNode> _mechanicalNodeKey = new PropertyKey<MechanicalNode>("MechanicalNode");

        private readonly RecipeDeserializer _recipeDeserializer;
        private readonly BuildingDeserializer _buildingDeserializer;
        private readonly MechanicalNodeDeserializer _mechanicalNodeDeserializer;

        public BuildingSpecificationDeserializer(
            RecipeDeserializer recipeDeserializer,
            BuildingDeserializer buildingDeserializer,
            MechanicalNodeDeserializer mechanicalNodeDeserializer)
        {
            _recipeDeserializer = recipeDeserializer;
            _buildingDeserializer = buildingDeserializer;
            _mechanicalNodeDeserializer = mechanicalNodeDeserializer;
        }

        public void Serialize(BuildingSpecification value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<BuildingSpecification> Deserialize(IObjectLoader objectLoader)
        {
            var recipes = objectLoader.Has(_recipesKey)
                ? objectLoader.Get(_recipesKey, _recipeDeserializer)
                : null;
            var buildings = objectLoader.Has(_buildingKey)
                ? objectLoader.Get(_buildingKey, _buildingDeserializer)
                : null;
            var mechanicalNode = objectLoader.Has(_mechanicalNodeKey)
                ? objectLoader.Get(_mechanicalNodeKey, _mechanicalNodeDeserializer)
                : null;
            return new BuildingSpecification(objectLoader.Get(_buildingIdKey),
                                             recipes,
                                             buildings,
                                             mechanicalNode);
        }
    }
}

