using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonRedFactory : IToolButtonFactory
    {
        public string Id => "Red";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonRedFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.Create(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-01");
        }
    }
}