﻿using System;
using System.Collections.Generic;
using System.Linq;
using TimberApi.ConfigSystem;

namespace TimberApi.Core.ConfigSystem
{
    internal class ConfigRepository
    {
        private readonly Dictionary<Type, IConfig> _configs;

        public ConfigRepository(Dictionary<Type, IConfig> configs)
        {
            _configs = configs;
        }

        internal static ConfigRepository CreateRepository(IEnumerable<IConfig> configs)
        {
            return new ConfigRepository(configs.ToDictionary(config => config.GetType(), config => config));
        }

        public T GetConfig<T>()
        {
            return (T) _configs[typeof(T)];
        }
    }
}