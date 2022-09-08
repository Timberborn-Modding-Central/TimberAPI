using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx.Bootstrap;

namespace TimberbornAPI.PluginSystem
{

    /// <summary>
    /// Service for finding paths and files relative to the plugin or it's dependencies.
    /// </summary>
    public class PluginLocationService
    {
        /// <summary>
        /// Get the plugin path
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <returns>Absolute plugin path</returns>
        public string GetPluginPath(string pluginGuid)
        {
            return Path.GetDirectoryName(Chainloader.PluginInfos.First(kv => kv.Value.Metadata.GUID == pluginGuid).Value.Location);
        }

        /// <summary>
        /// Get all plugin paths that depend on pluginGuid.
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <returns>List of absolute paths</returns>
        public IEnumerable<string> GetDependentPluginPaths(string pluginGuid)
        {
            return GetDependentPluginPaths(pluginGuid, false);
        }

        /// <summary>
        /// Get all plugin paths that depend on pluginGuid.
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <param name="includeSelf">Include your plugin path</param>
        /// <returns></returns>
        public IEnumerable<string> GetDependentPluginPaths(string pluginGuid, bool includeSelf)
        {
            if (includeSelf)
                yield return GetPluginPath(pluginGuid);
            foreach (KeyValuePair<string, BepInEx.PluginInfo> keyValuePair in Chainloader.PluginInfos.Where(kv => kv.Value.Dependencies.Any(dep => dep.DependencyGUID == pluginGuid)))
                yield return Path.GetDirectoryName(keyValuePair.Value.Location);
        }

        /// <summary>
        /// Get all files inside dependent plugin location
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <param name="includeSelf">Include your plugin files</param>
        /// <returns></returns>
        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, Array.Empty<string>(), true, Array.Empty<string>(), "*", includeSelf);
        }

        /// <summary>
        /// Get all files inside dependent plugin location
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <param name="relativeDirectory">Starting directory relative to the plugin</param>
        /// <param name="searchSubDirectories">Recursive search</param>
        /// <param name="includeSelf">Include your plugin files</param>
        /// <returns></returns>
        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, relativeDirectory, searchSubDirectories, Array.Empty<string>(), "*", includeSelf);
        }

        /// <summary>
        /// Get all files inside dependent plugin location
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <param name="relativeDirectory">Starting directory relative to the plugin</param>
        /// <param name="searchSubDirectories">Recursive search</param>
        /// <param name="allowedExtensions">What extension types are allowed</param>
        /// <param name="includeSelf">Include your plugin files</param>
        /// <returns></returns>
        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, string[] allowedExtensions, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, relativeDirectory, searchSubDirectories, allowedExtensions, "*", includeSelf);
        }

        /// <summary>
        /// Get all files inside dependent plugin location
        /// </summary>
        /// <param name="pluginGuid"></param>
        /// <param name="relativeDirectory">Starting directory relative to the plugin</param>
        /// <param name="searchSubDirectories">Recursive search</param>
        /// <param name="allowedExtensions">What extension types are allowed</param>
        /// <param name="searchPattern">Search pattern of `.NET Directory.GetFiles`</param>
        /// <param name="includeSelf">Include your plugin files</param>
        /// <returns></returns>
        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, string[] allowedExtensions, string searchPattern, bool includeSelf)
        {
            List<string> filePaths = new();

            foreach (string pluginPath in GetDependentPluginPaths(pluginGuid, includeSelf))
            {
                string path = Path.Combine(pluginPath, Path.Combine(relativeDirectory));

                if (!Directory.Exists(path))
                    continue;

                if (searchSubDirectories)
                    filePaths.AddRange(RecursiveFilePathSearch(path, searchPattern, allowedExtensions));
                else
                    filePaths.AddRange(GetFiles(path, searchPattern, allowedExtensions));
            }

            return filePaths;
        }

        private IEnumerable<string> RecursiveFilePathSearch(string path, string searchPattern, string[] allowedExtensions)
        {
            List<string> filePaths = new();

            filePaths.AddRange(GetFiles(path, searchPattern, allowedExtensions));

            foreach (string directory in Directory.GetDirectories(path))
            {
                filePaths.AddRange(RecursiveFilePathSearch(directory, searchPattern, allowedExtensions));
            }

            return filePaths;
        }

        private IEnumerable<string> GetFiles(string path, string searchPattern, string[] allowedExtensions)
        {
            if (allowedExtensions == default)
                return Directory.GetFiles(path, searchPattern);

            List<string> filePaths = new();

            foreach (string file in Directory.GetFiles(path, searchPattern))
            {
                if (!allowedExtensions.Contains(Path.GetExtension(file)))
                    continue;
                filePaths.Add(file);
            }

            return filePaths;
        }
    }
}