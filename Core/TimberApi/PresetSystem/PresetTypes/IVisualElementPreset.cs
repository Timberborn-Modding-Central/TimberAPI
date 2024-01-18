using UnityEngine.UIElements;

namespace TimberApi.PresetSystem.PresetTypes
{
    public interface IVisualElementPreset
    {
        string Id { get; }
        
        VisualElement build(string name);
    }
}