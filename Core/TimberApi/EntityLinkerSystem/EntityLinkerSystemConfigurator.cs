﻿using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using Timberborn.Buildings;
using Timberborn.TemplateSystem;

namespace TimberApi.EntityLinkerSystem
{
    [Configurator(SceneEntrypoint.InGame)]
    public class EntityLinkerSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityLinkObjectSerializer>().AsSingleton();
            containerDefinition.MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
        }

        private static TemplateModule ProvideTemplateModule()
        {
            var builder = new TemplateModule.Builder();
            builder.AddDecorator<Building, EntityLinker>();
            return builder.Build();
        }
    }
}