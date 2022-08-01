using System;
using System.Collections.Generic;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingDeserializer : IObjectSerializer<Building>
    {
        private readonly PropertyKey<int> _scienceCostKey = new PropertyKey<int>("ScienceCost");
        private readonly ListKey<BuildingCost> _buildingCostKey = new ListKey<BuildingCost>("BuildingCost");

        private readonly BuildingCostDeserializer _buildingCostDeserializer;

        public BuildingDeserializer(BuildingCostDeserializer buildingCostDeserializer)
        {
            _buildingCostDeserializer = buildingCostDeserializer;
        }

        /// <summary>
        /// This class only deserializes specification jsons, so this is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectSaver"></param>
        public void Serialize(Building value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<Building> Deserialize(IObjectLoader objectLoader)
        {
            var scienceCost = objectLoader.Has(_scienceCostKey)
                ? objectLoader.Get(_scienceCostKey)
                : 0;
            var buildingCost = objectLoader.Has(_buildingCostKey)
                ? objectLoader.Get(_buildingCostKey, _buildingCostDeserializer)
                : new List<BuildingCost>();
            return new Building(scienceCost,
                                buildingCost);
        }
    }
}
