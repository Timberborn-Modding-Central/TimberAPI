using Newtonsoft.Json;

namespace TimberApi.SpecificationSystem;

public class GeneratedSpec
{
    private static readonly string _specPath = "blueprints";

    public GeneratedSpec(string path, string specName, string json, bool isUnityObjectSpec = false)
    {
        FullPath = $"{_specPath}/{path}/{specName}".ToLower();
        SpecName = specName;
        Json = json;
        IsUnityObjectSpec = isUnityObjectSpec;
    }

    public GeneratedSpec(string path, string specName, object json, bool isUnityObjectSpec = false)
    {
        FullPath = $"{_specPath}/{path}/{specName}".ToLower();
        SpecName = specName;
        Json = JsonConvert.SerializeObject(json);
        IsUnityObjectSpec = isUnityObjectSpec;
    }

    public virtual bool IsUnityObjectSpec { get; }

    public string FullPath { get; }

    public string SpecName { get; }

    public string Json { get; }
}