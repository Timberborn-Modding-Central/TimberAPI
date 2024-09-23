using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem;

public interface IToolFactory
{
    public string Id { get; }

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null);
}