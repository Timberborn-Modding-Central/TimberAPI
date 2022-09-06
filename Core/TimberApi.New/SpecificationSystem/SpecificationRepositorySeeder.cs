using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimberApi.Common.Helpers;
using TimberApi.Common.SingletonSystem.Singletons;
using TimberApi.New.ModSystem;
using TimberApi.New.SpecificationSystem.SpecificationTypes;
using UnityEngine;

namespace TimberApi.New.SpecificationSystem
{
    public class SpecificationRepositorySeeder : ITimberApiSeeder
    {
        private static readonly string TimberbornSpecificationPath = "Specifications";

        private readonly IModRepository _modRepository;

        private readonly SpecificationRepository _specificationRepository;

        private readonly IEnumerable<ISpecificationGenerator> _specificationGenerators;

        public SpecificationRepositorySeeder(IModRepository modRepository, SpecificationRepository specificationRepository, IEnumerable<ISpecificationGenerator> specificationGenerators)
        {
            _modRepository = modRepository;
            _specificationRepository = specificationRepository;
            _specificationGenerators = specificationGenerators;
        }

        public void Run()
        {
            List<ISpecification> specifications = new List<ISpecification>();

            specifications.AddRange(FileService.GetFiles(_modRepository.All().Select(mod => Path.Combine(mod.DirectoryPath, mod.SpecificationPath)), "*.json").Select(filePath => new FileSpecification(filePath)));

            specifications.AddRange(Resources.LoadAll<TextAsset>(TimberbornSpecificationPath).Select(asset => new TimberbornSpecification(asset)));

            foreach (ISpecificationGenerator specificationGenerator in _specificationGenerators)
            {
                specifications.AddRange(specificationGenerator.Generate());
            }

            _specificationRepository.Initialize(specifications);
        }
    }
}