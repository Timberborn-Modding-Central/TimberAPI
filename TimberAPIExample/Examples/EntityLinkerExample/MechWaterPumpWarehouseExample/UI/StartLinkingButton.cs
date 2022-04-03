﻿using Timberborn.Localization;
using Timberborn.PickObjectToolSystem;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using TimberbornAPI.EntityLinkerSystem.UI;

namespace TimberAPIExample.Examples.EntityLinkerExample.MechWaterPumpWarehouseExample.UI
{
    /// <summary>
    /// Definition of the button that starts the linking process
    /// </summary>
    public class StartLinkingButton : BaseStartLinkingButton<MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink>
    {
        public StartLinkingButton(ILoc loc, 
                                  PickObjectTool pickObjectTool, 
                                  SelectionManager selectionManager, 
                                  ToolManager toolManager) 
            : base(loc, pickObjectTool, selectionManager, toolManager)
        {
        }
    }
}