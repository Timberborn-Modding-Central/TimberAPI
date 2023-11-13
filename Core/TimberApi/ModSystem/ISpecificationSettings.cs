using System.Collections.Generic;
using System.Collections.Immutable;

namespace TimberApi.ModSystem
{
    public interface ISpecificationSettings
    {
        string BasePath { get; }
        
        ImmutableArray<ISpecificationDirectory> Directories { get; }
        
        IEnumerable<string> LoadableDirectories { get; }
    }
}