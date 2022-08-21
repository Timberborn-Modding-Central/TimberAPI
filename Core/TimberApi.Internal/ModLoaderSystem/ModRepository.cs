using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using TimberApi.Core.ModSystem;

namespace TimberApi.Internal.ModLoaderSystem
{
    internal class ModRepository : IModRepository
    {
        private ImmutableArray<IMod> _mods;

        private ImmutableDictionary<string, IMod> _uniqueIdMods;

        private ImmutableDictionary<Assembly, IMod> _assemblyMods;

        public void SetMods(ImmutableArray<IMod> mods)
        {
            if(_mods != null)
            {
                throw new Exception("Mods are already loaded");
            }

            _mods = mods;
            _uniqueIdMods = mods.ToImmutableDictionary(mod => mod.UniqueId);
            #pragma warning disable CS8714
            _assemblyMods = mods.Where(mod => !mod.IsCodelessMod).ToImmutableDictionary(mod => mod.LoadedAssembly)!;
            #pragma warning restore CS8714
        }

        public ImmutableArray<IMod> All()
        {
            return _mods;
        }

        public bool TryGetByUniqueId(string uniqueId, out IMod? mod)
        {
            return _uniqueIdMods.TryGetValue(uniqueId, out mod);
        }

        public bool TryGetByAssembly(Assembly assembly, out IMod mod)
        {
            return _assemblyMods.TryGetValue(assembly, out mod!);
        }
    }
}