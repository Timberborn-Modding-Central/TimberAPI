using System.Collections.Generic;
using Timberborn.EntitySystem;
using UnityEngine;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.CustomObjectSystem
{
    public class CustomObjectCollection : IObjectCollection
	{

		public IEnumerable<Object> GetObjects()
		{
			List<GameObject> objects = TimberAPI.CustomObjectRegistry.GetAllGameObjects();
			Log.LogInfo($"Loaded {objects.Count} custom objects");
			return objects;
		}
	}
}
