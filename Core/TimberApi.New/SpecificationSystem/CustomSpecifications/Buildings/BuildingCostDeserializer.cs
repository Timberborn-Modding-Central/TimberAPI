using System;
using Timberborn.Persistence;

namespace TimberApi.New.SpecificationSystem.CustomSpecifications.Buildings
{
    public class BuildingCostDeserializer : IObjectSerializer<BuildingCost>
    {
        private readonly PropertyKey<int> _amountKey = new("Amount");
        private readonly PropertyKey<string> _goodIdKey = new("GoodId");

        /// <summary>
        ///     This class only deserializes specification jsons, so this is not used
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
            return new BuildingCost(objectLoader.Get(_goodIdKey), objectLoader.Get(_amountKey));
        }
    }
}