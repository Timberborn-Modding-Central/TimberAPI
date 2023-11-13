using System.Collections.Immutable;

namespace TimberApi.ModSystem
{
    public interface ISpecificationDirectory
    {
        string Path { get; }

        bool Enabled { get; set; }
        
        ImmutableArray<string> RequiredDependencies { get; }
    }
}