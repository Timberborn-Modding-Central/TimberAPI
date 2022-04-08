using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
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
