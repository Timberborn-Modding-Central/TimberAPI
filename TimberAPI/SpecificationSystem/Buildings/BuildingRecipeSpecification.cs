using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingRecipeSpecification
    {
        public BuildingRecipeSpecification(
            string buildingId,
            List<Recipe> recipes)
        {
            BuildingId = buildingId;
            Recipes = recipes;
        }

        public string BuildingId;

        public List<Recipe> Recipes;
    }

    public class Recipe
    {
        public string Id;

        public Recipe(string id)
        {
            Id = id;
        }
    }
}
