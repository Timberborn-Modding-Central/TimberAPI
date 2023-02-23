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
            return GetSpecifications(typeof(T).Name, serializer);
        }

        public IEnumerable<T> GetSpecifications<T>(string specificationName, IObjectSerializer<T> serializer)
        {
            var specifications = _specificationRepository.GetBySpecification(specificationName.ToLower()).ToArray();

            foreach (var specification in specifications.Where(specification => specification.IsOriginal))
            {
                var mergedSpecification = MergeSpecification(specification, specifications);

                yield return ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJson(mergedSpecification)).Get(new PropertyKey<T>(specification.SpecificationName), serializer);
            }
        }

        private string MergeSpecification(ISpecification originalSpecification, ISpecification[] specifications)
        {
            var mergeSpecifications = specifications.Where(s => s.FullName.Equals(originalSpecification.FullName) && ! s.IsReplace);
            var replaceSpecifications = specifications.Where(s => s.FullName.Equals(originalSpecification.FullName) && s.IsReplace);

            var specification = MergeSpecifications(originalSpecification, mergeSpecifications);
            specification = ReplaceSpecifications(specification, replaceSpecifications);

            return Wrap(specification.ToString(), originalSpecification.SpecificationName);
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
            var json = JObject.Parse(originalSpecification.LoadJson());
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