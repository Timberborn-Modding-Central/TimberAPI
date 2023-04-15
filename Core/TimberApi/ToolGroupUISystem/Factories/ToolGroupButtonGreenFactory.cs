using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

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

        public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-03");
        }
    }
}