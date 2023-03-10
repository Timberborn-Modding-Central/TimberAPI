using System.Collections.Generic;
using TimberApi.Common.SingletonSystem;

namespace TimberApi.SpecificationSystem
{
    public class SpecificationGenerator : ITimberApiLoadableSingleton
    {
        private readonly SpecificationRepository _specificationRepository;

        private readonly IEnumerable<ISpecificationGenerator> _specificationGenerators;

        public SpecificationGenerator(IEnumerable<ISpecificationGenerator> specificationGenerators, SpecificationRepository specificationRepository)
        {
            _specificationGenerators = specificationGenerators;
            _specificationRepository = specificationRepository;
        }

        public void Load()
        {
            foreach (var specificationGenerator in _specificationGenerators)
            {
                _specificationRepository.AddRange(specificationGenerator.Generate());
            }
        }
    }
}