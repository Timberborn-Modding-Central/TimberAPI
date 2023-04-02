using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonGrouplessRedFactory : IToolButtonFactory
    {
        public string Id => "GrouplessRed";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonGrouplessRedFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.CreateGroupless(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-01");
        }
    }
}