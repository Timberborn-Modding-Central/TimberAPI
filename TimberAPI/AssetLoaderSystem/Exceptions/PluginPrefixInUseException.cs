using System;
using TimberbornAPI.AssetLoaderSystem.PluginSystem;

namespace TimberbornAPI.AssetLoaderSystem.Exceptions
{
    internal class PluginPrefixInUseException : Exception
    {
        public readonly Plugin Plugin;

        public PluginPrefixInUseException(Plugin plugin)
        {
            Plugin = plugin;
        }
    }
}