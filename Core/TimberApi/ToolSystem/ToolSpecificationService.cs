using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.SpecificationSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.ToolSystem
{
    public class ToolSpecificationService : ILoadableSingleton
    {
        private readonly IApiSpecificationService _apiSpecificationService;

        private readonly ToolSpecificationDeserializer _toolSpecificationDeserializer;

        private ImmutableDictionary<string, ToolSpecification> _toolSpecifications = null!;

        public ImmutableArray<ToolSpecification> ToolSpecifications => _toolSpecifications.Select(pair => pair.Value).ToImmutableArray();

        public ToolSpecificationService(
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
        }

        public ToolSpecification Get(string id)
        {
            if(! _toolSpecifications.TryGetValue(id.ToLower(), out var toolSpecification))
            {
                throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");
            }

            return toolSpecification;
        }

        public IEnumerable<ToolSpecification> GetByGroupId(string groupId)
        {
            return _toolSpecifications
                .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
                .Select(pair => pair.Value);
        }
        
        public IEnumerable<ToolSpecification> GetBySection(string section)
        {
            return _toolSpecifications
                .Where(pair => string.Equals(pair.Value.Section, section, StringComparison.CurrentCultureIgnoreCase))
                .Select(pair => pair.Value);
        }
        
        public IEnumerable<ToolSpecification> GetByType(string type)
        {
            return _toolSpecifications
                .Where(pair => string.Equals(pair.Value.Type, type, StringComparison.CurrentCultureIgnoreCase))
                .Select(pair => pair.Value);
        }
    }
}