using System;
using System.Linq;
using TimberbornAPI.AssetLoaderSystem.Exceptions;

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
                Console.WriteLine($"Failed to load asset.");
                Console.WriteLine(e.StackTrace);
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
                Console.WriteLine($"Failed to load asset.");
                Console.WriteLine(e.StackTrace);
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
                Console.WriteLine($"Given prefix ({e.Prefix}) was not found. did you load it in the correct scene: {AssetRegistry.ActiveScene}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            catch (AssetNotFoundException e)
            {
                Console.WriteLine($"Given asset location was not found.");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong please contact the mod owner.");
                Console.WriteLine(e.Message);
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
                Console.WriteLine($"Failed to load asset.");
                Console.WriteLine(e.StackTrace);
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
                Console.WriteLine($"Failed to load asset.");
                Console.WriteLine(e.StackTrace);
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
                Console.WriteLine($"Given prefix ({e.Prefix}) was not found.");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            catch (AssetNotFoundException e)
            {
                Console.WriteLine($"Given asset location was not found.");
                Console.WriteLine(e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong please contact the mod owner.");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}