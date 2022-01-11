using System;
using Bindito.Core;
using Timberborn.EntitySystem;

namespace TimberbornAPI.ObjectCollectionSystem
{
    public class ObjectCollectionSystemConfigurator : IConfigurator
	{
		public void Configure(IContainerDefinition containerDefinition)
		{
			containerDefinition.MultiBind<IObjectCollection>().To<CustomObjectCollection>().AsSingleton();		
		}
	}
}

