using System;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Buildings
{
    public class MechanicalNodeDeserializer : IObjectSerializer<MechanicalNode>
    {
        private readonly PropertyKey<int> _powerInputtKey = new PropertyKey<int>("PowerInput");
        private readonly PropertyKey<int> _powerOutputKey = new PropertyKey<int>("PowerOutput");


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
            var powerInput = objectLoader.Has(_powerInputtKey)
                ? objectLoader.Get(_powerInputtKey)
                : 0;
            var powerOutput = objectLoader.Has(_powerOutputKey)
                ? objectLoader.Get(_powerOutputKey)
                : 0;
            return new MechanicalNode(powerInput,
                                      powerOutput);
        }
    }
}
