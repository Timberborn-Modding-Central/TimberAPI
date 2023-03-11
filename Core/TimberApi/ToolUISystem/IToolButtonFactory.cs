using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolUISystem
{
    public interface IToolButtonFactory
    {
        public string Id { get; }

        public ToolButton Create(Tool tool, ToolSpecification toolGroupSpecification);
    }
}