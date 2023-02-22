using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonGreenVisualiser : IToolGroupButtonVisualiser
    {
        public string Id => "Green";

        private readonly ToolGroupButtonFactory _toolGroupButtonFactory;

        public ToolGroupButtonGreenVisualiser(ToolGroupButtonFactory toolGroupButtonFactory)
        {
            _toolGroupButtonFactory = toolGroupButtonFactory;
        }

        public ToolGroupButton GetToolGroupButton(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification)
        {
            return _toolGroupButtonFactory.CreateGreen(toolGroup);
        }
    }
}