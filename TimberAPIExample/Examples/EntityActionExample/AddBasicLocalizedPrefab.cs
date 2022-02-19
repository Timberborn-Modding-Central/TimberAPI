using Bindito.Unity;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.GameDistricts;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.LocalizationSystem;
using UnityEngine;

namespace TimberAPIExample.Examples.EntityActionExample
{
    public class AddBasicLocalizedPrefab : IEntityAction
    {
        private readonly IInstantiator _instantiator;

        public AddBasicLocalizedPrefab(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void ApplyToEntity(GameObject entity)
        {
            if (entity.GetComponent<PlaceableBlockObject>() == null)
                return;

            Debug.Log(entity.name);
            if (entity.name == "4x1Arch")
            {
                Debug.Log("I did It");
                entity.AddComponent<BasicLabeledPrefab>();
            }
        }
    }
}

