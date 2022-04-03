using Timberborn.Localization;
using Timberborn.PickObjectToolSystem;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using TimberbornAPI.EntityLinkerSystem.UI;

namespace TimberAPIExample.Examples.EntityLinkerExample.LumbermillWIndmillExample.UI
{
    public class StartLinkButton : BaseStartLinkingButton<LumbermillBehaviour, WindmillBehaviour, LumbermillWindmillLink>
    {
        public StartLinkButton(ILoc loc, 
                               PickObjectTool pickObjectTool, 
                               SelectionManager selectionManager, 
                               ToolManager toolManager) 
            : base(loc, pickObjectTool, selectionManager, toolManager)
        {
        }
    }
}
