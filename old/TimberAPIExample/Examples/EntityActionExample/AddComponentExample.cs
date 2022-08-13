using Bindito.Unity;
using Timberborn.GameDistricts;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class AddComponentActionExample : IEntityAction
    {
        private readonly IInstantiator _instantiator;

        public AddComponentActionExample(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        // We can give entities custom MonoBehaviors or other Components when they are constructed
        public void ApplyToEntity(GameObject entity)
        {
            // Return if object isn't a district
            if (entity.GetComponent<DistrictCenter>() == null)
                return;
            
            // Add a new Monobehavior component
            entity.AddComponent<ExampleMonoBehaviourComponent>();
            
            // Adds a component that can inject dependency injection classes
            _instantiator.AddComponent<BinditoInjectComponentExample>(entity);
        }
    }
}