using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem.Factories
{
    public class ToolGroupButtonBlueFactory : IToolGroupButtonFactory
    {
        public string Id => "Blue";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonBlueFactory(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton Create(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.Create(toolGroup, toolGroup.Icon, "UI/Images/BottomBar/button-bg-02");
        }
    }
}