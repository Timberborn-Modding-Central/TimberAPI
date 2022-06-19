using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.CustomObjectSystem
{
    public class CustomObjectRegistry : ICustomObjectRegistry
    {
		private readonly HashSet<GameObject> CustomObjects = new();
        private bool Accessed = false;

		public void AddGameObject(GameObject gameObject)
        {
            var added = CustomObjects.Add(gameObject);
            if (Accessed && added)
            {
                Log.LogInfo("The CustomObjectRegistry has already been loaded by the game. " +
                            "You probably need to call AddGameObject() earlier.");
            }
        }

        public List<GameObject> GetAllGameObjects()
        {
            Accessed = true;
            return CustomObjects.ToList();
        }
    }
}

