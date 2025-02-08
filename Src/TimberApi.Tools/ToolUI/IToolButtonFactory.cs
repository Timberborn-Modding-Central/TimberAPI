using TimberApi.Tools.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI;

public interface IToolButtonFactory
{
    public string Id { get; }

    public ToolButton Create(Tool tool, ToolSpec toolGroupSpec);
}