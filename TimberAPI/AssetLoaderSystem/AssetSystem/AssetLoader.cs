using System;
using System.Linq;
using TimberbornAPI.AssetLoaderSystem.Exceptions;
using static TimberbornAPI.Internal.TimberAPIPlugin;

namespace TimberbornAPI.AssetLoaderSystem.AssetSystem
{
    public class AssetLoader : IAssetLoader
    {
        public T Load<T>(string path) where T : UnityEngine.Object
        {
            try
            {
                string[] slicedPath = path.Split("/");
                string prefix = slicedPath.First();
                string newPath = string.Join("/", slicedPath.Skip(1));

                return Load<T>(prefix, newPath);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to load asset.");
                Log.LogError(e.StackTrace);
                throw;
            }
        }

        public T Load<T>(string prefix, string path) where T : UnityEngine.Object
        {
            try
            {
                string[] slicedPath = path.Split("/");
                string fileName = slicedPath[slicedPath.Length - 2];
                string name = slicedPath[slicedPath.Length - 1];
                string[] assetPath = slicedPath.Take(slicedPath.Length - 2).ToArray();
                return Load<T>(prefix, assetPath, fileName, name);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to load asset.");
                Log.LogError(e.StackTrace);
                throw;
            }
        }

        public T Load<T>(string prefix, string[] path, string fileName, string name) where T : UnityEngine.Object
        {
            try
            {
                return AssetRegistry.PluginRepository.FindByPrefix(prefix).AssetRepository
                    .FindByPathAndFileName(path, fileName).AssetBundle.LoadAsset<T>(name);
            }
            catch (PrefixNotFoundException e)
            {
                Log.LogError($"Given prefix ({e.Prefix}) was not found. did you load it in the correct scene: {AssetRegistry.ActiveScene}");
                Log.LogError(e.StackTrace);
                throw;
            }
            catch (AssetNotFoundException e)
            {
                Log.LogError($"Given asset location ({e.Filename}) was not found.");
                Log.LogError(e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                Log.LogError($"Something went wrong: please contact the mod owner.");
                Log.LogError(e.Message);
                throw;
            }
        }

        public T[] LoadAll<T>(string path) where T : UnityEngine.Object
        {
            try
            {
                string[] slicedPath = path.Split("/");
                string prefix = slicedPath.First();
                string newPath = string.Join("/", slicedPath.Skip(1));

                return LoadAll<T>(prefix, newPath);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to load asset.");
                Log.LogError(e.StackTrace);
                throw;
            }
        }

        public T[] LoadAll<T>(string prefix, string path) where T : UnityEngine.Object
        {
            try
            {
                string[] slicedPath = path.Split("/");
                string fileName = slicedPath[slicedPath.Length - 1];
                string[] assetPath = slicedPath.Take(slicedPath.Length - 1).ToArray();
                return LoadAll<T>(prefix, assetPath, fileName);
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to load asset.");
                Log.LogError(e.StackTrace);
                throw;
            }
        }

        public T[] LoadAll<T>(string prefix, string[] path, string fileName) where T : UnityEngine.Object
        {
            try
            {
                return AssetRegistry.PluginRepository.FindByPrefix(prefix).AssetRepository
                    .FindByPathAndFileName(path, fileName).AssetBundle.LoadAllAssets<T>();
            }
            catch (PrefixNotFoundException e)
            {
                Log.LogError($"Given prefix ({e.Prefix}) was not found.");
                Log.LogError(e.StackTrace);
                throw;
            }
            catch (AssetNotFoundException e)
            {
                Log.LogError($"Given asset location ({e.Filename}) was not found.");
                Log.LogError(e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                Log.LogError($"Something went wrong please contact the mod owner.");
                Log.LogError(e.Message);
                throw;
            }
        }
    }
}