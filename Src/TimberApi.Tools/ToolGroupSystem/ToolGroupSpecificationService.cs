using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecificationService(ISpecService specificationService) : ILoadableSingleton
{
    private ImmutableDictionary<string, TimberApiToolGroupSpec> _toolGroupSpecifications = null!;

    public ImmutableArray<TimberApiToolGroupSpec> ToolGroupSpecifications =>
        _toolGroupSpecifications.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolGroupSpecifications = specificationService.GetSpecs<TimberApiToolGroupSpec>()
            .ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public TimberApiToolGroupSpec Get(string id)
    {
        if (!_toolGroupSpecifications.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolGroupSpecification;
    }

    public IEnumerable<TimberApiToolGroupSpec> GetByGroupId(string groupId)
    {
        return _toolGroupSpecifications
            .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }

    public IEnumerable<TimberApiToolGroupSpec> GetBySection(string section)
    {
        return _toolGroupSpecifications
            .Where(pair => pair.Value.Section.ToLower().Equals(section.ToLower()))
            .Select(pair => pair.Value);
    }
}