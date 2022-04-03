using System.Linq;
using Timberborn.Warehouses;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.MechWaterPumpWarehouseExample
{
    public class WarehouseBehaviour : BaseEntityLinkee<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour>
    {
        private Stockpile _warehouse;

        public override void OnEnterFinishedState()
        {
            base.OnEnterFinishedState();
            // Get the actual game component so we can do comparisons
            // in the Tick() method
            _warehouse = GetComponent<Stockpile>();
        }

        public override void OnExitFinishedState()
        {
            base.OnExitFinishedState();
            _warehouse = null;
        }

        public override void Tick()
        {
            //Get the variable to which we want to do comparisons
            var berryCount = _warehouse.Inventory
                                       .Stock
                                       .Where(x => x.GoodSpecification.Id.Contains("Berries"))
                                       .Select(x => x.Amount)
                                       .SingleOrDefault();

            //Loop thru all the links this warehouse has
            foreach (var link in EntityLinks)
            {
                // If we have equally or more berries. pause the water pump
                if (berryCount >= link.BerryTreshold)
                {
                    var waterPump = link.Linker;
                    waterPump.PauseWaterPump();
                    continue;
                }
                // If we dont have anough berries, unpause the water pump
                if(berryCount < link.BerryTreshold)
                {
                    var waterPump = link.Linker;
                    waterPump.ResumeWaterPump();
                    continue;
                }
            }
        }
    }
}
