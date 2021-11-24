using Bindito.Unity;
using Timberborn.GameDistricts;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class AddComponentExample : IEntityAction
    {
        private readonly IInstantiator _instantiator;

        public AddComponentExample(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void ApplyToEntity(GameObject entity)
        {
            // Return if object isn't a district
            if(entity.GetComponent<DistrictCenter>() == null)
                return;
            
            // Add a default component
            entity.AddComponent<ComponentExample>();
            
            // Adds a component that can inject dependency injection classes
            _instantiator.AddComponent<BinditoComponentExample>(entity);
        }
    }
}