using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingRecipeSpecificationDeserializer : IObjectSerializer<BuildingRecipeSpecification>
    {
        private PropertyKey<string> _buildingKey = new PropertyKey<string>("BuildingId");
        private ListKey<Recipe> RecipesKey = new ListKey<Recipe>("Recipes");

        private readonly RecipeDeserializer _recipeDeserializer;

        public BuildingRecipeSpecificationDeserializer(RecipeDeserializer recipeDeserializer)
        {
            _recipeDeserializer = recipeDeserializer;
        }

        public void Serialize(BuildingRecipeSpecification value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<BuildingRecipeSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return new BuildingRecipeSpecification(objectLoader.Get(_buildingKey),
                                                   objectLoader.Get(RecipesKey, _recipeDeserializer));
        }
    }
}

