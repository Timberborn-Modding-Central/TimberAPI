using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupUISystem
{
    public interface IToolGroupButtonFactory
    {
        public string Id { get; }

        public ToolGroupButton Create(ToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification);
    }
}