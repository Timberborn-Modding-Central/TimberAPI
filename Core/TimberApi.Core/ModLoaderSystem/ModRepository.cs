using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModRepository : IModRepository
    {
        private ImmutableArray<IMod> _mods;

        private ImmutableDictionary<string, IMod> _uniqueIdMods = null!;

        private ImmutableDictionary<Assembly, IMod> _assemblyMods = null!;

        private readonly ModLoader _modLoader;

        public ModRepository(ModLoader modLoader)
        {
            _modLoader = modLoader;
        }

        public void LoadMods()
        {
            if(_mods != null)
            {
                throw new Exception("Mods are already loaded");
            }

            _mods = _modLoader.LoadedMods;
            _uniqueIdMods = _mods.ToImmutableDictionary(mod => mod.UniqueId);
            #pragma warning disable CS8714
            _assemblyMods = _mods.Where(mod => !mod.IsCodelessMod).ToImmutableDictionary(mod => mod.LoadedAssembly)!;
            #pragma warning restore CS8714
        }

        public ImmutableArray<IMod> All()
        {
            return _mods;
        }

        public bool TryGetByUniqueId(string uniqueId, out IMod mod)
        {
            return _uniqueIdMods.TryGetValue(uniqueId, out mod!);
        }

        public bool TryGetByAssembly(Assembly assembly, out IMod mod)
        {
            return _assemblyMods.TryGetValue(assembly, out mod!);
        }
    }
}