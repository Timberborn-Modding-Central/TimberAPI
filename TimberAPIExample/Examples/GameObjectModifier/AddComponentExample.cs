using Bindito.Unity;
using Timberborn.GameDistricts;
using TimberbornAPI.GameObjectModifier;
using UnityEngine;

namespace TimberAPIExample.Examples.GameObjectModifier
{
    public class AddComponentExample : IEntityInstantiator
    {
        private readonly IInstantiator _instantiator;

        public AddComponentExample(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void Instantiate(GameObject gameObject)
        {
            // Return if object isn't a district
            if(gameObject.GetComponent<DistrictCenter>() == null)
                return;
            
            // Add a default component
            gameObject.AddComponent<ComponentExample>();
            
            // Adds a component that can inject dependency injection classes
            _instantiator.AddComponent<BinditoComponentExample>(gameObject);
        }
    }
}