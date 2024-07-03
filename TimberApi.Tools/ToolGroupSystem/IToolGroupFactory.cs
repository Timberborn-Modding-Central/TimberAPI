namespace TimberApi.Tools.ToolGroupSystem;

public interface IToolGroupFactory
{
    public string Id { get; }

    public IToolGroup Create(ToolGroupSpecification toolGroupSpecification);
}