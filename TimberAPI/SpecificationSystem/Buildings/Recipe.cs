namespace TimberbornAPI.SpecificationSystem.Buildings
{
    /// <summary>
    /// Stripped version of Timberborn.Goods.RecipeSpecification
    /// Only contains relevant fields
    /// </summary>
    public class Recipe
    {
        public string RecipeId;

        public Recipe(string recipeId)
        {
            RecipeId = recipeId;
        }
    }
}
