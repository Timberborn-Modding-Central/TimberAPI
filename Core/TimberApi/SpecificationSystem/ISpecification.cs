namespace TimberApi.SpecificationSystem
{
    public interface ISpecification
    {
        string Name { get; }

        string SpecificationName { get; }

        string FullName { get; }

        bool IsOriginal { get; }

        public bool IsReplace { get; }

        string LoadJson();
    }
}