using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem.Factories
{
    public class ToolGroupButtonGreenFactory : IToolGroupButtonFactory
    {
        public string Id => "Green";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonGreenFactory(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton Create(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create(toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-03");
        }
    }
}