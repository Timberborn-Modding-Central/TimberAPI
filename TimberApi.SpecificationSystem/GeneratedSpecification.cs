using Newtonsoft.Json;

namespace TimberApi.SpecificationSystem;

public class GeneratedSpecification
{
    private static string _specificationPath = "specifications";
    
    public virtual bool ObjectSpecification { get; }

    public string FullPath { get; }
    
    public string SpecificationName { get; }
    
    public string Json { get; }

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
        ObjectSpecification = objectSpecification;
        Json = JsonConvert.SerializeObject(json);
    }
}