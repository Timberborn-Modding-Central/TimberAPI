using System.Collections.Generic;

namespace TimberbornAPI.AssetLoader.PluginSystem
{
    internal interface IPluginRepository
    {
        Plugin FindByPrefix(string prefix);
        
        void Add(Plugin plugin);
        
        List<Plugin> All();
    }
}