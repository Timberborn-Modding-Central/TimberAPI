using Timberborn.Buildings;
using TimberbornAPI.EntityActionSystem;
using UnityEngine;

namespace TimberbornAPI.EntityLinkerSystem
{
    public class EntityActions : IEntityAction
    {
        /// <summary>
        /// Apply the Linker to every object
        /// </summary>
        /// <param name="entity"></param>
        public void ApplyToEntity(GameObject entity)
        {
            if (entity.GetComponent<Building>() != null)
            {
                entity.AddComponent<EntityLinker>();
            }
        }
    }
}
