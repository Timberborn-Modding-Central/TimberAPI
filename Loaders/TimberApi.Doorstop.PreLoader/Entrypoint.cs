using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TimberApi.LoaderInterfaces;

namespace Doorstop
{
    internal class Entrypoint
    {
        private static string _timberApiLogPath = string.Empty;

        private static string _timberApiCorePath = string.Empty;

        private static string _timberApiPatchersPath = string.Empty;

        private static string _timberApiModPath = string.Empty;

        private static readonly string[] CoreDlls =
        {
            "TimberApi.Core.dll",
            "TimberApi.Internal.dll"
        };

        private static readonly string[] LibraryDlls =
        {
            "Mono.Cecil.dll",
            "Mono.Cecil.Mdb.dll",
            "Mono.Cecil.Pdb.dll",
            "Mono.Cecil.Rocks.dll",
            "MonoMod.Utils.dll",
            "0Harmony.dll",
            "TimberApi.LoaderInterfaces.dll"
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
                LoadTimberApiPaths(Path.GetDirectoryName(Environment.GetEnvironmentVariable("DOORSTOP_INVOKE_DLL_PATH")) ?? string.Empty);
                SetTimberApiPathEnvironmentVariables();
                EnsurePathsExists(_timberApiLogPath, _timberApiCorePath, _timberApiPatchersPath, _timberApiModPath);
                LoadLibraries();
                LoadCore();
                LoadPatchers();
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
            Environment.SetEnvironmentVariable("TIMBER_API_LOG_PATH", _timberApiLogPath);
            Environment.SetEnvironmentVariable("TIMBER_API_CORE_PATH", _timberApiCorePath);
            Environment.SetEnvironmentVariable("TIMBER_API_PATCHERS_PATH", _timberApiPatchersPath);
            Environment.SetEnvironmentVariable("TIMBER_API_MODS_PATH", _timberApiModPath);
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
        /// Loads all assemblies in side the patcher folder and initializes
        /// </summary>
        private static void LoadPatchers()
        {
            foreach (string dependencyDll in Directory.GetFiles(Path.Combine(_timberApiPatchersPath), "*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(_timberApiPatchersPath, dependencyDll));
                InitializePatchersInAssembly(assembly);
            }
        }

        /// <summary>
        /// Loads all absolute api paths
        /// </summary>
        /// <param name="invokeDllPath">Absolute preloader path</param>
        /// <exception cref="DirectoryNotFoundException">Throws exception when game directory could not be loaded</exception>
        private static void LoadTimberApiPaths(string invokeDllPath)
        {
            DirectoryInfo timberApiPath = Directory.GetParent(invokeDllPath)!;

            string gamePath = timberApiPath.Parent?.FullName ?? string.Empty;

            if(gamePath == string.Empty)
            {
                throw new DirectoryNotFoundException("Timberborn game location was not found");
            }

            _timberApiLogPath = Path.Combine(gamePath, "TimberApi", "logs");
            _timberApiCorePath = Path.Combine(gamePath, "TimberApi", "core");
            _timberApiPatchersPath = Path.Combine(gamePath, "TimberApi", "patchers");
            _timberApiModPath = Path.Combine(gamePath, "TimberApi", "mods");
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
                InitializePatchersInAssembly(assembly);
            }
        }

        /// <summary>
        /// Searches if the assembly has any class that depends on `ITimberApiPatcher` and initializes it
        /// Used for loading TimberAPI patchers
        /// </summary>
        /// <param name="assembly"></param>
        private static void InitializePatchersInAssembly(Assembly assembly)
        {
            IEnumerable<ITimberApiPatcher> patcherInstances = assembly
                .GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(ITimberApiPatcher)) && type.GetConstructor(Type.EmptyTypes) != null)
                .Select(type => Activator.CreateInstance(type) as ITimberApiPatcher)!;

            foreach (ITimberApiPatcher timberApiPatcher in patcherInstances)
            {
                timberApiPatcher.Initialize();
            }
        }
    }
}