using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TimberApi.SpecificationSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupSpecificationService : ILoadableSingleton
    {
        private readonly IApiSpecificationService _apiSpecificationService;

        private readonly ToolGroupSpecificationDeserializer _toolGroupSpecificationDeserializer;

        private ImmutableDictionary<string, ToolGroupSpecification> _toolGroupSpecifications = null!;

        public ImmutableArray<ToolGroupSpecification> ToolGroupSpecifications => _toolGroupSpecifications.Select(pair => pair.Value).ToImmutableArray();

        public ToolGroupSpecificationService(
            // ReSharper disable once InconsistentNaming, Without it generators will be loaded after this class
            ObjectSpecificationGenerator FIX_FOR_LATER_LOADING,
            IApiSpecificationService apiAPISpecificationService,
            ToolGroupSpecificationDeserializer toolGroupSpecificationDeserializer)
        {
            _apiSpecificationService = apiAPISpecificationService;
            _toolGroupSpecificationDeserializer = toolGroupSpecificationDeserializer;
        }

        public void Load()
        {
            _toolGroupSpecifications = _apiSpecificationService.GetSpecifications(_toolGroupSpecificationDeserializer).ToImmutableDictionary(specification => specification.Id.ToLower());
        }

        public ToolGroupSpecification Get(string id)
        {
            if(! _toolGroupSpecifications.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            {
                throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");
            }

            return toolGroupSpecification;
        }

        public IEnumerable<ToolGroupSpecification> GetByGroupId(string groupId)
        {
            return _toolGroupSpecifications
                .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
                .Select(pair => pair.Value);
        }

        public IEnumerable<ToolGroupSpecification> GetBySection(string section)
        {
            return _toolGroupSpecifications
                .Where(pair => pair.Value.Section.ToLower().Equals(section.ToLower()))
                .Select(pair => pair.Value);
        }
    }
}