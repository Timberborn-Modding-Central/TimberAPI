using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.ObjectCollectionSystem
{
    public class CustomObjectCollection : IObjectCollection, ICustomObjectCollection
	{
		private static List<GameObject> CustomObjects = new();

		public void AddGameObject(GameObject gameObject)
		{
			CustomObjects.Add(gameObject);
		}

		public IEnumerable<Object> GetObjects()
		{
			return CustomObjects;
		}
	}
}
