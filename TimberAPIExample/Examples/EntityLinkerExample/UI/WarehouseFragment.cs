using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.UI
{
    public class WarehouseFragment : BaseLinkeeFragment<MechanicalWaterPumpWarehouseLink, MechanicalWaterPumpBehaviour, WarehouseBehaviour, LinkViewFactory>
    {
        public WarehouseFragment(UIBuilder builder, 
                                 LinkViewFactory entityLinkViewFactory, 
                                 SelectionManager selectionManager, 
                                 ILoc loc) 
            : base(builder, entityLinkViewFactory, selectionManager, loc)
        {
        }
    }
}
