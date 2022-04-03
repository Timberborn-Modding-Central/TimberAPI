using Bindito.Unity;
using Timberborn.PowerGenerating;
using Timberborn.Workshops;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample
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
            //Add custom linker class to lumbermill
            var manufactory = entity.GetComponent<Manufactory>();
            if (manufactory != null && manufactory.name.Contains("LumberMill"))
            {
                _instantiator.AddComponent<LumbermillBehaviour>(entity);
            }

            //Add custom class to Windmills
            var windmill = entity.GetComponent<WindPoweredGenerator>();
            if (windmill != null)
            {
                _instantiator.AddComponent<WindmillBehaviour>(entity);
            }
        }
    }
}
