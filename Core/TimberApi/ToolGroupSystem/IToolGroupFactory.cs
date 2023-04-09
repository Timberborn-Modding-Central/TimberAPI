namespace TimberApi.ToolGroupSystem
{
    public interface IToolGroupFactory
    {
        public string Id { get; }

        public ApiToolGroup Create(ToolGroupSpecification toolGroupSpecification);
    }
}