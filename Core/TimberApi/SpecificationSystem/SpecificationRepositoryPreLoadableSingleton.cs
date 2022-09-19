using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimberApi.Common.Helpers;
using TimberApi.Common.SingletonSystem;
using TimberApi.ModSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using UnityEngine;

namespace TimberApi.SpecificationSystem
{
    internal class SpecificationRepositoryPreLoadableSingleton : ITimberApiPreLoadableSingleton
    {
        private static readonly string TimberbornSpecificationPath = "Specifications";

        private readonly IModRepository _modRepository;

        private readonly IEnumerable<ISpecificationGenerator> _specificationGenerators;

        private readonly SpecificationRepository _specificationRepository;

        public SpecificationRepositoryPreLoadableSingleton(IModRepository modRepository, SpecificationRepository specificationRepository, IEnumerable<ISpecificationGenerator> specificationGenerators)
        {
            _modRepository = modRepository;
            _specificationRepository = specificationRepository;
            _specificationGenerators = specificationGenerators;
        }

        public void PreLoad()
        {
            List<ISpecification> specifications = new();

            specifications.AddRange(FileService.GetFiles(_modRepository.All().Select(mod => Path.Combine(mod.DirectoryPath, mod.SpecificationPath)), "*.json")
                .Select(filePath => new FileSpecification(filePath)));

            specifications.AddRange(Resources.LoadAll<TextAsset>(TimberbornSpecificationPath).Select(asset => new TimberbornSpecification(asset)));

            foreach (ISpecificationGenerator specificationGenerator in _specificationGenerators)
            {
                specifications.AddRange(specificationGenerator.Generate());
            }

            _specificationRepository.Initialize(specifications);
        }
    }
}