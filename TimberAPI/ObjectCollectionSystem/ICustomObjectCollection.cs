using UnityEngine;

namespace TimberbornAPI.ObjectCollectionSystem
{
    public interface ICustomObjectCollection
    {
        /// <summary>
        /// Add a GameObject to the game
        /// You can use this to add buildings to the game
        /// </summary>
        /// <param name="gameObject">The gameObject to add</param>
        void AddGameObject(GameObject gameObject);

    }
}