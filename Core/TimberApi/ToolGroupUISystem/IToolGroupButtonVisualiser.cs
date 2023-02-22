using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem
{
    public interface IToolGroupButtonVisualiser
    {
        public string Id { get; }

        public ToolGroupButton GetToolGroupButton(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification);
    }
}