using System;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class RecipeDeserializer : IObjectSerializer<Recipe>
    {
        private readonly PropertyKey<string> _recipeId = new PropertyKey<string>("RecipeId");

        /// <summary>
        /// This class only deserializes specification jsons, so this is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectSaver"></param>
        public void Serialize(Recipe value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<Recipe> Deserialize(IObjectLoader objectLoader)
        {
            return new Recipe(objectLoader.Get(_recipeId));
        }
    }
}
