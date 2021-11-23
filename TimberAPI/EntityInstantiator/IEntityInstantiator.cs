using UnityEngine;

namespace TimberbornAPI.EntityInstantiatorSystem
{
    public interface IEntityInstantiator
    {
        void Instantiate(GameObject gameObject);
    }
}