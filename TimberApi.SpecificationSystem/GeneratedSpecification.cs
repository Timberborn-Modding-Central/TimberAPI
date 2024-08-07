using Newtonsoft.Json;

namespace TimberApi.SpecificationSystem;

public class GeneratedSpecification
{
    private static readonly string _specificationPath = "specifications";

    public GeneratedSpecification(string path, string specificationName, string json, bool objectSpecification = false)
    {
        FullPath = $"{_specificationPath}/{path}/{specificationName}".ToLower();
        SpecificationName = specificationName;
        Json = json;
        ObjectSpecification = objectSpecification;
    }

    public GeneratedSpecification(string path, string specificationName, object json, bool objectSpecification = false)
    {
        FullPath = $"{_specificationPath}/{path}/{specificationName}".ToLower();
        SpecificationName = specificationName;
        Json = JsonConvert.SerializeObject(json);
        ObjectSpecification = objectSpecification;
    }

    public virtual bool ObjectSpecification { get; }

    public string FullPath { get; }

    public string SpecificationName { get; }

    public string Json { get; }
}