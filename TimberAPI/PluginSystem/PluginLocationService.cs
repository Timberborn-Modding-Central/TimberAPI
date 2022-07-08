using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx.Bootstrap;

namespace TimberbornAPI.PluginSystem
{
    public class PluginLocationService
    {
        public string GetPluginPath(string pluginGuid)
        {
            return Path.GetDirectoryName(Chainloader.PluginInfos.First(kv => kv.Value.Metadata.GUID == pluginGuid).Value.Location);
        }

        public IEnumerable<string> GetDependentPluginPaths(string pluginGuid)
        {
            return GetDependentPluginPaths(pluginGuid, false);
        }

        public IEnumerable<string> GetDependentPluginPaths(string pluginGuid, bool includeSelf)
        {
            if (includeSelf)
                yield return GetPluginPath(pluginGuid);
            foreach (KeyValuePair<string, BepInEx.PluginInfo> keyValuePair in Chainloader.PluginInfos.Where(kv => kv.Value.Dependencies.Any(dep => dep.DependencyGUID == pluginGuid)))
                yield return Path.GetDirectoryName(keyValuePair.Value.Location);
        }

        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, Array.Empty<string>(), true, Array.Empty<string>(), "*", includeSelf);
        }

        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, relativeDirectory, searchSubDirectories, Array.Empty<string>(), "*", includeSelf);
        }

        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, string[] allowedExtensions, bool includeSelf = false)
        {
            return GetDependentPluginFiles(pluginGuid, relativeDirectory, searchSubDirectories, allowedExtensions, "*", includeSelf);
        }

        public IEnumerable<string> GetDependentPluginFiles(string pluginGuid, string[] relativeDirectory, bool searchSubDirectories, string[] allowedExtensions, string searchPattern, bool includeSelf)
        {
            List<string> filePaths = new List<string>();

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
            List<string> filePaths = new List<string>();

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

            List<string> filePaths = new List<string>();

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