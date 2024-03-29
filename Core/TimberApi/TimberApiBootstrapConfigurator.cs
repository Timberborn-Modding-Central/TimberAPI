﻿using Bindito.Core;
using TimberApi.AssetSystem;
using TimberApi.SpecificationSystem;

namespace TimberApi
{
    internal class BootstrapConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApi>().AsSingleton();
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
            containerDefinition.Install(new SpecificationSystemGlobalConfigurator());
        }
    }
}