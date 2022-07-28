using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingSpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<BuildingSpecificationService>().AsSingleton();
            containerDefinition.Bind<BuildingSpecificationDeserializer>().AsSingleton();
            containerDefinition.Bind<RecipeDeserializer>().AsSingleton();
            containerDefinition.Bind<BuildingDeserializer>().AsSingleton();
            containerDefinition.Bind<BuildingCostDeserializer>().AsSingleton();
            containerDefinition.Bind<MechanicalNodeDeserializer>().AsSingleton();
        }
    }
}
