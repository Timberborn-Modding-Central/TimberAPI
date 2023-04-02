using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimberApi.Common;
using TimberApi.Common.Helpers;
using TimberApi.Common.SingletonSystem;
using TimberApi.ModSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using UnityEngine;

namespace TimberApi.SpecificationSystem
{
    public class SpecificationRepository : ITimberApiLoadableSingleton
    {
        private static readonly string SpecificationPath = "Specifications";

        private readonly IModRepository _modRepository;

        private Dictionary<string, List<ISpecification>> _specifications;

        public SpecificationRepository(IModRepository modRepository)
        {
            _modRepository = modRepository;
            _specifications = new Dictionary<string, List<ISpecification>>();
        }

        public void AddRange(IEnumerable<ISpecification> specifications)
        {
            foreach (var groupedSpecification in specifications.GroupBy(specification => specification.SpecificationName))
            {
                if(! _specifications.ContainsKey(groupedSpecification.Key.ToLower()))
                {
                    _specifications.Add(groupedSpecification.Key, new List<ISpecification>());
                }

                _specifications[groupedSpecification.Key.ToLower()].AddRange(groupedSpecification);
            }
        }

        public IEnumerable<ISpecification> GetBySpecification(string specificationName)
        {
            return _specifications.ContainsKey(specificationName) ? _specifications[specificationName] : Enumerable.Empty<ISpecification>();
        }

        public void Load()
        {
            AddRange(
                FileService.GetFiles(Path.Combine(Paths.TimberApi, SpecificationPath), "*.json")
                    .Select(filePath => new FileSpecification(filePath))
            );

            AddRange(
                FileService.GetFiles(_modRepository.All().Select(mod => Path.Combine(mod.DirectoryPath, mod.SpecificationPath)), "*.json")
                    .Select(filePath => new FileSpecification(filePath))
            );

            AddRange(Resources.LoadAll<TextAsset>(SpecificationPath).Select(asset => new TimberbornSpecification(asset)));
        }
    }
}