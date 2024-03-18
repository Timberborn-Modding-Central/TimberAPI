using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using TimberApi.PresetSystem.Exceptions;
using TimberApi.UiBuilderSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;

namespace TimberApi.PresetSystem
{
    public class PresetRepository
    {
        private bool _loaded;
        
        private ImmutableDictionary<Type, Dictionary<string, IPreset>> _registeredPresets = null!;
        
        internal void Load(ImmutableDictionary<Type, Dictionary<string, IPreset>> presets)
        {
            if (_loaded)
            {
                throw new PresetRepositoryAlreadyLoadedException();
            }
            
            _registeredPresets = presets;

            _loaded = true;
        }
        
        public IPreset<TElementBuilder> Get<TElementBuilder>(string presetId) where TElementBuilder : BaseBuilder
        {
            var preset = _registeredPresets[typeof(SliderBuilder)][presetId];
            
            return (IPreset<TElementBuilder>) preset;
        }
    }
}