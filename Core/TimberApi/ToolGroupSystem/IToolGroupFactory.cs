namespace TimberApi.ToolGroupSystem
{
    public interface IToolGroupFactory
    {
        public string Id { get; }

        public IToolGroup Create(ToolGroupSpecification toolGroupSpecification);
    }
}