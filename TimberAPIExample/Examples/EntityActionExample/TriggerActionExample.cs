using Timberborn.ConstructibleSystem;
using TimberbornAPI.EntityInstantiatorSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class TriggerActionExample : IEntityAction
    {
        public void ApplyToEntity(GameObject entity)
        {
            // Receives the constructable component
            Constructible constructible = entity.GetComponent<Constructible>();
            
            // Is this a constructable entity or is finished
            if (constructible == null || constructible.IsFinished)
                return;
            
            // Completes building skipping the needs or resources or building (only works when placing, already placed entities will be skipped)
            constructible.Finish();
        }
    }
}