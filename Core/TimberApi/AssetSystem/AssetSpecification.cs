using System.Collections.Immutable;

namespace TimberApi.AssetSystem
{
    public class AssetSpecification
    {
        public AssetSpecification(ImmutableArray<string> ignoreDirectoryPrefixes)
        {
            IgnoreDirectoryPrefixes = ignoreDirectoryPrefixes;
        }

        public ImmutableArray<string> IgnoreDirectoryPrefixes { get; }
    }
}