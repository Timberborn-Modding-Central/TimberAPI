using System.Collections.Generic;
using TimberApi.ConfigSystem;

namespace TimberAPIExample.Examples.ConfigExample
{
    /// <summary>
    /// This config will be created into a file in the mod's 
    /// configs folder as "ExampleConfig.json" when the 
    /// mod.Configs.Get<ExampleConfig>() is called in 
    /// the entry method
    /// </summary>
    public class ExampleConfig : IConfig
    {
        public string ConfigFileName => "ExampleConfig";

        public string ConfigValue1 { get; set; }

        public int ConfigValue2 { get; set; }

        public List<float> ConfigValues3 { get; set; }

        public ExampleConfig()
        {
            ConfigValue1 = "foo";
            ConfigValue2 = 123;
            ConfigValues3 = new List<float>()
            {
                1.0f,
                2.0f,
                3.0f
            };
        }
    }
}
