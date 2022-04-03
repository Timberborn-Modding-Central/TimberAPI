using Timberborn.Persistence;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.MechWaterPumpWarehouseExample
{
    public class MechanicalWaterPumpWarehouseLinkSerializer : BaseEntityLinkSerializer<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour>
    {
        //Key that is used to save/load custom properties
        private static readonly PropertyKey<int> BerryTresholdKey = new PropertyKey<int>(nameof(MechanicalWaterPumpWarehouseLink.BerryTreshold));

        public override void Serialize(MechanicalWaterPumpWarehouseLink value, IObjectSaver objectSaver)
        {
            //The base method takes care of saving the linker and linkee values
            base.Serialize(value, objectSaver);

            //Here we need to save our custom Link classes custom properties
            //var link = value as MechanicalWaterPumpWarehouseLink;
            objectSaver.Set(BerryTresholdKey, value.BerryTreshold);
        }

        public override Obsoletable<MechanicalWaterPumpWarehouseLink> Deserialize(IObjectLoader objectLoader)
        {
            var link = base.Deserialize(objectLoader);

            link.Value.BerryTreshold = objectLoader.Get(BerryTresholdKey);
            return link;
        }
    }
}
