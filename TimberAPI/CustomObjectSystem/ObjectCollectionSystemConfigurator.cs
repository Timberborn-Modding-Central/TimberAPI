using System;
using Bindito.Core;
using Timberborn.EntitySystem;

namespace TimberbornAPI.CustomObjectSystem
{
    public class ObjectCollectionSystemConfigurator : IConfigurator
	{
		public void Configure(IContainerDefinition containerDefinition)
		{
			containerDefinition.MultiBind<IObjectCollection>().To<CustomObjectCollection>().AsSingleton();		
		}
	}
}

