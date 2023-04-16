using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem.Factories
{
    public class ToolButtonDefaultFactory : IToolButtonFactory
    {
        private readonly ToolButtonFactory _toolButtonFactory;

        public ToolButtonDefaultFactory(ToolButtonFactory toolButtonFactory)
        {
            _toolButtonFactory = toolButtonFactory;
        }

        public string Id => "Default";

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification)
        {
            return _toolButtonFactory.Create(tool, toolGroupSpecification.Icon);
        }
    }
}