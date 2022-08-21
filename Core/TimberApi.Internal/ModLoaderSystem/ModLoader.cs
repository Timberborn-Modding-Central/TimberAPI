using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using TimberApi.Core.ModEntrySystem;
using TimberApi.Core.ModSystem;
using TimberApi.Internal.Common;
using TimberApi.Internal.LoggingSystem;
using TimberApi.Internal.ModLoaderSystem.Exceptions;
using TimberApi.Internal.ModLoaderSystem.ObjectDeserializers;
using TimberApi.Internal.SingletonSystem.Singletons;
using Timberborn.Persistence;
using Timberborn.Versioning;
using Timberborn.WorldSerialization;
using Version = TimberApiVersioning.Version;

namespace TimberApi.Internal.ModLoaderSystem
{
    internal class ModLoader : IBootableSingleton
    {
        private static readonly string ObjectSaveReaderWriterType = "Mod";

        private static readonly string ModFileName = "mod.json";

        private readonly IConsoleWriterInternal _consoleWriterInternal;

        private readonly ModObjectDeserializer _modObjectDeserializer;

        private readonly ObjectSaveReaderWriter _objectSaveReaderWriter;

        private readonly ModRepository _modRepository;

        private readonly Logger _logger;

        public ModLoader(IConsoleWriterInternal consoleWriterInternal, ModObjectDeserializer modObjectDeserializer, ObjectSaveReaderWriter objectSaveReaderWriter, Logger logger, ModRepository modRepository)
        {
            _consoleWriterInternal = consoleWriterInternal;
            _modObjectDeserializer = modObjectDeserializer;
            _objectSaveReaderWriter = objectSaveReaderWriter;
            _modRepository = modRepository;
            _logger = logger;
        }

        public void Boot()
        {
            var stopwatch = Stopwatch.StartNew();
            _consoleWriterInternal.Log("Mod loading started");
            string[] modFilePaths = GetModFilePaths();
            _consoleWriterInternal.Log($"Found {modFilePaths.Length} mods");
            IMod[] deserializedMods = DeserializeMods(modFilePaths).ToArray();
            _consoleWriterInternal.Log($"Deserialized {deserializedMods.Length} mods");
            IMod[] uniqueMods = FilterUniqueMods(deserializedMods).ToArray();
            SetDependencyReferenceOnLoadableMods(uniqueMods);
            IMod[] timberApiCompatibleMods = FilterGameCompatibleMods(uniqueMods).ToArray();
            IMod[] gameCompatibleMods = FilterGameCompatibleMods(timberApiCompatibleMods).ToArray();
            IMod[] loadableMods = FilterMissingDependencyMods(gameCompatibleMods).ToArray();
            IMod[] sortedLoadableMods = SortModsOnDependency(loadableMods).ToArray();
            ImmutableArray<IMod> loadedMods = LoadMods(sortedLoadableMods).ToImmutableArray();
            stopwatch.Stop();
            _modRepository.SetMods(loadedMods);
            _consoleWriterInternal.Log("Mod loading finished in: " + stopwatch.ElapsedMilliseconds + "ms, Loaded mods:" + sortedLoadableMods.Count(mod => mod.IsLoaded));
        }

        private IEnumerable<IMod> LoadMods(IMod[] sortedLoadableMods)
        {
            List<IMod> loadedMods = new List<IMod>();

            foreach (IMod loadableMod in sortedLoadableMods)
            {
                try
                {
                    if(!NeededDependenciesAreLoaded(loadableMod.Dependencies, sortedLoadableMods, out IEnumerable<IModDependency> missingDependencies))
                    {
                        _consoleWriterInternal.Log($"Skipped \"{loadableMod.UniqueId}\" in \"{loadableMod.DirectoryName}\", message: Missing the following dependencies: {string.Join(", ", missingDependencies.Select(dependency => dependency.UniqueId))}");
                        continue;
                    }

                    if(!loadableMod.IsCodelessMod && !TryLoadCodeMod(loadableMod))
                    {
                        continue;
                    }

                    loadableMod.IsLoaded = true;
                    loadedMods.Add(loadableMod);
                }
                catch (Exception e)
                {
                    _consoleWriterInternal.Log($"Failed to load \"{loadableMod.UniqueId}\" in \"{loadableMod.DirectoryName}\", message: {e.Message}");
                }
            }

            return loadedMods;
        }

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
            catch (MultiModEntrypointException e)
            {
                _consoleWriterInternal.Log($"Failed to load \"{mod.UniqueId}\" in \"{mod.DirectoryName}\", message: {e.Message}");
            }
            catch (ModEntrypointFailedException e)
            {
                _consoleWriterInternal.Log($"Failed to load entrypoint \"{mod.UniqueId}\" in \"{mod.DirectoryName}\", message: {e}");
            }
            catch (Exception e)
            {
                _consoleWriterInternal.Log($"Failed to load \"{mod.UniqueId}\" in \"{mod.DirectoryName}\", message: {e}");
            }

            return false;
        }

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

                modEntrypoint.Entry(mod, new ManualConsoleWriter(_logger, mod));
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

        private static IEnumerable<IMod> SortModsOnDependency(IMod[] loadableMods)
        {
            return loadableMods.TopogicalSequenceDfs(mod => mod.Dependencies.Where(dependency => dependency.Mod != null).Select(dependency => dependency.Mod)!);
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
                        _consoleWriterInternal.Log($"Skipped \"{gameCompatibleMod.UniqueId}\" in \"{gameCompatibleMod.DirectoryName}\", message: Missing the following dependencies: {string.Join(", ", missingDependencies.Select(dependency => dependency.UniqueId))}");
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

        private IEnumerable<IMod> FilterTimberApiCompatibleMods(IEnumerable<IMod> uniqueMods)
        {
            //TODO: TimberAPI has no versioning system yet, maybe make `FilterGameCompatibleMods` more generic
            return uniqueMods;
        }

        private IEnumerable<IMod> FilterGameCompatibleMods(IEnumerable<IMod> uniqueMods)
        {
            List<IMod> gameCompatibleMods = new List<IMod>();
            Version gameVersion = Version.Parse(Versions.VersionNumber);

            foreach (IMod uniqueMod in uniqueMods)
            {
                try
                {
                    if (uniqueMod.MinimumGameVersion >= gameVersion)
                    {
                        _consoleWriterInternal.Log($"Skipped \"{uniqueMod.UniqueId}\" in \"{uniqueMod.DirectoryName}\", message: MinimumGameVersion is higher than GameVersion");
                        continue;
                    }

                    gameCompatibleMods.Add(uniqueMod);
                }
                catch (Exception e)
                {
                    _consoleWriterInternal.Log($"Skipped \"{uniqueMod.UniqueId}\" in \"{uniqueMod.DirectoryName}\", message: {e.Message}");
                }
            }

            return gameCompatibleMods;
        }

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
                    _consoleWriterInternal.Log($"Skipped \"{deserializedMod.UniqueId}\" in \"{deserializedMod.DirectoryName}\", message: {e.Message}");
                }
            }

            return uniqueMods.Values;
        }

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
                    _consoleWriterInternal.Log($"Failed to deserialize mod in directory: {new DirectoryInfo(Path.GetDirectoryName(modFilePath)!).Name}, message: {e.Message}");
                }
            }

            return deSerializedMods;
        }

        private static string[] GetModFilePaths()
        {
            return Directory.GetDirectories(Paths.Mods).Select(modDirectory => Path.Combine(modDirectory, ModFileName)).Where(File.Exists).ToArray();
        }
    }
}