using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.SpecificationSystem;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class ToolSpecificationRepository : ILoadableSingleton
    {
        private readonly IApiSpecificationService _apiSpecificationService;

        private readonly ToolSpecificationDeserializer _toolSpecificationDeserializer;

        private ImmutableDictionary<string, ToolSpecification> _toolSpecifications = null!;

        public ToolSpecificationRepository(
            // ReSharper disable once InconsistentNaming, Without it generators will be loaded after this class
            ObjectSpecificationGenerator FIX_FOR_LATER_LOADING,
            IApiSpecificationService apiAPISpecificationService,
            ToolSpecificationDeserializer toolSpecificationDeserializer)
        {
            _apiSpecificationService = apiAPISpecificationService;
            _toolSpecificationDeserializer = toolSpecificationDeserializer;
        }

        public void Load()
        {
            _toolSpecifications = _apiSpecificationService.GetSpecifications(_toolSpecificationDeserializer).ToImmutableDictionary(specification => specification.Id.ToLower());
            Debug.LogWarning(_toolSpecifications.Count);
        }

        public ToolSpecification Get(string id)
        {
            if(! _toolSpecifications.TryGetValue(id.ToLower(), out var toolSpecification))
            {
                throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");
            }

            return toolSpecification;
        }

        public IEnumerable<ToolSpecification> GetAllFromGroup(string groupId)
        {
            return _toolSpecifications.Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
                .Select(pair => pair.Value)
                .OrderBy(specification => specification.Order);
        }
    }
}