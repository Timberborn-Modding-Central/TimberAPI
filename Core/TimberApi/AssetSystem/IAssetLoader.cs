using UnityEngine;

namespace TimberApi.AssetSystem
{
    public interface IAssetLoader
    {
        /// <summary>
        ///     Load a single asset with path string
        ///     Example: Prefix/Subfolder/Filename/ButtonUI
        /// </summary>
        /// <param name="path">Path to the asset</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string path) where T : Object;

        /// <summary>
        ///     Load a single asset with prefix and path string
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <param name="path">Path to asset without the prefix</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string prefix, string path) where T : Object;

        /// <summary>
        ///     Load a single asset
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <param name="pathToFile"></param>
        /// <param name="name">name of object</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T Load<T>(string prefix, string pathToFile, string name) where T : Object;

        /// <summary>
        ///     Load all assets inside bundle
        ///     Example: Prefix/Subfolder/Filename
        /// </summary>
        /// <param name="path">Path to the asset</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T[] LoadAll<T>(string path) where T : Object;

        /// <summary>
        ///     Load all assets inside bundle
        /// </summary>
        /// <param name="prefix">Prefix that used in the register</param>
        /// <typeparam name="T">Unity asset object</typeparam>
        T[] LoadAll<T>(string prefix, string pathToFile) where T : Object;
    }
}