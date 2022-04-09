using System.Collections.Generic;
using UnityEngine;

namespace TimberbornAPI.CustomObjectSystem
{
    public interface ICustomObjectRegistry
    {
        /// <summary>
        /// Add a GameObject to the game
        /// You can use this to add buildings to the game
        /// Add VERY EARLY (e.g. use AddConfiguratorBeforeLoad and IInitializableSingleton)
        /// </summary>
        /// <param name="gameObject">The gameObject to add</param>
        void AddGameObject(GameObject gameObject);

        /// <summary>
        /// Get every custom game object added to the registry
        /// </summary>
        List<GameObject> GetAllGameObjects();

    }
}