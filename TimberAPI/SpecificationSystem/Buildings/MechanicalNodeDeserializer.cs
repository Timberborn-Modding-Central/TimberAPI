using System;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class MechanicalNodeDeserializer : IObjectSerializer<MechanicalNode>
    {
        private readonly PropertyKey<int> _powerInputtKey = new PropertyKey<int>("PowerInput");
        private readonly PropertyKey<int> _powerOutputKey = new PropertyKey<int>("PowerOutput");

        private readonly BuildingCostDeserializer _buildingCostDeserializer;

        public MechanicalNodeDeserializer(BuildingCostDeserializer buildingCostDeserializer)
        {
            _buildingCostDeserializer = buildingCostDeserializer;
        }

        /// <summary>
        /// This class only deserializes specification jsons, so this is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectSaver"></param>
        public void Serialize(MechanicalNode value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<MechanicalNode> Deserialize(IObjectLoader objectLoader)
        {
            return new MechanicalNode(objectLoader.Get(_powerInputtKey),
                                      objectLoader.Get(_powerOutputKey));
        }
    }
}
