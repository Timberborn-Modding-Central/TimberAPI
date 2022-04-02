using Bindito.Core;
using System;
using System.Collections.Generic;
using System.Text;
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

            containerDefinition.Bind<LinkerFragment<WaterMover, MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink>>().AsSingleton();
            containerDefinition.Bind<LinkeeFragment<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour>>().AsSingleton();
            containerDefinition.Bind<EntityLinkViewFactory>().AsSingleton();
            containerDefinition.Bind<StartLinkingButton<MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink>>().AsSingleton();
            containerDefinition.MultiBind<EntityPanelModule>().ToProvider<EntityPanelModuleProvider>().AsSingleton();
        }


        private class EntityPanelModuleProvider : IProvider<EntityPanelModule>
        {
            private readonly LinkerFragment<WaterMover, MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink> _linkerFragment;
            private readonly LinkeeFragment<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour> _linkeeFragment;

            public EntityPanelModuleProvider(LinkerFragment<WaterMover, MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink> linkerFragment,
                                             LinkeeFragment<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour> linkeeFragment)
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
