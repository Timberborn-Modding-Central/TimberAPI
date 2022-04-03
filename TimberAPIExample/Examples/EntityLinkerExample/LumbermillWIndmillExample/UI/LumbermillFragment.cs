using Timberborn.Localization;
using Timberborn.SelectionSystem;
using Timberborn.Workshops;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample.UI
{
    public class LumbermillFragment : BaseLinkerFragment<Manufactory, LumbermillBehaviour, WindmillBehaviour, LumbermillWindmillLink, LinkViewFactory, StartLinkButton>
    {
        public LumbermillFragment(UIBuilder builder, 
                                  LinkViewFactory entityLinkViewFactory, 
                                  StartLinkButton startLinkButton, 
                                  SelectionManager selectionManager, 
                                  ILoc loc) 
            : base(builder, entityLinkViewFactory, startLinkButton, selectionManager, loc)
        {
        }
    }
}
