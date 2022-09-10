using Newtonsoft.Json;
using TimberApi.New.ConfigSystem;

namespace TimberApi.New
{
    public class TestConfig : IConfig
    {
        [JsonIgnore]
        public string Test { get; set; }

        public string ConfigFileName { get; }
    }
}