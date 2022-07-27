using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingRecipeSpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<BuildingRecipeService>().AsSingleton();
            containerDefinition.Bind<BuildingRecipeSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<RecipeDeserializer>().AsSingleton();
        }
    }
}
