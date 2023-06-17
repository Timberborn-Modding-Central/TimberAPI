using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LINQtoCSV;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using Timberborn.Localization;
using UnityEngine;

namespace TimberApi.LocalizationSystem
{
    internal static class LocalizationFetcher
    {
        /// <summary>
        ///     Modified timberborn method Timberborn.Localization.LocalizationRepository.GetLocalization
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetLocalization(string localizationKey)
        {
            var localizedRecords = GetLocalizationRecordsFromFiles(localizationKey, GetLocalizationFilePathsFromDependencies(localizationKey))
                .ToDictionary(record => record.Id, record => TextColors.ColorizeText(record.Text));

            foreach (LocalizationRecord defaultRecord in GetDefaultLocalization())
            {
                var id = defaultRecord.Id;
                if (!localizedRecords.TryGetValue(id, out string text) || string.IsNullOrEmpty(text))
                {
                    localizedRecords[id] = TextColors.ColorizeText(defaultRecord.Text);
                }
            }

            return localizedRecords;
        }

        /// <summary>
        ///     Parses text files into LocalizationRecords
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        private static IEnumerable<LocalizationRecord> GetLocalizationRecordsFromFiles(string localization, IEnumerable<LocalizationFile> filePaths)
        {
            List<LocalizationRecord> records = new();
            foreach (LocalizationFile localizationFile in filePaths)
            {
                records.AddRange(TryToReadRecords(localization, localizationFile));
            }

            return records;
        }

        /// <summary>
        ///     Timberborn method Timberborn.Localization.LocalizationRepository.TryToReadRecords
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="localizationFile"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static IEnumerable<LocalizationRecord> TryToReadRecords(string localization, LocalizationFile localizationFile)
        {
            try
            {
                var localizationRecords =  new CsvContext().Read<LocalizationRecord>(localizationFile.FilePath);
                
                ValidateLocalizationRecords(localizationRecords, localizationFile.Mod);
                
                return new CsvContext().Read<LocalizationRecord>(localizationFile.FilePath);
            }
            catch (Exception ex)
            {
                var message = "Unable to parse file for " + localization + ".";
                if (ex is AggregatedException aggregatedException)
                {
                    message = message + " First error: " + aggregatedException.m_InnerExceptionsList[0].Message;
                }

                if (localization == LocalizationCodes.Default)
                {
                    throw new InvalidDataException(message, ex);
                }

                TimberApi.ConsoleWriter.Log(message, LogType.Error);
                return new List<LocalizationRecord>();
            }
        }

        private static void ValidateLocalizationRecords(IEnumerable<LocalizationRecord> localizationRecords, IMod mod)
        {
            var hasValidationErrors = false;

            foreach (var record in localizationRecords)
            {
                if(record.Text is null)
                {
                    hasValidationErrors = true;
                    TimberApi.ConsoleWriter.LogAs(mod.Name, $"Localization Id does not have any text: {record.Id}", LogType.Error);
                }
            }

            if(hasValidationErrors)
            {
                throw new Exception($"Validating localization files for {mod.Name} failed.");
            }
        }

        /// <summary>
        ///     Returns the default localization
        /// </summary>
        private static IEnumerable<LocalizationRecord> GetDefaultLocalization()
        {
            return GetLocalizationRecordsFromFiles(LocalizationCodes.Default, GetLocalizationFilePathsFromDependencies(LocalizationCodes.Default));
        }

        /// <summary>
        ///     Searches for depencies
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <returns></returns>
        private static IEnumerable<LocalizationFile> GetLocalizationFilePathsFromDependencies(string localizationKey)
        {
            List<LocalizationFile> localizationFilePaths = new();
            foreach (IMod mod in DependencyContainer.GetInstance<IModRepository>().All())
            {
                var pluginLocalizationPath = Path.Combine(mod.DirectoryPath, mod.LanguagePath);

                (var hasLocalization, var localizationName) = LocalizationNameOrDefault(pluginLocalizationPath, localizationKey);

                if (!hasLocalization)
                {
                    continue;
                }

                localizationFilePaths.Add(new LocalizationFile(mod, Path.Combine(pluginLocalizationPath, localizationName)));
            }

            return localizationFilePaths;
        }

        /// <summary>
        ///     Check if localization file exists, return default if not
        ///     Returns false if default and localization file doesn't exists
        /// </summary>
        /// <param name="pluginLocalizationPath"></param>
        /// <param name="localizationName"></param>
        private static (bool, string) LocalizationNameOrDefault(string pluginLocalizationPath, string localizationName)
        {
            if (string.IsNullOrEmpty(localizationName))
            {
                return (false, "");
            }

            if (!Directory.Exists(pluginLocalizationPath))
            {
                return (false, "");
            }

            if (File.Exists(Path.Combine(pluginLocalizationPath, localizationName + ".txt")))
            {
                return (true, localizationName + ".txt");
            }

            if (File.Exists(Path.Combine(pluginLocalizationPath, LocalizationCodes.Default + ".txt")))
            {
                return (true, LocalizationCodes.Default + ".txt");
            }

            return (false, "");
        }
    }
}
