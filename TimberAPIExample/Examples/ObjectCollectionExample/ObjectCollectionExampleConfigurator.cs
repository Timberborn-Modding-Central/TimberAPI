using System;
using Bindito.Core;

namespace TimberAPIExample.Examples.ObjectCollectionExample
{
    public class ObjectCollectionExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ObjectCollectionAddExample>().AsSingleton();
        }
    }
}