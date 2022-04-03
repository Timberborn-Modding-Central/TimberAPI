using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TimberAPIExample.Examples.EntityLinkerExample.UI;
using Timberborn.EntityPanelSystem;
using Timberborn.WaterBuildings;
using TimberbornAPI;
using TimberbornAPI.EntityActionSystem;
using TimberbornAPI.EntityLinkerSystem.UI;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    public class EntityLinkerConfigurator : IConfigurator
    {
        public static void AddLabels()
        {
            TimberAPI.Localization.AddLabel("Entitylink.StartLink", "Attach");
            TimberAPI.Localization.AddLabel("Entitylink.StartLinkingTip", "Cool tip");
            TimberAPI.Localization.AddLabel("Entitylink.StartLinkingTitle", "Cool title");
        }

        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<IEntityAction>().To<EntityActions>().AsSingleton();

            containerDefinition.Bind<MechanicalWaterPumpWarehouseLinkSerializer>().AsSingleton();

            containerDefinition.Bind<MechanicalWaterPumpFragment>().AsSingleton();
            containerDefinition.Bind<WarehouseFragment>().AsSingleton();
            containerDefinition.Bind<LinkViewFactory>().AsSingleton();
            containerDefinition.Bind<StartLinkingButton>().AsSingleton();

            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }


        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly MechanicalWaterPumpFragment _linkerFragment;
            private readonly WarehouseFragment _linkeeFragment;

            public EntityPanelModuleProvider(MechanicalWaterPumpFragment linkerFragment,
                                             WarehouseFragment linkeeFragment)
            {
                _linkerFragment = linkerFragment;
                _linkeeFragment = linkeeFragment;
            }

            public EntityPanelModule Get()
            {
                EntityPanelModule.Builder builder = new EntityPanelModule.Builder();
                builder.AddBottomFragment(_linkerFragment);
                builder.AddBottomFragment(_linkeeFragment);
                return builder.Build();
            }
        }
    }
}
