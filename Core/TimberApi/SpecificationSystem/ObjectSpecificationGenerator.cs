using System.Collections.Generic;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.SpecificationSystem
{
    public class ObjectSpecificationGenerator : ILoadableSingleton
    {
        private readonly SpecificationRepository _specificationRepository;

        private readonly ObjectCollectionService _objectCollectionService;

        private readonly IEnumerable<IObjectSpecificationGenerator> _specificationGenerators;

        public ObjectSpecificationGenerator(ObjectCollectionService objectCollectionService,
            IEnumerable<IObjectSpecificationGenerator> objectSpecificationGenerators,
            SpecificationRepository specificationRepository)
        {
            _objectCollectionService = objectCollectionService;
            _specificationGenerators = objectSpecificationGenerators;
            _specificationRepository = specificationRepository;
        }

        public void Load()
        {
            foreach (var specificationGenerator in _specificationGenerators)
            {
                _specificationRepository.AddRange(specificationGenerator.Generate(_objectCollectionService));
            }
        }
    }
}