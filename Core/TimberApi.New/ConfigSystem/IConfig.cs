using Newtonsoft.Json;

namespace TimberApi.Core2.ConfigSystem
{
    public interface IConfig
    {
        [JsonIgnore]
        [JsonProperty(Required = Required.DisallowNull)]
        string ConfigFileName { get; }
    }
}