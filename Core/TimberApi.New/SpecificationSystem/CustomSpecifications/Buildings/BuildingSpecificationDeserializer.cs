using System;
using System.Collections.Generic;
using TimberApi.Common.Extensions;
using Timberborn.Persistence;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    public class BuildingSpecificationDeserializer : IObjectSerializer<BuildingSpecification>
    {
        private readonly BuildingCostDeserializer _buildingCostDeserializer;

        private readonly ListKey<BuildingCost> _buildingCosts = new("BuildingCosts");
        private readonly PropertyKey<string> _buildingIdKey = new("BuildingId");

        private readonly PropertyKey<int> _powerInputKey = new("PowerInput");

        private readonly PropertyKey<int> _powerOutputKey = new("PowerOutput");

        private readonly ListKey<string> _recipeIdsKey = new("RecipeIds");

        private readonly PropertyKey<int> _scienceCostKey = new("ScienceCost");

        public BuildingSpecificationDeserializer(BuildingCostDeserializer buildingCostDeserializer)
        {
            _buildingCostDeserializer = buildingCostDeserializer;
        }

        /// <summary>
        ///     This class only deserializes specification jsons, so this is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectSaver"></param>
        public void Serialize(BuildingSpecification value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<BuildingSpecification> Deserialize(IObjectLoader objectLoader)
        {
            string buildingId = objectLoader.Get(_buildingIdKey);
            int? scienceCost = objectLoader.GetValueOrNullable(_scienceCostKey);
            int? powerInput = objectLoader.GetValueOrNullable(_powerInputKey);
            int? powerOutput = objectLoader.GetValueOrNullable(_powerOutputKey);
            List<string> recipeIds = objectLoader.GetValueOrEmpty(_recipeIdsKey);
            List<BuildingCost> buildingCosts = objectLoader.GetValueOrEmpty(_buildingCosts, _buildingCostDeserializer);

            return new BuildingSpecification(buildingId, scienceCost, powerInput, powerOutput, recipeIds, buildingCosts);
        }
    }
}