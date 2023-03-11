using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem.Factories
{
    public class ToolGroupButtonRedFactory : IToolGroupButtonFactory
    {
        public string Id => "Red";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonRedFactory(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton Create(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create(toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-01");
        }
    }
}