using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx.Bootstrap;
using Timberborn.Localization;
using LINQtoCSV;
using TimberbornAPI.Internal;
using UnityEngine;

namespace TimberbornAPI.Localizations
{
    internal static class LocalizationRepository
    {
        /// <summary>
        /// Modified timberborn method Timberborn.Localization.LocalizationRepository.GetLocalization
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <returns></returns>
        public static IDictionary<string, string> GetLocalization(string localizationKey)
        {
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
            Dictionary<string, string> dictionary2 = GetLocalizationRecordsFromFiles(localizationKey, GetLocalizationFilePathsFromDependencies(localizationKey)).ToDictionary(record => record.Id, record => record.Text);
            
            foreach (LocalizationRecord localizationRecord in GetDefaultLocalization())
            {
                string id = localizationRecord.Id;
                if (dictionary2.TryGetValue(id, out string text) && !string.IsNullOrEmpty(text))
                {
                    dictionary1[id] = TextColors.ColorizeText(text);
                }
                else
                {
                    dictionary1[id] = TextColors.ColorizeText(localizationRecord.Text);
                }
            }

            return dictionary1;
        }
        
        /// <summary>
        /// Parses text files into LocalizationRecords
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="filePaths"></param>
        /// <returns></returns>
        private static IEnumerable<LocalizationRecord> GetLocalizationRecordsFromFiles(string localization, IEnumerable<string> filePaths)
        {
            List<LocalizationRecord> records = new List<LocalizationRecord>();
            foreach (string path in filePaths)
            {
                records.AddRange(TryToReadRecords(localization, path));
            }

            return records;
        }

        /// <summary>
        /// Timberborn method Timberborn.Localization.LocalizationRepository.TryToReadRecords
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static IEnumerable<LocalizationRecord> TryToReadRecords(string localization, string filePath)
        {
            try
            {
                return new CsvContext().Read<LocalizationRecord>(filePath);
            }
            catch (Exception ex)
            {
                string message = "Unable to parse file for " + localization + ".";
                if (ex is AggregatedException aggregatedException1)
                    message = message + " First error: " + ((List<Exception>) aggregatedException1.m_InnerExceptionsList)[0].Message;
                if (localization == LocalizationCodes.Default)
                    throw new InvalidDataException(message, ex);
                Debug.LogError((object) message);
                return new List<LocalizationRecord>();
            }
        }

        /// <summary>
        /// Returns the default localization
        /// </summary>
        private static IEnumerable<LocalizationRecord> GetDefaultLocalization() => GetLocalizationRecordsFromFiles(LocalizationCodes.Default, GetLocalizationFilePathsFromDependencies(LocalizationCodes.Default));

        /// <summary>
        /// Searches for depencies
        /// </summary>
        /// <param name="localizationKey"></param>
        /// <returns></returns>
        private static List<string> GetLocalizationFilePathsFromDependencies(string localizationKey)
        {
            List<string> localizationFilePaths = new List<string>();
            foreach (KeyValuePair<string, BepInEx.PluginInfo> keyValuePair in Chainloader.PluginInfos.Where(kv => kv.Value.Dependencies.Any(dep => dep.DependencyGUID == TimberAPIPlugin.Guid)))
            {
                string pluginLocalizationPath = Path.Combine(Path.GetDirectoryName(keyValuePair.Value.Location) ?? string.Empty, "lang");
                (bool hasLocalization, string localizationName) = LocalizationNameOrDefault(pluginLocalizationPath, localizationKey);

                if(!hasLocalization)
                    continue;
                localizationFilePaths.Add(Path.Combine(pluginLocalizationPath, localizationName));
            }

            return localizationFilePaths;
        }
        
        /// <summary>
        /// Check if localization file exists, return default if not
        /// Returns false if default and localization file doesn't exists 
        /// </summary>
        /// <param name="pluginLocalizationPath"></param>
        /// <param name="localizationName"></param>
        private static (bool, string) LocalizationNameOrDefault(string pluginLocalizationPath, string localizationName)
        {
            if (string.IsNullOrEmpty(localizationName))
                return (false, "");
            
            if (!Directory.Exists(pluginLocalizationPath))
                return (false, "");
            
            if(File.Exists(Path.Combine(pluginLocalizationPath, localizationName + ".txt")))
                return (true, localizationName + ".txt");
            
            if (File.Exists(Path.Combine(pluginLocalizationPath, LocalizationCodes.Default + ".txt")))
                return (true, LocalizationCodes.Default + ".txt");
            
            return (false, "");
        }
    }
}