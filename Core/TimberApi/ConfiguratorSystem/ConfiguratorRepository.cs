using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Bindito.Core;
using TimberApi.SceneSystem;

namespace TimberApi.ConfiguratorSystem
{
    internal class ConfiguratorRepository
    {
        public static Dictionary<SceneEntrypoint, ImmutableArray<IConfigurator>> SceneConfigurators = new();

        public void SetSceneConfigurators(SceneEntrypoint sceneEntrypoint, IEnumerable<IConfigurator> configurators)
        {
            if (SceneConfigurators.ContainsKey(sceneEntrypoint))
            {
                throw new Exception($"{sceneEntrypoint} already loaded");
            }

            SceneConfigurators.Add(sceneEntrypoint, configurators.ToImmutableArray());
        }
    }
}