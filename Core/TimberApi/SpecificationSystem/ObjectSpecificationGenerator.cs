using System.Collections.Generic;
using TimberApi.Common.SingletonSystem;
using Timberborn.PrefabSystem;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace TimberApi.SpecificationSystem
{
    public class ObjectSpecificationGenerator : ILoadableSingleton
    {
        private readonly ISingletonRepository _singletonRepository;

        private readonly SpecificationRepository _specificationRepository;

        private readonly ObjectCollectionService _objectCollectionService;

        private readonly IEnumerable<IObjectSpecificationGenerator> _specificationGenerators;

        private readonly ObjectSpecificationCacheService _objectSpecificationCacheService;

        public ObjectSpecificationGenerator(
            ISingletonRepository singletonRepository,
            ObjectCollectionService objectCollectionService,
            IEnumerable<IObjectSpecificationGenerator> objectSpecificationGenerators,
            SpecificationRepository specificationRepository,
            ObjectSpecificationCacheService objectSpecificationCacheService)
        {
            _objectCollectionService = objectCollectionService;
            _specificationGenerators = objectSpecificationGenerators;
            _specificationRepository = specificationRepository;
            _objectSpecificationCacheService = objectSpecificationCacheService;
            _singletonRepository = singletonRepository;
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
            
            Debug.LogWarning("LOLOLOLOLOLOL");

            RunSpecificationLoadableSingletons(_singletonRepository.GetSingletons<IObjectSpecificationLoadableSingleton>());
        }
        
        private static void RunSpecificationLoadableSingletons(IEnumerable<IObjectSpecificationLoadableSingleton> singletons)
        {
            foreach (var singleton in singletons)
            {
                Debug.LogWarning("NNNNNNNNNNNNNNN");
                singleton.SpecificationLoad();
                Debug.LogWarning("MMMMMMMMMMMMMM");
            }
        }
    }
}