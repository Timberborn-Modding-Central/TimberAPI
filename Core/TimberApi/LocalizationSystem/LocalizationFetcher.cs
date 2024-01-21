using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LINQtoCSV;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using Timberborn.Common;
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
            if (localizationKey == LocalizationCodes.Default)
            {
                return GetLocalizationRecordsFromFiles(localizationKey, GetLocalizationFilePathsFromDependencies(localizationKey))
                    .ToDictionary(record => record.Id, record => TextColors.ColorizeText(record.Text))!;
            }

            var userLocalizationRecords = GetLocalizationRecordsFromFiles(localizationKey, GetLocalizationFilePathsFromDependencies(localizationKey));
            var defaultLocalizationRecords = GetLocalizationRecordsFromFiles(LocalizationCodes.Default, GetLocalizationFilePathsFromDependencies(LocalizationCodes.Default));

            return defaultLocalizationRecords
                .ToDictionary(
                    defaultLocalizationRecord => defaultLocalizationRecord.Id,
                    defaultLocalizationRecord => TextColors.ColorizeText(userLocalizationRecords.FirstOrDefault(userLocalizationRecord => userLocalizationRecord.Id == defaultLocalizationRecord.Id)?.Text ?? defaultLocalizationRecord.Text)
                )!;
        }

        /// <summary>
        ///     Parses text files into LocalizationRecords
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        private static IEnumerable<LocalizationRecord> GetLocalizationRecordsFromFiles(string localizationKey, IEnumerable<LocalizationFile> filePaths)
        {
            return filePaths
                .SelectMany(localizationFile => TryToReadRecords(localizationKey, localizationFile))
                .GroupBy(record => record.Id)
                .Select(recordsGroupedById => recordsGroupedById.Last())
                .ToList();
        }

        /// <summary>
        ///     Timberborn method Timberborn.Localization.LocalizationRepository.TryToReadRecords
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <param name="localizationFile"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static IEnumerable<LocalizationRecord> TryToReadRecords(string localizationKey, LocalizationFile localizationFile)
        {
            try
            {
                return CleanLocalizationRecords(new CsvContext().Read<LocalizationRecord>(localizationFile.FilePath), localizationFile.Mod);
            }
            catch (Exception exception)
            {
                var message = "Unable to parse file for " + localizationKey + ".";
                if (exception is AggregatedException aggregatedException)
                {
                    message = message + " First error: " + aggregatedException.m_InnerExceptionsList[0].Message;
                }

                if (localizationKey == LocalizationCodes.Default)
                {
                    throw new InvalidDataException(message, exception);
                }

                TimberApi.ConsoleWriter.Log(message, LogType.Error);
                
                return new List<LocalizationRecord>();
            }
        }

        private static IEnumerable<LocalizationRecord> CleanLocalizationRecords(IEnumerable<LocalizationRecord> localizationRecords, IMod mod)
        {
            var records = localizationRecords.ToList();
            
            var errors = records
                .Where(record => record.Text is null)
                .ToList();

            if (errors.IsEmpty())
            {
                return records.Where(record => record.Id is not null);
            }

            foreach (var error in errors)
            {
                TimberApi.ConsoleWriter.LogAs(mod.Name, $"Localization Id does not have any text: {error.Id}", LogType.Error);
            }

            throw new Exception($"Validating localization files for {mod.Name} failed.");
        }

        /// <summary>
        ///     Searches for depencies
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <returns></returns>
        private static IEnumerable<LocalizationFile> GetLocalizationFilePathsFromDependencies(string localizationKey)
        {
            return (
                from mod in DependencyContainer.GetInstance<IModRepository>().All()
                let pluginLocalizationPath = Path.Combine(mod.DirectoryPath, mod.LanguagePath)
                let localizationFile = GetLocalizationFile(pluginLocalizationPath, localizationKey) ?? GetLocalizationFile(pluginLocalizationPath, LocalizationCodes.Default)
                where localizationFile is not null
                select new LocalizationFile(mod, Path.Combine(pluginLocalizationPath, localizationFile))
            ).ToList();
        }

        /// <summary>
        ///     Get the localization file from the plugin localization path or return null
        /// </summary>
        /// <param name="pluginLocalizationPath"></param>
        /// <param name="localizationKey"></param>
        private static string? GetLocalizationFile(string pluginLocalizationPath, string localizationKey)
        {
            if (string.IsNullOrEmpty(localizationKey) || !Directory.Exists(pluginLocalizationPath))
            {
                return null;
            }

            return File.Exists(Path.Combine(pluginLocalizationPath, localizationKey + ".txt")) ? localizationKey + ".txt" : null;
        }
    }
}