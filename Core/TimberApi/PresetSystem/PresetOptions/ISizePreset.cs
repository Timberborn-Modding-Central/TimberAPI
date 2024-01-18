using UnityEngine.UIElements;

namespace TimberApi.PresetSystem.PresetOptions
{
    public interface ISizePreset
    {
        Length? Width { get; set; }
        
        Length? Height { get; set; }
    }
}