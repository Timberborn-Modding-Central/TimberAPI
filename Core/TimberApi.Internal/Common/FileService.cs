using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimberApi.Internal.Common
{
    public static class FileService
    {
        /// <summary>
        /// Gets files that are filtered with multiple extensions
        /// </summary>
        public static IEnumerable<string> GetFiles(string path, string searchPattern, string[] allowedExtensions, SearchOption searchOption = SearchOption.AllDirectories)
        {
            return !Directory.Exists(path) ? Array.Empty<string>() : Directory.GetFiles(path, searchPattern, searchOption).Where(file => allowedExtensions.Contains(Path.GetExtension(file)));
        }

        /// <summary>
        /// Gets files from an array of base paths that are filtered with multiple extensions
        /// </summary>
        public static IEnumerable<string> GetFiles(IEnumerable<string> paths, string searchPattern, string[] allowedExtensions, SearchOption searchOption = SearchOption.AllDirectories)
        {
            return paths.SelectMany(path => GetFiles(path, searchPattern, allowedExtensions, searchOption));
        }

        /// <summary>
        /// Base use of `Directory.GetFiles`
        /// </summary>
        public static IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.AllDirectories)
        {
            return !Directory.Exists(path) ? Array.Empty<string>() : Directory.GetFiles(path, searchPattern, searchOption);
        }

        /// <summary>
        /// Gets files from an array of base paths, with default `Directory.GetFiles` parameters
        /// </summary>
        public static IEnumerable<string> GetFiles(IEnumerable<string> paths, string searchPattern, SearchOption searchOption = SearchOption.AllDirectories)
        {
            return paths.SelectMany(path => GetFiles(path, searchPattern, searchOption));
        }
    }
}