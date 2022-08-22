using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using TimberApi.Core.Common;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.LoggingSystem;
using TimberApi.Core.ModLoaderSystem.Exceptions;
using TimberApi.Core.ModLoaderSystem.ObjectDeserializers;
using TimberApi.Core2;
using TimberApi.Core2.Common;
using TimberApi.Core2.ModEntrySystem;
using TimberApi.Core2.ModSystem;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;
using UnityEngine;
using Logger = TimberApi.Core.LoggingSystem.Logger;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModLoader
    {
        private static readonly string ObjectSaveReaderWriterType = "Mod";

        private static readonly string ModFileName = "mod.json";

        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModObjectDeserializer _modObjectDeserializer;

        private readonly ObjectSaveReaderWriter _objectSaveReaderWriter;

        private readonly Logger _logger;

        private readonly IModDependencySorter _dependencySorter;

        public ImmutableArray<IMod> LoadedMods;

        public ModLoader(IInternalConsoleWriter consoleWriter, ModObjectDeserializer modObjectDeserializer, ObjectSaveReaderWriter objectSaveReaderWriter, Logger logger, IModDependencySorter dependencySorter)
        {
            _consoleWriter = consoleWriter;
            _modObjectDeserializer = modObjectDeserializer;
            _objectSaveReaderWriter = objectSaveReaderWriter;
            _dependencySorter = dependencySorter;
            _logger = logger;
        }

        public void Boot()
        {
            var stopwatch = Stopwatch.StartNew();
            _consoleWriter.Log("Mod loading started");
            string[] modFilePaths = GetModFilePaths();
            _consoleWriter.Log($"Found {modFilePaths.Length} mods");
            IMod[] deserializedMods = DeserializeMods(modFilePaths).ToArray();
            _consoleWriter.Log($"Deserialized {deserializedMods.Length} mods");
            IMod[] uniqueMods = FilterUniqueMods(deserializedMods).ToArray();
            SetDependencyReferenceOnLoadableMods(uniqueMods);
            IMod[] timberApiCompatibleMods = FilterTimberApiCompatibleMods(uniqueMods).ToArray();
            IMod[] gameCompatibleMods = FilterGameCompatibleMods(timberApiCompatibleMods).ToArray();
            IMod[] loadableMods = FilterMissingDependencyMods(gameCompatibleMods).ToArray();
            IMod[] sortedLoadableMods = SortModsOnDependency(loadableMods).ToArray();
            LoadedMods = LoadMods(sortedLoadableMods).ToImmutableArray();
            stopwatch.Stop();
            _consoleWriter.Log("Mod loading finished in: " + stopwatch.ElapsedMilliseconds + "ms, Loaded mods:" + sortedLoadableMods.Count(mod => mod.IsLoaded));
        }

        /// <summary>
        /// Load code and codeless mods, skipped if dependency failed to load
        /// List must be ordered on dependencies
        /// </summary>
        private IEnumerable<IMod> LoadMods(IMod[] sortedLoadableMods)
        {
            List<IMod> loadedMods = new List<IMod>();

            foreach (IMod loadableMod in sortedLoadableMods)
            {
                try
                {
                    if(!NeededDependenciesAreLoaded(loadableMod.Dependencies, sortedLoadableMods, out IEnumerable<IModDependency> missingDependencies))
                    {
                        LogMessageAsMod(loadableMod, $"Skipped: Missing dependencies: {string.Join(", ", missingDependencies.Select(dependency => dependency.UniqueId))}");
                        continue;
                    }

                    if(!loadableMod.IsCodelessMod && !TryLoadCodeMod(loadableMod))
                    {
                        continue;
                    }

                    loadableMod.IsLoaded = true;
                    loadedMods.Add(loadableMod);
                    LogMessageAsMod(loadableMod, "Loaded!", LogType.Log);
                }
                catch (Exception e)
                {
                    LogMessageAsMod(loadableMod,"Failed: " + e.Message, LogType.Error);
                }
            }

            return loadedMods;
        }

        /// <summary>
        /// Loads entryDll, if exceptions are throw mod load is set to true, modders can do this manual too.
        /// Dll cannot be unloaded, except if they all get their own Domain.
        /// </summary>
        private bool TryLoadCodeMod(IMod mod)
        {
            try
            {
                string entryDllPath = Path.Combine(mod.DirectoryPath, mod.EntryDll);
                if (!File.Exists(entryDllPath))
                {
                    throw new ArgumentException("EntryDll was not found");
                }

                Assembly assembly = Assembly.LoadFile(entryDllPath);
                InitializeEntrypointInAssembly(assembly, mod);

                if (mod.LoadFailed)
                {
                    return false;
                }

                mod.LoadedAssembly = assembly;
                return true;
            }
            catch (ModEntrypointFailedException e)
            {
                LogMessageAsMod(mod,"Entrypoint failed: " + e.Message, LogType.Error);
            }
            catch (Exception e)
            {
                LogMessageAsMod(mod,"Failed: " + e.Message, LogType.Error);
            }

            return false;
        }

        /// <summary>
        /// Checks if needed dependencies are loaded
        /// Returns list of dependencies that were missing
        /// </summary>
        private static bool NeededDependenciesAreLoaded(IEnumerable<IModDependency> modDependencies, IMod[] mods, out IEnumerable<IModDependency> missingDependencies)
        {
            List<IModDependency> missingDependenciesList = new List<IModDependency>();
            var neededDependencyLoaded = true;

            foreach (IModDependency modDependency in modDependencies)
            {
                if (mods.Any(mod => modDependency.Optional || (mod.UniqueId == modDependency.UniqueId && mod.IsLoaded)))
                {
                    continue;

                }

                missingDependenciesList.Add(modDependency);
                neededDependencyLoaded = false;
            }

            missingDependencies = missingDependenciesList;
            return neededDependencyLoaded;
        }

        /// <summary>
        /// Creates a instance of the entrypoint class and invokes the entrypoint method
        /// </summary>
        private void InitializeEntrypointInAssembly(Assembly assembly, IMod mod)
        {
            try
            {
                IModEntrypoint? modEntrypoint = assembly
                    .GetTypes()
                    .Where(type => type.GetInterfaces().Contains(typeof(IModEntrypoint)) && type.GetConstructor(Type.EmptyTypes) != null)
                    .Select(type => Activator.CreateInstance(type) as IModEntrypoint)!
                    .Single();

                if (modEntrypoint == null)
                {
                    return;
                }

                modEntrypoint.Entry(mod, new ManualModConsoleWriter(_logger, mod));
            }
            catch (InvalidOperationException)
            {
                throw new MultiModEntrypointException("Only 1 entrypoint is allowed");
            }
            catch (Exception e)
            {
                throw new ModEntrypointFailedException(e.Message);
            }
        }

        /// <summary>
        /// Sorts the list based on dependencies
        /// Makes sure that mods that need a dependency are loaded later
        /// </summary>
        private IEnumerable<IMod> SortModsOnDependency(IEnumerable<IMod> loadableMods)
        {
            return _dependencySorter.Sort(loadableMods, mod => mod.Dependencies.Where(dependency => dependency.Mod != null).Select(dependency => dependency.Mod)!);
        }

        private static void SetDependencyReferenceOnLoadableMods(IMod[] loadableMods)
        {
            foreach (IMod loadableMod in loadableMods)
            {
                foreach (IModDependency loadableModDependency in loadableMod.Dependencies)
                {
                    loadableModDependency.Mod = loadableMods.FirstOrDefault(mod => mod.UniqueId == loadableModDependency.UniqueId);
                }
            }
        }

        /// <summary>
        /// Removes mods with missing dependencies
        /// </summary>
        /// <param name="gameCompatibleMods"></param>
        /// <returns></returns>
        private IEnumerable<IMod> FilterMissingDependencyMods(IMod[] gameCompatibleMods)
        {
            while (true)
            {
                List<IMod> loadableMod = new List<IMod>();
                var removedMod = false;

                foreach (IMod gameCompatibleMod in gameCompatibleMods)
                {
                    if (!NeededDependenciesAreLoadable(gameCompatibleMod.Dependencies, gameCompatibleMods, out IEnumerable<IModDependency> missingDependencies))
                    {
                        LogMessageAsMod(gameCompatibleMod, $"Missing the following dependencies: {string.Join(", ", missingDependencies.Select(dependency => dependency.UniqueId))}");
                        removedMod = true;
                        continue;
                    }

                    loadableMod.Add(gameCompatibleMod);
                }

                if (!removedMod)
                {
                    return loadableMod;
                }

                gameCompatibleMods = loadableMod.ToArray();
            }
        }

        /// <summary>
        /// Checks if the needed dependencies are loadable
        /// Returns a list of needed dependencies that are not loadable
        /// </summary>
        private static bool NeededDependenciesAreLoadable(IEnumerable<IModDependency> modDependencies, IMod[] gameCompatibleMods, out IEnumerable<IModDependency> missingDependencies)
        {
            List<IModDependency> missingDependenciesList = new List<IModDependency>();
            var missingDependency = true;

            foreach (IModDependency modDependency in modDependencies)
            {
                if (gameCompatibleMods.Any(mod =>
                        (mod.UniqueId == modDependency.UniqueId &&
                         !(modDependency.Mod == null || modDependency.Mod.LoadFailed)) ||
                        modDependency.Optional)
                   )
                {
                    continue;
                }

                missingDependenciesList.Add(modDependency);
                missingDependency = false;
            }

            missingDependencies = missingDependenciesList;
            return missingDependency;
        }

        /// <summary>
        /// Minimum timberApi version check
        /// </summary>
        private IEnumerable<IMod> FilterTimberApiCompatibleMods(IEnumerable<IMod> uniqueMods)
        {
            List<IMod> timberApiCompatibleMods = new List<IMod>();

            foreach (IMod uniqueMod in uniqueMods)
            {
                try
                {
                    if (uniqueMod.MinimumApiVersion >= Versions.TimberApiVersion)
                    {
                        LogMessageAsMod(uniqueMod,$"Skipped: Minimum TimberAPI version required: {uniqueMod.MinimumApiVersion}, current TimberAPI version: {Versions.TimberApiVersion}");
                        continue;
                    }

                    timberApiCompatibleMods.Add(uniqueMod);
                }
                catch (Exception e)
                {
                    LogMessageAsMod(uniqueMod,"Failed: " + e, LogType.Error);
                }
            }

            return timberApiCompatibleMods;
        }

        /// <summary>
        /// Minimum game version check
        /// </summary>
        private IEnumerable<IMod> FilterGameCompatibleMods(IEnumerable<IMod> uniqueMods)
        {
            List<IMod> gameCompatibleMods = new List<IMod>();

            foreach (IMod uniqueMod in uniqueMods)
            {
                try
                {
                    if (uniqueMod.MinimumGameVersion >= Versions.GameVersion)
                    {
                        LogMessageAsMod(uniqueMod,$"Skipped: Minimum game version required: {uniqueMod.MinimumGameVersion}, current game version: {Versions.GameVersion}");
                        continue;
                    }

                    gameCompatibleMods.Add(uniqueMod);
                }
                catch (Exception e)
                {
                    LogMessageAsMod(uniqueMod,"Failed: " + e, LogType.Error);
                }
            }

            return gameCompatibleMods;
        }

        /// <summary>
        /// Removes all duplicated unique ID mods
        /// </summary>
        private IEnumerable<IMod> FilterUniqueMods(IEnumerable<IMod> deserializedMods)
        {
            Dictionary<string, IMod> uniqueMods = new Dictionary<string, IMod>();

            foreach (IMod deserializedMod in deserializedMods)
            {
                try
                {
                    uniqueMods.Add(deserializedMod.UniqueId, deserializedMod);
                }
                catch (Exception e)
                {
                    LogMessageAsMod(deserializedMod,"Skipped: " + e.Message);
                }
            }

            return uniqueMods.Values;
        }

        /// <summary>
        /// Deserializing mod.json files
        /// </summary>
        private IEnumerable<IMod> DeserializeMods(IEnumerable<string> modFilePaths)
        {
            List<Mod> deSerializedMods = new List<Mod>();

            foreach (string modFilePath in modFilePaths)
            {
                try
                {
                    ObjectSave wrappedModJson = _objectSaveReaderWriter.ReadJson(DeserializerHelper.Wrap(ObjectSaveReaderWriterType, File.ReadAllText(modFilePath)));
                    Mod mod = ObjectLoader.CreateBasicLoader(wrappedModJson).Get(new PropertyKey<Mod>(ObjectSaveReaderWriterType), _modObjectDeserializer);
                    mod.DirectoryPath = Path.GetDirectoryName(modFilePath)!;
                    mod.DirectoryName = new DirectoryInfo(mod.DirectoryPath).Name;
                    deSerializedMods.Add(mod);
                }
                catch (Exception e)
                {
                    _consoleWriter.Log(new DirectoryInfo(Path.GetDirectoryName(modFilePath)!).Name, "Failed to deserialize: " + e.Message, LogType.Error, LogTextColors.Default[LogType.Error]);
                }
            }

            return deSerializedMods;
        }

        /// <summary>
        /// Searches for mod.json files inside any subdirectory in mods
        /// </summary>
        private static string[] GetModFilePaths()
        {
            return Directory.GetDirectories(Paths.Mods).Select(modDirectory => Path.Combine(modDirectory, ModFileName)).Where(File.Exists).ToArray();
        }

        /// <summary>
        /// Creates a log message as the mod
        /// </summary>
        private void LogMessageAsMod(IMod mod, string message, LogType logType = LogType.Warning)
        {
            Color color = LogTextColors.Default[logType];
            _consoleWriter.Log(mod.Name, message, logType, color);
        }
    }
}