﻿using Timberborn.Buildings;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.MechWaterPumpWarehouseExample
{
    /// <summary>
    /// Custom class that represent the linker in a entitylink
    /// </summary>
    public class MechanicalWaterPumpBehaviour : BaseEntityLinker<MechanicalWaterPumpWarehouseLink, WarehouseBehaviour, MechanicalWaterPumpBehaviour>
    {
        //The following methods can be anything. In this example we want to 
        // pause/unpause the waterpump based on the berries in a warehouse.
        // They are called in the WarehouseBehaviour.Tick()
        public void PauseWaterPump()
        {
            var pausableComponent = GetComponent<PausableBuilding>();
            if(!pausableComponent.Paused)
            {
                pausableComponent.Pause();
            }
        }

        public void ResumeWaterPump()
        {
            var pausableComponent = GetComponent<PausableBuilding>();
            if(pausableComponent.Paused)
            {
                pausableComponent.Resume();
            }
        }
    }
}