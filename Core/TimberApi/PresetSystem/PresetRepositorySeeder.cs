using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.PresetSystem.Exceptions;
using TimberApi.UiBuilderSystem;
using TimberApi.UiBuilderSystem.ElementBuilders;

namespace TimberApi.PresetSystem
{
    internal class PresetRepositorySeeder
    {
        public PresetRepositorySeeder(PresetRepository presetRepository, IEnumerable<IPreset> presets)
        {
            var validatedPresets = new Dictionary<Type, Dictionary<string, IPreset>>();
            
            foreach (var preset in presets)
            {
                var builderType = preset.GetType()
                    .GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPreset<>))
                    ?.GetGenericArguments()[0];
                
                if (builderType is null)
                {
                    throw new PresetDoesNotHaveGenericTypeException(preset.GetType());
                }
                
                if (! typeof(BaseBuilder).IsAssignableFrom(builderType))
                {
                    throw new PresetDoesNotExtendElementBuilderException();
                }
            
                if (validatedPresets.ContainsKey(builderType))
                {
                    validatedPresets[builderType].Add(preset.Id, preset);
                }
                else
                {
                    validatedPresets.Add(builderType, new Dictionary<string, IPreset> { { preset.Id, preset } });
                }
            }

            presetRepository.Load(validatedPresets.ToImmutableDictionary());
        }
    }
}