using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolGroupUI;

public interface IToolGroupButtonFactory
{
    public string Id { get; }

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpec toolGroupSpec);
}