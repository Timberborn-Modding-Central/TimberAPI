using System;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingCostDeserializer : IObjectSerializer<BuildingCost>
    {
        private readonly PropertyKey<string> _goodIdKey = new PropertyKey<string>("GoodId");
        private readonly PropertyKey<int> _amountKey = new PropertyKey<int>("Amount");

        /// <summary>
        /// This class only deserializes specification jsons, so this is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="objectSaver"></param>
        /// <exception cref="NotSupportedException"></exception>
        public void Serialize(BuildingCost value, IObjectSaver objectSaver)
        {
            throw new NotSupportedException();
        }

        public Obsoletable<BuildingCost> Deserialize(IObjectLoader objectLoader)
        {
            return new BuildingCost(objectLoader.Get(_goodIdKey),
                                    objectLoader.Get(_amountKey));
        }
    }
}
