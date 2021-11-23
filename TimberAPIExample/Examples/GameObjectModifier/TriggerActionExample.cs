using Timberborn.ConstructibleSystem;
using TimberbornAPI.GameObjectModifier;
using UnityEngine;

namespace TimberAPIExample.Examples.GameObjectModifier
{
    public class TriggerActionExample : IEntityInstantiator
    {
        public void Instantiate(GameObject gameObject)
        {
            // Receives the constructable component
            Constructible constructible = gameObject.GetComponent<Constructible>();
            
            // Is this a constructable entity or is finished
            if (constructible == null || constructible.IsFinished)
                return;
            
            // Completes building skipping the needs or resources or building (only works when placing, already placed entities will be skipped)
            constructible.Finish();
        }
    }
}