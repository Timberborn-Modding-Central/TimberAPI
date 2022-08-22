using System.Collections.Generic;

namespace TimberApi.Core2.ModSystem
{
    public interface IModAsset
    {
        string Prefix { get; }

        IEnumerable<string> Scenes { get; }

        string Path { get; }
    }
}