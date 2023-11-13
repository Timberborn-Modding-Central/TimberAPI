using System.Collections.Generic;
using System.Collections.Immutable;
using TimberApi.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    public class SpecificationDirectory : ISpecificationDirectory
    {
        public string Path { get; }
        
        public ImmutableArray<string> RequiredDependencies { get; }

        public bool Enabled { get; set; }
        
        public SpecificationDirectory(string path, IEnumerable<string> requiredDependencies)
        {
            RequiredDependencies = requiredDependencies.ToImmutableArray();
            Path = path;
        }
    }
}