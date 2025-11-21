using TimberApi.Tools.ToolSystem;
using Timberborn.ToolButtonSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolUI;

public interface IToolButtonFactory
{
    public string Id { get; }

    public ToolButton Create(ITool tool, ToolSpec toolGroupSpec);
}