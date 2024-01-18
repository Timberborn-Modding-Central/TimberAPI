using TimberApi.PresetSystem.PresetOptions;
using TimberApi.UiBuilderSystem.ElementSystem;
using UnityEngine;

namespace TimberApi.PresetSystem.PresetTypes
{
    public interface IButtonPreset : IElementPreset, ILocalizationPreset, ISizePreset
    {
        ButtonBuilder Build(ButtonBuilder builder);
    }
}