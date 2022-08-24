using System;
using System.Collections.Generic;
using TimberApi.Core.Common;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core2.ConfigSystem;
using TimberApi.Core2.ModSystem;
using UnityEngine;

namespace TimberApi.Core.ConfigSystem
{
    public class ConfigService : IConfigService
    {
        private readonly string _consoleTag;

        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ConfigRepository _configRepository;

        public ConfigService(IInternalConsoleWriter consoleWriter, IEnumerable<IConfig> configs, string consoleTag)
        {
            _consoleWriter = consoleWriter;
            _consoleTag = consoleTag;
            _configRepository = ConfigRepository.CreateRepository(configs);
        }

        public T Get<T>() where T : IConfig, new()
        {
            try
            {
                return _configRepository.GetConfig<T>();
            }
            catch (Exception e)
            {
                _consoleWriter.LogAs(_consoleTag,  "Failed to retrieve config, returning default", LogType.Warning);
                _consoleWriter.LogAs(_consoleTag, "Failed config reason: " + e.Message, LogType.Error);
                return new T();
            }
        }
    }
}