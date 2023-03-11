using Timberborn.ToolSystem;

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

        public ToolGroupButton Create(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create(toolGroup, toolGroup.Icon, "UI/Images/BottomBar/subbutton-bg-01");
        }
    }
}