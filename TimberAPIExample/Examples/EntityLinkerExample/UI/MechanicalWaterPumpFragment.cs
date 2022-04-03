using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using Timberborn.WaterBuildings;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.UI
{
    public class MechanicalWaterPumpFragment : BaseLinkerFragment<WaterMover, MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink, LinkViewFactory, StartLinkingButton>
    {
        public MechanicalWaterPumpFragment(UIBuilder builder, 
                                           LinkViewFactory entityLinkViewFactory, 
                                           StartLinkingButton startLinkButton, 
                                           SelectionManager selectionManager, 
                                           ILoc loc) 
            : base(builder, entityLinkViewFactory, startLinkButton, selectionManager, loc)
        {
        }
    }
}
