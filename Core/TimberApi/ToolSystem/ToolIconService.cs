using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class ToolIconService
    {
        private readonly IResourceAssetLoader _resourceAssetLoader;

        private readonly Dictionary<string, Sprite> _icons = new();

        public ToolIconService(IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        public void AddIcon(Sprite sprite)
        {
            _icons.Add(sprite.name, sprite);
        }

        public Sprite GetIcon(string path)
        {
            return _icons.TryGetValue(path, out var sprite) ? sprite : _resourceAssetLoader.Load<Sprite>(path);
        }
    }
}