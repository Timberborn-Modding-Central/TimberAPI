namespace TimberbornAPI.SpecificationSystem.Buildings
{
    /// <summary>
    /// Stripped version of Timberborn.Goods.RecipeSpecification
    /// Only contains relevant fields
    /// </summary>
    public class Recipe
    {
        public string Id;

        public Recipe(string id)
        {
            Id = id;
        }
    }
}
