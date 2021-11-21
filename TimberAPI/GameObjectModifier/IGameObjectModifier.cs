using UnityEngine;

namespace TimberbornAPI.GameObjectModifier
{
    public interface IGameObjectModifier
    {
        /// <summary>
        /// Triggers when a new object is initialized, after placed and loaded on game
        /// </summary>
        /// <param name="gameObject"></param>
        void Modify(GameObject gameObject);
    }
}