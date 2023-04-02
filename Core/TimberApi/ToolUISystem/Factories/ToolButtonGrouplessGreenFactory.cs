using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonGrouplessGreenFactory : IToolButtonFactory
    {
        public string Id => "GrouplessGreen";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonGrouplessGreenFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-03");
        }
    }
}