using Newtonsoft.Json;

namespace TimberApi.SpecificationSystem;

public class GeneratedSpecification : IGeneratedSpecification
{
    public virtual bool ObjectSpecification => false;

    public string FullPath { get; }
    
    public string SpecificationName { get; }
    
    public string Json { get; }

    public GeneratedSpecification(string path, string specificationName, string json)
    {
        FullPath = path + "/" + specificationName;
        SpecificationName = specificationName;
        Json = json;
    }

    public GeneratedSpecification(string path, string specificationName, object json)
    {
        FullPath = path + "/" + specificationName;
        SpecificationName = specificationName;
        Json = JsonConvert.SerializeObject(json);
    }
}