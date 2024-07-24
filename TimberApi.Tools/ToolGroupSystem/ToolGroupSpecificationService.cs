using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecificationService : ILoadableSingleton
{
    private readonly ISpecificationService _specificationService;

    private readonly ToolGroupSpecificationDeserializer _toolGroupSpecificationDeserializer;

    private ImmutableDictionary<string, ToolGroupSpecification> _toolGroupSpecifications = null!;

    public ToolGroupSpecificationService(
        ISpecificationService specificationService,
        ToolGroupSpecificationDeserializer toolGroupSpecificationDeserializer)
    {
        _specificationService = specificationService;
        _toolGroupSpecificationDeserializer = toolGroupSpecificationDeserializer;
    }

    public ImmutableArray<ToolGroupSpecification> ToolGroupSpecifications =>
        _toolGroupSpecifications.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolGroupSpecifications = _specificationService.GetSpecifications(_toolGroupSpecificationDeserializer)
            .ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public ToolGroupSpecification Get(string id)
    {
        if (!_toolGroupSpecifications.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

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