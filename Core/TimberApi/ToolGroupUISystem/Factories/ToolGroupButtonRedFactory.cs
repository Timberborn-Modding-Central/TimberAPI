using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

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

        public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-01");
        }
    }
}