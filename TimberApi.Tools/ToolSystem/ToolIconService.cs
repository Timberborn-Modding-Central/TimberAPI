using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem;

public class ToolIconService
{
    private readonly Dictionary<string, Sprite> _icons = new();

    private readonly IAssetLoader _assetLoader;

    public ToolIconService(IAssetLoader assetLoader)
    {
        _assetLoader = assetLoader;
    }

    public void AddIcon(string key, Sprite sprite)
    {
        _icons.Add(key, sprite);
    }

    public Sprite GetIcon(string path)
    {
        return _icons.TryGetValue(path, out var sprite) ? sprite : _assetLoader.Load<Sprite>(path);
    }
}