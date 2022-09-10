using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using TimberApi.New.AssetSystem.Exceptions;
using TimberApi.New.ModSystem;
using TimberApi.New.SceneSystem;
using UnityEngine;

namespace TimberApi.New.AssetSystem
{
    internal class AssetRepository
    {
        private readonly Dictionary<string, AssetFolder> _modAssets;
        private readonly List<string> _usedAssetRootFolderPaths;

        public AssetRepository()
        {
            _modAssets = new Dictionary<string, AssetFolder>();
            _usedAssetRootFolderPaths = new List<string>();
        }

        public void Add(IMod mod)
        {
            foreach (IModAssetInfo modAssetInfo in mod.Assets)
            {
                Add(modAssetInfo.Prefix, modAssetInfo.SceneEntrypoint, mod.DirectoryPath, modAssetInfo.Path);
            }
        }

        public void Add(string prefix, SceneEntrypoint sceneEntrypoint, string assetRootFolderPath, string assetFolder)
        {
            try
            {
                if (_modAssets.ContainsKey(prefix.ToLower()))
                {
                    throw new PrefixAlreadyExistsException(prefix);
                }

                string fullAssetRootFolderPath = Path.Combine(assetRootFolderPath, assetFolder);
                if (HasOverlappingAssetDirectoryPaths(fullAssetRootFolderPath))
                {
                    throw new AssetRootFolderPathOverlappingException(fullAssetRootFolderPath);
                }

                _usedAssetRootFolderPaths.Add(fullAssetRootFolderPath);
                _modAssets.Add(prefix.ToLower(), new AssetFolder(sceneEntrypoint, fullAssetRootFolderPath));
            }
            catch (PrefixAlreadyExistsException e)
            {
                TimberApi.ConsoleWriter.Log("Failed to add prefix: " + e.Message, LogType.Exception);
                throw;
            }
            catch (Exception e)
            {
                TimberApi.ConsoleWriter.Log($"Failed to add prefix ({prefix}), Exception: " + e, LogType.Exception);
                throw;
            }
        }

        public IEnumerable<AssetFolder> GetAll()
        {
            return _modAssets.Values;
        }

        public IEnumerable<AssetFolder> GetByEntrypoint(SceneEntrypoint sceneEntrypoint)
        {
            return _modAssets.Values.Where(folder => folder.SceneEntrypoint.HasFlag(sceneEntrypoint));
        }

        public bool TryGetByPrefix(string prefix, [MaybeNullWhen(false)] out AssetFolder assetFolder)
        {
            return _modAssets.TryGetValue(prefix.ToLower(), out assetFolder);
        }

        private bool HasOverlappingAssetDirectoryPaths(string assetRootFolderPath)
        {
            return _usedAssetRootFolderPaths.Any(assetRootFolderPath.Contains) || _usedAssetRootFolderPaths.Any(usedPath => usedPath.Contains(assetRootFolderPath));
        }
    }
}