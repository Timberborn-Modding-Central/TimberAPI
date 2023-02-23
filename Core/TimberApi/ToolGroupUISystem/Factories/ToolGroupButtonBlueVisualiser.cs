using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonBlueVisualiser : IToolGroupButtonVisualiser
    {
        public string Id => "Blue";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonBlueVisualiser(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton GetToolGroupButton(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.CreateBlue(toolGroup);
        }
    }
}