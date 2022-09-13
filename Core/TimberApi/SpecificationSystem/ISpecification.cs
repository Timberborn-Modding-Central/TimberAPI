namespace TimberApi.SpecificationSystem
{
    public interface ISpecification
    {
        string FullName { get; }

        string SpecificationName { get; }

        bool IsOriginal { get; }

        string LoadJson();
    }
}