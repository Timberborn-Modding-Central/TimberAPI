using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using TimberApi.ModSystem;
using UnityEngine;

namespace TimberApi.Core.ModLoaderSystem
{
    public class SpecificationSettings : ISpecificationSettings
    {
        public string BasePath { get; }
        
        public ImmutableArray<ISpecificationDirectory> Directories { get; }
        
        public IEnumerable<string> LoadableDirectories
        {
            get
            {
                if(Directories.IsEmpty)
                {
                    return new List<string>
                    {
                        BasePath
                    };
                }

                return Directories.Where(directory => directory.Enabled).Select(directory => Path.Combine(BasePath, directory.Path));
            }
        }

        public SpecificationSettings(string basePath, IEnumerable<ISpecificationDirectory> directories)
        {
            BasePath = basePath;
            Directories = directories.ToImmutableArray();
        }
    }
}