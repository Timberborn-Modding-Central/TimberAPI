using TimberApi.UiBuilderSystem;

namespace TimberApi.PresetSystem
{
    public interface IPreset
    {
        string Id { get; }
    }
    
    public interface IPreset<TElementBuilder> : IPreset where TElementBuilder : BaseBuilder
    {
        TElementBuilder Build(TElementBuilder builder);
    }
}
