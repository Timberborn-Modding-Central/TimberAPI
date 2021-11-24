using UnityEngine;

namespace TimberbornAPI.EntityInstantiatorSystem
{
    public interface IEntityAction
    {
        void ApplyToEntity(GameObject entity);
    }
}