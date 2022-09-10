using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Bindito.Core;
using TimberApi.New.ModSystem;
using UnityEngine;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModRepository : MonoBehaviour, IModRepository
    {
        private ImmutableDictionary<Assembly, IMod> _assemblyModDirectory = null!;

        private ImmutableArray<IMod> _codeMods;

        private ModLoader _modLoader = null!;
        private ImmutableArray<IMod> _mods;

        private ImmutableDictionary<string, IMod> _uniqueIdModDirectory = null!;

        public ImmutableArray<IMod> All()
        {
            return _mods;
        }

        public ImmutableArray<IMod> GetCodeMods()
        {
            return _codeMods;
        }

        public bool TryGetByUniqueId(string uniqueId, out IMod mod)
        {
            return _uniqueIdModDirectory.TryGetValue(uniqueId, out mod!);
        }

        public bool TryGetByAssembly(Assembly assembly, out IMod mod)
        {
            return _assemblyModDirectory.TryGetValue(assembly, out mod!);
        }

        [Inject]
        public void InjectDependencies(ModLoader modLoader)
        {
            _modLoader = modLoader;
        }

        public void LoadMods()
        {
            if (_mods != null)
            {
                throw new Exception("Mods are already loaded");
            }

            _mods = _modLoader.LoadedMods;
            _codeMods = _mods.Where(mod => !mod.IsCodelessMod).ToImmutableArray();
            _uniqueIdModDirectory = _mods.ToImmutableDictionary(mod => mod.UniqueId);
#pragma warning disable CS8714
            _assemblyModDirectory = _codeMods.ToImmutableDictionary(mod => mod.LoadedAssembly)!;
#pragma warning restore CS8714
        }
    }
}