using Timberborn.Buildings;
using Timberborn.ConstructibleSystem;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class TriggerActionExample : IEntityAction
    {
        public void ApplyToEntity(GameObject entity)
        {
            // Receives the constructable component
            Constructible constructable = entity.GetComponent<Constructible>();
            // Receives the building component
            Building building = entity.GetComponent<Building>();
            
            // Skip entity if components are missing or building is already finished on place
            if (constructable  == null || building == null || building.PlaceFinished)
                return;
            
            // Finishes the constructor
            
            constructable.Finish();
        }
    }
}