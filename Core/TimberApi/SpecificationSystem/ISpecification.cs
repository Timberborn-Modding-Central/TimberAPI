namespace TimberApi.SpecificationSystem
{
    public interface ISpecification
    {
        string FullName { get; }

        string SpecificationName { get; }

        bool IsOriginal { get; }

        public bool IsReplace { get; }

        string LoadJson();
    }
}