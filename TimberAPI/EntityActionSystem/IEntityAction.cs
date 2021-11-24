using UnityEngine;

namespace TimberbornAPI.EntityActionSystem
{
    public interface IEntityAction
    {
        void ApplyToEntity(GameObject entity);
    }
}