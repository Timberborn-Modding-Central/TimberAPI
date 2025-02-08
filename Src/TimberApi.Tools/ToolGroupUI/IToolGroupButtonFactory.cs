using TimberApi.Tools.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpec = TimberApi.Tools.ToolGroupSystem.ToolGroupSpec;

namespace TimberApi.Tools.ToolGroupUI;

public interface IToolGroupButtonFactory
{
    public string Id { get; }

    public ToolGroupButton Create(IToolGroup toolGroup, ToolGroupSpec toolGroupSpec);
}