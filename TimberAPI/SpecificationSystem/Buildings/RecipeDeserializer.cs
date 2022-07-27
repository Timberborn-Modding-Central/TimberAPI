using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class RecipeDeserializer : IObjectSerializer<Recipe>
    {
        private readonly PropertyKey<string> _recipeId = new PropertyKey<string>("RecipeId");

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
