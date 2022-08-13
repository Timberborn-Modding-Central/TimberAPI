using System.Collections.Generic;
using System.Linq;
using TimberbornAPI.AssetLoaderSystem.Exceptions;
using TimberbornAPI.Common;

namespace TimberbornAPI.AssetLoaderSystem.PluginSystem
{
    internal class PluginRepository : IPluginRepository
    {
        private readonly List<Plugin> _plugins;

        public PluginRepository()
        {
            _plugins = new List<Plugin>();
        }

        /// <summary>
        /// Finds plugin by their prefix withing the active entry point or global
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        /// <exception cref="PrefixNotFoundException"></exception>
        public Plugin FindByPrefix(string prefix)
        {
            Plugin modPlugin = _plugins.FirstOrDefault(plugin => plugin.Prefix == prefix && (plugin.LoadingScene == AssetRegistry.ActiveScene
                || plugin.LoadingScene == SceneEntryPoint.Global));

            if (modPlugin == null)
                throw new PrefixNotFoundException(prefix);
            return modPlugin;
        }

        public void Add(Plugin plugin)
        {
            if (PluginPrefixInUse(plugin))
                throw new PluginPrefixInUseException(plugin);

            _plugins.Add(plugin);
        }

        public List<Plugin> All()
        {
            return _plugins;
        }

        /// <summary>
        /// Checks if prefix is already used in the given entrypoint or global
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        private bool PluginPrefixInUse(Plugin plugin)
        {
            return _plugins.Any(p => (p.Prefix == plugin.Prefix && p.LoadingScene == plugin.LoadingScene)
                                                || p.Prefix == plugin.Prefix && (p.LoadingScene == SceneEntryPoint.Global
                                                    || plugin.LoadingScene == SceneEntryPoint.Global));
        }
    }
}