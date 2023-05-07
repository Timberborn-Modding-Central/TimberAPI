using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = Timberborn.ToolSystem.ToolGroupSpecification;

namespace TimberApi.ToolGroupUISystem
{
    public interface IToolGroupButtonFactory
    {
        public string Id { get; }

        public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpecification toolGroupSpecification);
    }
}