using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class ToolIconService
    {
        private readonly Dictionary<string, Sprite> _icons = new();
        
        private readonly IResourceAssetLoader _resourceAssetLoader;

        public ToolIconService(IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        public void AddIcon(string key, Sprite sprite)
        {
            _icons.Add(key, sprite);
        }

        public Sprite GetIcon(string path)
        {
            return _icons.TryGetValue(path, out var sprite) ? sprite : _resourceAssetLoader.Load<Sprite>(path);
        }
    }
}