using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;

namespace TimberApi.SpecificationSystem
{
    internal class ApiSpecificationService : IApiSpecificationService
    {
        private readonly JsonMergeSettings _jsonMergeSettings;
        private readonly JsonMergeSettings _jsonMergeSettingsReplace;

        private readonly ObjectSaveReaderWriter _objectSaveReaderWriter;
        private readonly SpecificationRepository _specificationRepository;

        public ApiSpecificationService(ObjectSaveReaderWriter objectSaveReaderWriter, SpecificationRepository specificationRepository)
        {
            _objectSaveReaderWriter = objectSaveReaderWriter;
            _specificationRepository = specificationRepository;
            _jsonMergeSettings = new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            };
            _jsonMergeSettingsReplace = new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Replace
            };
        }

        public IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
        {
            return GetSpecifications<T>(typeof(T).Name, serializer);
        }

        public IEnumerable<T> GetSpecifications<T>(string specificationName, IObjectSerializer<T> serializer)
        {
            IEnumerable<ISpecification> specifications = _specificationRepository.GetBySpecification(specificationName).ToArray();

            foreach (var originalSpecification in specifications.Where(specification => specification.IsOriginal))
            {
                var mergeSpecifications =
                    specifications.Where(specification => originalSpecification != specification && specification.FullName.Equals(originalSpecification.FullName) && specification.IsReplace == false);

                var replaceSpecifications = specifications.Where(specification => originalSpecification != specification && specification.FullName.Equals(originalSpecification.FullName) && specification.IsReplace == true);
                var mergedJson = MergeSpecifications(originalSpecification, mergeSpecifications);
                var replacedJson = Wrap(ReplaceSpecifications(mergedJson, replaceSpecifications).ToString(), specificationName);
                yield return ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJson(replacedJson)).Get(new PropertyKey<T>(specificationName), serializer);
            }
        }

        private JObject MergeSpecification(JObject originalSpecification, ISpecification mergeSpecification)
        {
            originalSpecification.Merge(JObject.Parse(mergeSpecification.LoadJson()), _jsonMergeSettings);
            return originalSpecification;
        }

        private JObject ReplaceSpecification(JObject mergedSpecification, ISpecification replaceSpecification)
        {
            mergedSpecification.Merge(JObject.Parse(replaceSpecification.LoadJson()), _jsonMergeSettingsReplace);
            return mergedSpecification;
        }

        private JObject MergeSpecifications(ISpecification originalSpecification, IEnumerable<ISpecification> mergeSpecifications)
        {
            JObject json = JObject.Parse(originalSpecification.LoadJson());
            return mergeSpecifications.Aggregate(json, MergeSpecification);
        }

        private JObject ReplaceSpecifications(JObject mergedSpecification, IEnumerable<ISpecification> replaceSpecifications)
        {
            return replaceSpecifications.Aggregate(mergedSpecification, ReplaceSpecification);
        }

        private static string Wrap(string assetText, string type)
        {
            return "{\"" + type + "\":" + assetText + "}";
        }
    }
}