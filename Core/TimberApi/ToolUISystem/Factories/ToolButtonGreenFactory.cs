using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonGreenFactory : IToolButtonFactory
    {
        public string Id => "Green";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonGreenFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.Create(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-03");
        }
    }
}