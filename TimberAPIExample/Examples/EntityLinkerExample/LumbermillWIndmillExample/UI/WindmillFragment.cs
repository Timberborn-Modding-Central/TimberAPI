using Timberborn.Localization;
using Timberborn.SelectionSystem;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample.UI
{
    public class WindmillFragment : BaseLinkeeFragment<LumbermillWindmillLink, LumbermillBehaviour, WindmillBehaviour, LinkViewFactory>
    {
        public WindmillFragment(UIBuilder builder, 
                                LinkViewFactory entityLinkViewFactory, 
                                SelectionManager selectionManager, 
                                ILoc loc) 
            : base(builder, entityLinkViewFactory, selectionManager, loc)
        {
        }
    }
}
