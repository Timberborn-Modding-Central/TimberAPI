using System;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class BuildingCostDeserializer : IObjectSerializer<BuildingCost>
    {
        private readonly PropertyKey<string> _goodIdKey = new PropertyKey<string>("GoodId");
        private readonly PropertyKey<int> _amountKey = new PropertyKey<int>("Amount");

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
