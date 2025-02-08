namespace TimberApi.SpecificationPatcherSystem;

public interface ISpecificationModifierResolver
{
    public string Modifier { get; }
    
    public bool Resolve(string argument);
}