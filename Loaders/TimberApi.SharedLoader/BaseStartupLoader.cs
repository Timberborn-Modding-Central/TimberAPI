using System;
using System.IO;
using System.Reflection;
using HarmonyLib;

namespace TimberApi.SharedLoader
{
    public class BaseStartupLoader
    {
        private readonly string _timberApiPath;

        private readonly string _timberApiLogsPath;

        private readonly string _timberApiCorePath;

        private readonly string _timberApiModsPath;

        private readonly string _timberApiConfigsPath;

        private readonly string _timberApiLoaderType;

        private readonly string[] _coreDlls =
        {
            "TimberApi.Core.dll"
        };

        private readonly string[] _libraryDlls =
        {
            "TimberApi.Common.dll",
            "TimberApi.LoaderInterfaces.dll",
            "TimberApi.New.dll"
        };

        public BaseStartupLoader(string loaderType, string timberApiRootPath, string modsPath, string[]? libraryDlls = null)
        {
            _timberApiPath = timberApiRootPath;
            _timberApiModsPath = modsPath;
            _timberApiLoaderType = loaderType;
            _timberApiLogsPath = Path.Combine(timberApiRootPath, "logs");
            _timberApiCorePath = Path.Combine(timberApiRootPath, "core");
            _timberApiConfigsPath = Path.Combine(timberApiRootPath, "configs");
            if(libraryDlls != null)
            {
                _libraryDlls = _libraryDlls.AddRangeToArray(libraryDlls);
            }
        }

        /// <summary>
        /// Doorstop entry point
        /// Load order:
        /// 1. Libraries
        /// 2. TimberApi core
        /// 3. Additional patchers
        /// </summary>
        public void Run()
        {
            try
            {
                SetTimberApiPathEnvironmentVariables();
                EnsurePathsExists(_timberApiPath, _timberApiLogsPath, _timberApiCorePath, _timberApiModsPath, _timberApiConfigsPath);
                LoadLibraries();
                LoadCore();
            }
            catch (Exception e)
            {
                HandleException(e);
                throw;
            }
        }

        /// <summary>
        /// Sets environment variables to be used in other assemblies
        /// </summary>
        private void SetTimberApiPathEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable("TIMBER_LOADER_TYPE", _timberApiLoaderType);
            Environment.SetEnvironmentVariable("TIMBER_API_PATH", _timberApiPath);
            Environment.SetEnvironmentVariable("TIMBER_API_LOG_PATH", _timberApiLogsPath);
            Environment.SetEnvironmentVariable("TIMBER_API_CORE_PATH", _timberApiCorePath);
            Environment.SetEnvironmentVariable("TIMBER_API_MODS_PATH", _timberApiModsPath);
            Environment.SetEnvironmentVariable("TIMBER_API_CONFIGS_PATH", _timberApiConfigsPath);
        }

        /// <summary>
        /// Creates directories when they don't exist
        /// </summary>
        /// <param name="paths">Absolute path to directory</param>
        private static void EnsurePathsExists(params string[] paths)
        {
            foreach (string path in paths)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// Reusable exception logger
        /// This will log all exceptions thrown in all loaded assemblies: mods & libraries
        /// </summary>
        /// <param name="exception"></param>
        private void HandleException(Exception exception)
        {
            File.WriteAllText(Path.Combine(_timberApiLogsPath, $"Exception-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), exception.ToString());
        }

        /// <summary>
        /// Loads essential assemblies for TimberAPI
        /// </summary>
        private void LoadLibraries()
        {
            foreach (string libraryDll in _libraryDlls)
            {
                Assembly.LoadFile(Path.Combine(_timberApiCorePath, libraryDll));
            }
        }

        /// <summary>
        /// Loads TimberAPI Patcher
        /// </summary>
        private void LoadCore()
        {
            foreach (string coreDll in _coreDlls)
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(_timberApiCorePath, coreDll));
                InitializeCoreEntrypoint(assembly);
            }
        }

        /// <summary>
        /// Searches if the assembly has any class that depends on `ITimberApiPatcher` and initializes it
        /// Used for loading TimberAPI patchers
        /// </summary>
        /// <param name="assembly"></param>
        private static void InitializeCoreEntrypoint(Assembly assembly)
        {
            assembly
                .GetType("TimberApi.Core.TimberApiEntrypoint")
                .GetMethod("LoadTimberApiManager", BindingFlags.Public | BindingFlags.Static)!
                .Invoke(null, null);
        }
    }
}