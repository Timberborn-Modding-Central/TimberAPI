using System.Collections.Generic;
using Timberborn.EntitySystem;
using UnityEngine;

namespace TimberbornAPI.CustomObjectSystem
{
    public class CustomObjectCollection : IObjectCollection
	{

		public IEnumerable<Object> GetObjects()
		{
			return TimberAPI.CustomObjectRegistry.GetAllGameObjects();
		}
	}
}
