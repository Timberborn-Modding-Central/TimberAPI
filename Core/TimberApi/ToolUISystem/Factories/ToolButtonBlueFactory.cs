using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonBlueFactory : IToolButtonFactory
    {
        public string Id => "Blue";

        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonBlueFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.Create(tool, toolGroupSpecification.Icon, "UI/Images/BottomBar/button-bg-02");
        }
    }
}