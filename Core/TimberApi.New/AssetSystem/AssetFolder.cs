using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimberApi.Common.Helpers;
using TimberApi.New.AssetSystem.Exceptions;
using TimberApi.New.SceneSystem;

namespace TimberApi.New.AssetSystem
{
    internal class AssetFolder
    {
        private static readonly string[] AllowedExtensions = {"", ".bundle", ".asset"};

        private readonly Dictionary<string, ModAssetBundle> _assetBundles;

        private readonly string _rootFolderPath;

        public readonly SceneEntrypoint SceneEntrypoint;

        public AssetFolder(SceneEntrypoint sceneEntrypoint, string rootFolderPath)
        {
            SceneEntrypoint = sceneEntrypoint;
            _rootFolderPath = rootFolderPath;
            _assetBundles = new Dictionary<string, ModAssetBundle>();
            FillAssetBundleDirectory(rootFolderPath);
        }

        public ModAssetBundle GetAssetBundleAtPath(string filePath)
        {
            if (!_assetBundles.TryGetValue(filePath.ToLower(), out ModAssetBundle modAssetBundle))
            {
                throw new AssetFilePathNotFoundException(Path.Combine(_rootFolderPath, filePath));
            }

            return modAssetBundle;
        }

        public void Load()
        {
            foreach (ModAssetBundle modAssetBundle in _assetBundles.Values)
            {
                modAssetBundle.LoadAssetBundle();
            }
        }

        public void Unload()
        {
            foreach (ModAssetBundle modAssetBundle in _assetBundles.Values)
            {
                modAssetBundle.UnloadAssetBundle();
            }
        }

        private void FillAssetBundleDirectory(string rootFolderPath)
        {
            if (!Directory.Exists(rootFolderPath))
            {
                return;
            }

            string[] rootPath = _rootFolderPath.Split(Path.DirectorySeparatorChar);
            foreach (string absoluteFilePath in FileService.GetFiles(rootFolderPath, "*", AllowedExtensions))
            {
                string[] seperatedAbsoluteDirectoryPath = Path.GetDirectoryName(absoluteFilePath)!.Split(Path.DirectorySeparatorChar);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(absoluteFilePath);
                string directoryPath = AbsolutePathToRelativePath(seperatedAbsoluteDirectoryPath, rootPath);
                string lookupPath = Path.Combine(directoryPath, fileNameWithoutExtension).Replace(Path.DirectorySeparatorChar, '/').ToLower();
                _assetBundles.Add(lookupPath, new ModAssetBundle(fileNameWithoutExtension, absoluteFilePath));
            }
        }

        private static string AbsolutePathToRelativePath(IEnumerable<string> path, IReadOnlyCollection<string> rootPath)
        {
            return string.Join(Path.DirectorySeparatorChar, path.Skip(rootPath.Count));
        }
    }
}