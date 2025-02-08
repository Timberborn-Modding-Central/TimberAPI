using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecificationService(ISpecService specificationService) : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolGroupSpec> _toolGroupSpecifications = null!;

    public ImmutableArray<ToolGroupSpec> ToolGroupSpecifications =>
        _toolGroupSpecifications.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolGroupSpecifications = specificationService.GetSpecs<ToolGroupSpec>()
            .ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public ToolGroupSpec Get(string id)
    {
        if (!_toolGroupSpecifications.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolGroupSpecification;
    }

    public IEnumerable<ToolGroupSpec> GetByGroupId(string groupId)
    {
        return _toolGroupSpecifications
            .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }

    public IEnumerable<ToolGroupSpec> GetBySection(string section)
    {
        return _toolGroupSpecifications
            .Where(pair => pair.Value.Section.ToLower().Equals(section.ToLower()))
            .Select(pair => pair.Value);
    }
}