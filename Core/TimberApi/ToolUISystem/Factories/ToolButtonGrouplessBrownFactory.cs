using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonGrouplessBrownFactory : IToolButtonFactory
    {
        public string Id => "GrouplessBrown";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonGrouplessBrownFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/subbutton-bg-01");
        }
    }
}