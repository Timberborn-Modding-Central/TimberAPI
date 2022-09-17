using Newtonsoft.Json;

namespace TimberApi.ConfigSystem
{
    public interface IConfig
    {
        [JsonIgnore]
        [JsonProperty(Required = Required.DisallowNull)]
        string ConfigFileName { get; }
    }
}