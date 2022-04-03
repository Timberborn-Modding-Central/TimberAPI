using Bindito.Unity;
using Timberborn.Warehouses;
using Timberborn.WaterBuildings;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    public class EntityActions : IEntityAction
    {
        private readonly IInstantiator _instantiator;

        public EntityActions(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        /// <summary>
        /// Add our custom behaviours to desired game objects
        /// </summary>
        /// <param name="entity"></param>
        public void ApplyToEntity(GameObject entity)
        {
            //Mechanical water pumps have a WaterMover component
            var watermover = entity.GetComponent<WaterMover>();
            //Really make sure custom class is only added to Mechanical water pumps
            if (watermover != null && watermover.name.Contains("Mechanical"))
            {
                _instantiator.AddComponent<MechanicalWaterPumpBehaviour>(entity);
            }

            //Add custom class to Warehouses
            var stockpile = entity.GetComponent<Stockpile>();
            if (stockpile != null && stockpile.name.Contains("Ware"))
            {
                _instantiator.AddComponent<WarehouseBehaviour>(entity);
            }
        }
    }
}
