using System.Collections.Generic;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModAsset : IModAsset
    {
        public ModAsset(string prefix, IEnumerable<string> scenes, string path)
        {
            Prefix = prefix;
            Scenes = scenes;
            Path = path;
        }

        public string Prefix { get; set; }

        public IEnumerable<string> Scenes { get; set; }

        public string Path { get; set; }
    }
}