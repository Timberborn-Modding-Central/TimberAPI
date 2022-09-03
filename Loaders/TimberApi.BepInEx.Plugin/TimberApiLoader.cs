using System;
using System.IO;
using System.Reflection;
using BepInEx;

namespace TimberApi.BepInExPlugin
{
    public static class TimberApiLoader
    {
        private static string _timberApiPath = string.Empty;

        private static string _timberApiLogPath = string.Empty;

        private static string _timberApiCorePath = string.Empty;

        private static string _timberApiPatchersPath = string.Empty;

        private static string _timberApiModsPath = string.Empty;

        private static string _timberApiConfigsPath = string.Empty;

        private static string _bepInExPluginPath = string.Empty;

        private static readonly string[] CoreDlls =
        {
            "TimberApi.Core.dll"
        };

        private static readonly string[] LibraryDlls =
        {
            "GriffinPlus.Lib.FastActivator.dll",
            "TimberApiVersioning.dll",
            "TimberApi.LoaderInterfaces.dll",
            "TimberApi.New.dll"
        };


        /// <summary>
        /// Doorstop entry point
        /// Load order:
        /// 1. Libraries
        /// 2. TimberApi core
        /// 3. Additional patchers
        /// </summary>
        public static void Start()
        {
            try
            {
                LoadTimberApiPaths();
                SetTimberApiPathEnvironmentVariables();
                EnsurePathsExists(_timberApiLogPath, _timberApiCorePath, _timberApiPatchersPath, _timberApiModsPath, _timberApiConfigsPath);
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
        private static void SetTimberApiPathEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable("TIMBER_LOADER_TYPE", "TimberAPI");
            Environment.SetEnvironmentVariable("TIMBER_API_PATH", _timberApiPath);
            Environment.SetEnvironmentVariable("TIMBER_API_LOG_PATH", _timberApiLogPath);
            Environment.SetEnvironmentVariable("TIMBER_API_CORE_PATH", _timberApiCorePath);
            Environment.SetEnvironmentVariable("TIMBER_API_PATCHERS_PATH", _timberApiPatchersPath);
            Environment.SetEnvironmentVariable("TIMBER_API_MODS_PATH", _timberApiModsPath);
            Environment.SetEnvironmentVariable("TIMBER_API_CONFIGS_PATH", _timberApiConfigsPath);
            Environment.SetEnvironmentVariable("BEP_IN_EX_PLUGIN_PATH", _bepInExPluginPath);
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
        private static void HandleException(Exception exception)
        {
            File.WriteAllText(Path.Combine(_timberApiLogPath, $"Exception-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), exception.ToString());
        }

        /// <summary>
        /// Loads all absolute api paths
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">Throws exception when game directory could not be loaded</exception>
        private static void LoadTimberApiPaths()
        {
            string timberApiRootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "..");

            _timberApiPath = Path.Combine(timberApiRootPath);
            _timberApiLogPath = Path.Combine(timberApiRootPath, "logs");
            _timberApiCorePath = Path.Combine(timberApiRootPath, "core");
            _timberApiPatchersPath = Path.Combine(timberApiRootPath, "patchers");
            _timberApiModsPath = Path.Combine(timberApiRootPath, "mods");
            _timberApiConfigsPath = Path.Combine(timberApiRootPath, "configs");
            _bepInExPluginPath = Paths.PluginPath;
        }

        /// <summary>
        /// Loads essential assemblies for TimberAPI
        /// </summary>
        private static void LoadLibraries()
        {
            foreach (string libraryDll in LibraryDlls)
            {
                Assembly.LoadFile(Path.Combine(_timberApiCorePath, libraryDll));
            }
        }

        /// <summary>
        /// Loads TimberAPI Patcher
        /// </summary>
        private static void LoadCore()
        {
            foreach (string coreDll in CoreDlls)
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