using System.Linq;
using TimberApi.EntityLinkerSystem;
using Timberborn.Buildings;
using Timberborn.Stockpiles;
using Timberborn.TickSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    /// <summary>
    /// Custom class that inherits from TickacleComponent so we can
    /// pause the building linked to a warehouse when we want.
    /// There are many ways o hook into the Link, this is just one example
    /// </summary>
    public class WarehouseLinkService : TickableComponent
    {
        private Stockpile _stockpile;
        private EntityLinker _linker;

        /// <summary>
        /// Get the Stockpile to keep track of wanted items
        /// and EntityLinker to do stuff with the Link
        /// </summary>
        public void Awake()
        {
            _stockpile = GetComponent<Stockpile>();
            _linker = GetComponent<EntityLinker>();
        }

        /// <summary>
        /// When a Warehouse is linked to another building and
        /// has over 150 Berries, Pause the linked building.
        /// </summary>
        public override void Tick()
        {
            if(_linker == null && _linker.EntityLinks.Count == 0)
            {
                return;
            }

            foreach (var link in _linker.EntityLinks)
            {
                var buildingToPause = link.Linker == _linker
                    ? link.Linkee.GetComponent<PausableBuilding>()
                    : link.Linker.GetComponent<PausableBuilding>();
                if (_stockpile.Inventory
                         .Stock
                         .Where(x => x.GoodId.Contains("Berr"))
                         .FirstOrDefault()
                         .Amount > 150)
                {
                    if (buildingToPause.Paused == false)
                    {
                        buildingToPause.Pause();
                    }
                }
                else
                {
                    if (buildingToPause.Paused == true)
                    {
                        buildingToPause.Resume();
                    }
                }
            }
        }

    }
}
