using Timberborn.Localization;
using Timberborn.SelectionSystem;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.UI
{
    /// <summary>
    /// Definition of custom fargment for Warehouse, which acts as the Linkee.
    /// No custom implementation, base view is enough for us
    /// </summary>
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
