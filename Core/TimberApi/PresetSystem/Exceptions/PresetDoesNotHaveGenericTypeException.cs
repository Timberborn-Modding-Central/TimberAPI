using System;

namespace TimberApi.PresetSystem.Exceptions
{
    public class PresetDoesNotHaveGenericTypeException : Exception
    {
        public PresetDoesNotHaveGenericTypeException(Type preset) : base($"The given preset: {preset}, does not extend IPreset<TElementBuilder>.")
        {
        }
    }
}