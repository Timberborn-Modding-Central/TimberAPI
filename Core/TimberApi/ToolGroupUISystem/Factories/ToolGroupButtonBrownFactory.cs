using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.ToolGroupUISystem.Factories
{
    public class ToolGroupButtonBrownFactory : IToolGroupButtonFactory
    {
        public string Id => "Brown";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonBrownFactory(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create((ToolGroup) toolGroup, toolGroup.Icon, "UI/Images/BottomBar/subbutton-bg-01");
        }
    }
}