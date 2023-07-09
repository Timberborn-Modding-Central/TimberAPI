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

        private readonly ObjectSpecificationCacheService _objectSpecificationCacheService;

        public ObjectSpecificationGenerator(
            ObjectCollectionService objectCollectionService,
            IEnumerable<IObjectSpecificationGenerator> objectSpecificationGenerators,
            SpecificationRepository specificationRepository,
            ObjectSpecificationCacheService objectSpecificationCacheService)
        {
            _objectCollectionService = objectCollectionService;
            _specificationGenerators = objectSpecificationGenerators;
            _specificationRepository = specificationRepository;
            _objectSpecificationCacheService = objectSpecificationCacheService;
        }

        public void Load()
        {
            foreach (var specificationGenerator in _specificationGenerators)
            {
                foreach (var specification in specificationGenerator.Generate(_objectCollectionService))
                {
                    if(_objectSpecificationCacheService.TryGet(specification, out var cachedSpecification))
                    {
                        _specificationRepository.Add(cachedSpecification);
                    }
                    else
                    {
                        _objectSpecificationCacheService.Add(specification);
                        _specificationRepository.Add(specification);
                    }
                }
            }
        }
    }
}