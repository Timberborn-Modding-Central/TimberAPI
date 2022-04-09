using System;
using System.Collections.Generic;
using UnityEngine;

namespace TimberbornAPI.CustomObjectSystem
{
    public class CustomObjectRegistry : ICustomObjectRegistry
    {
		private List<GameObject> CustomObjects = new();
        private Boolean Accessed = false;

		public void AddGameObject(GameObject gameObject)
		{
            if (Accessed)
            {
                Console.WriteLine("The CustomObjectRegistry has already been loaded by the game." +
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

