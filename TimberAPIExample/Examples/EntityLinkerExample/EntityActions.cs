using Bindito.Unity;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void ApplyToEntity(GameObject entity)
        {
            var watermover = entity.GetComponent<WaterMover>();
            if (watermover != null && watermover.name.Contains("Mechanical"))
            {
                _instantiator.AddComponent<MechanicalWaterPumpBehaviour>(entity);
            }

            var stockpile = entity.GetComponent<Stockpile>();
            if (stockpile != null && stockpile.name.Contains("Ware"))
            {
                _instantiator.AddComponent<WarehouseBehaviour>(entity);
            }
        }
    }
}
