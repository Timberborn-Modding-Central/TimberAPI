using System.Collections.Generic;
using UnityEngine;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.CustomObjectSystem
{
    public class CustomObjectRegistry : ICustomObjectRegistry
    {
		private readonly List<GameObject> CustomObjects = new();
        private bool Accessed = false;

		public void AddGameObject(GameObject gameObject)
		{
            if (Accessed)
            {
                Log.LogInfo("The CustomObjectRegistry has already been loaded by the game." +
                    "You probably need to call AddGameObject() earlier.");
            }
			CustomObjects.Add(gameObject);
		}

        public List<GameObject> GetAllGameObjects()
        {
            Accessed = true;
            return CustomObjects;
        }
    }
}

