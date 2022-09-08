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

        private const string CoreDll = "TimberApi.Core.dll";

        private readonly string[] _libraryDlls =
        {
            "TimberApi.Common.dll",
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

        public void StartLoader()
        {
            try
            {
                SetTimberApiPathEnvironmentVariables();
                EnsurePathsExists(_timberApiPath, _timberApiLogsPath, _timberApiCorePath, _timberApiModsPath, _timberApiConfigsPath);
                LoadLibraries();
            }
            catch (Exception e)
            {
                HandleException(e);
                throw;
            }
        }

        public void LoadAndInitializeCoreStartup()
        {
            Assembly assembly = Assembly.LoadFile(Path.Combine(_timberApiCorePath, CoreDll));
            assembly.GetType("TimberApi.Core.Startup").GetMethod("Run", BindingFlags.Public | BindingFlags.Static)!.Invoke(null, null);
        }

        private void SetTimberApiPathEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberLoaderType, _timberApiLoaderType);
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberApiPath, _timberApiPath);
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberApiLogsPath, _timberApiLogsPath);
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberApiCorePath, _timberApiCorePath);
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberApiModsPath, _timberApiModsPath);
            Environment.SetEnvironmentVariable(EnvironmentVariable.TimberApiConfigsPath, _timberApiConfigsPath);
        }

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

        private void HandleException(Exception exception)
        {
            File.WriteAllText(Path.Combine(_timberApiLogsPath, $"Exception-{DateTime.Now:yyyy-MM-dd-HH\\hmm\\mss\\s}.log"), exception.ToString());
        }

        private void LoadLibraries()
        {
            foreach (string libraryDll in _libraryDlls)
            {
                Assembly.LoadFile(Path.Combine(_timberApiCorePath, libraryDll));
            }
        }
    }
}