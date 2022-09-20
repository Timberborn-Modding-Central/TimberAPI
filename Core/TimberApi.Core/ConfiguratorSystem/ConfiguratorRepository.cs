using System.Collections.Generic;
using Bindito.Core;
using TimberApi.SceneSystem;

namespace TimberApi.Core.ConfiguratorSystem
{
    internal class ConfiguratorRepository
    {
        public Dictionary<SceneEntrypoint, List<IConfigurator>> SceneConfigurators = new();

        public void AddRange(SceneEntrypoint sceneEntrypoint, IEnumerable<IConfigurator> configurators)
        {
            if (SceneConfigurators.ContainsKey(sceneEntrypoint))
            {
                SceneConfigurators[sceneEntrypoint].AddRange(configurators);
            }
            else
            {
                SceneConfigurators.Add(sceneEntrypoint, new List<IConfigurator>(configurators));
            }
        }
    }
}