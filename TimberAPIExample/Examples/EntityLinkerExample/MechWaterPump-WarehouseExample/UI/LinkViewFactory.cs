using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.MechWaterPumpWarehouseExample.UI
{
    /// <summary>
    /// Creates views for Links. The views are added to Linker/Linkee UI Fragments
    /// </summary>
    public class LinkViewFactory : BaseEntityLinkViewFactory
    {
        public LinkViewFactory(UIBuilder builder) 
            : base(builder)
        {
        }
    }
}
