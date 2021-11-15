using System;
using TimberbornAPI.AssetLoader.PluginSystem;

namespace TimberbornAPI.AssetLoader.Exceptions
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