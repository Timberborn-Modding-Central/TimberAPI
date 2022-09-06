using Newtonsoft.Json;

namespace TimberApi.New.ConfigSystem
{
    public interface IConfig
    {
        [JsonIgnore]
        [JsonProperty(Required = Required.DisallowNull)]
        string ConfigFileName { get; }
    }
}