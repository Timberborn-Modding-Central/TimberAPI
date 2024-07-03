namespace TimberApi.SpecificationSystem;

public class GeneratedObjectSpecification : GeneratedSpecification
{
    public override bool ObjectSpecification => true;

    public GeneratedObjectSpecification(string path, string specificationName, string json) : base(path, specificationName, json)
    {
    }

    public GeneratedObjectSpecification(string path, string specificationName, object json) : base(path, specificationName, json)
    {
    }
}