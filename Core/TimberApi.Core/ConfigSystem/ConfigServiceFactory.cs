using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TimberApi.Core.Common;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core2.ConfigSystem;
using UnityEngine;

namespace TimberApi.Core.ConfigSystem
{
    public class ConfigServiceFactory
    {
        private static readonly string _configFolder = "configs";

        private static readonly string _configExtension = ".json";

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private readonly IInternalConsoleWriter _consoleWriter;

        public ConfigServiceFactory(IInternalConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new ConfigContractResolver()
            };
        }

        public ConfigService CreateWithAssemblyConfigs(Assembly assembly, string configDirectoryPath, string consoleTag)
        {
            List<IConfig> configs = new List<IConfig>();

            foreach (Type type in assembly.GetTypesWithInterface<IConfig>()!)
            {
                var config = (IConfig)Activator.CreateInstance(type);

                string configFilePath = Path.Combine(configDirectoryPath, _configFolder, config.ConfigFileName + _configExtension);

                if (!File.Exists(configFilePath))
                {
                    _consoleWriter.LogAs(consoleTag, "Config (" + config.ConfigFileName + ") not found, saving a new one", LogType.Log);
                    SaveConfigFile(consoleTag, configFilePath, configDirectoryPath, config);
                }
                else
                {
                    PopulateConfig(consoleTag, config, configFilePath);
                }

                configs.Add(config);
            }

            return new ConfigService(_consoleWriter, configs, consoleTag);
        }

        private void SaveConfigFile(string consoleTag, string configFilePath, string configDirectoryPath, IConfig config)
        {
            try
            {
                if(!Directory.Exists(configDirectoryPath))
                    Directory.CreateDirectory(configDirectoryPath);
                File.WriteAllText(configFilePath, JsonConvert.SerializeObject(config));
            }
            catch (Exception e)
            {
                _consoleWriter.LogAs(consoleTag, "Failed to save config: " + e.Message, LogType.Error);
            }
        }

        private void PopulateConfig(string consoleTag, IConfig config, string configPath)
        {
            try
            {
                JsonConvert.PopulateObject(File.ReadAllText(configPath), config, _jsonSerializerSettings);
            }
            catch (Exception e)
            {
                _consoleWriter.LogAs(consoleTag, "Failed to populate config:" + e.Message, LogType.Error);
            }
        }
    }
}