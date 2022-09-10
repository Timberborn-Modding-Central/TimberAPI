using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;

namespace TimberApi.New.SpecificationSystem
{
    internal class TimberApiSpecificationService : ISpecificationService
    {
        private readonly JsonMergeSettings _jsonMergeSettings;

        private readonly ObjectSaveReaderWriter _objectSaveReaderWriter;
        private readonly SpecificationRepository _specificationRepository;

        public TimberApiSpecificationService(ObjectSaveReaderWriter objectSaveReaderWriter, SpecificationRepository specificationRepository)
        {
            _objectSaveReaderWriter = objectSaveReaderWriter;
            _specificationRepository = specificationRepository;
            _jsonMergeSettings = new JsonMergeSettings
            {
                MergeArrayHandling = MergeArrayHandling.Union
            };
        }

        public IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
        {
            string specificationType = typeof(T).Name;
            IEnumerable<ISpecification> typeSpecification = _specificationRepository.GetBySpecification(specificationType).ToArray();


            foreach (ISpecification originalSpecification in typeSpecification.Where(specification => specification.IsOriginal))
            {
                IEnumerable<ISpecification> mergeSpecifications =
                    typeSpecification.Where(specification => originalSpecification != specification && specification.FullName.Equals(originalSpecification.FullName));
                string mergedJson = Wrap(MergeSpecifications(originalSpecification, mergeSpecifications), specificationType);
                yield return ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJson(mergedJson)).Get(new PropertyKey<T>(specificationType), serializer);
            }
        }

        private JObject MergeSpecification(JObject originalSpecification, ISpecification mergeSpecification)
        {
            originalSpecification.Merge(JObject.Parse(mergeSpecification.LoadJson()), _jsonMergeSettings);
            return originalSpecification;
        }

        private string MergeSpecifications(ISpecification originalSpecification, IEnumerable<ISpecification> mergeSpecifications)
        {
            JObject json = JObject.Parse(originalSpecification.LoadJson());
            return mergeSpecifications.Aggregate(json, MergeSpecification).ToString();
        }

        private static string Wrap(string assetText, string type)
        {
            return "{\"" + type + "\":" + assetText + "}";
        }
    }
}