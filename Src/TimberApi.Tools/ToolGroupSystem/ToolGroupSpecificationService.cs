using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecificationService(ISpecService specificationService) : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolGroupSpec> _toolGroupSpecifications;

    private ImmutableArray<ToolGroupExtensionSpec> _toolGroupExtensionSpecs;

    public ImmutableArray<ToolGroupSpec> ToolGroupSpecs => _toolGroupSpecifications.Select(pair => pair.Value).ToImmutableArray();
    
    public ImmutableArray<ToolGroupExtensionSpec> ToolGroupExtensionSpecs => _toolGroupExtensionSpecs.ToImmutableArray();

    public void Load()
    {
        Debug.LogWarning("WSSSS");
        _toolGroupSpecifications = specificationService.GetSpecs<ToolGroupSpec>()
            .ToImmutableDictionary(specification => specification.Id.ToLower());

        _toolGroupExtensionSpecs = specificationService.GetSpecs<ToolGroupExtensionSpec>().ToImmutableArray();
        
        Debug.LogWarning("BABABOE");

    }

    public ToolGroupSpec Get(string id)
    {
        if (!_toolGroupSpecifications.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolGroupSpecification;
    }

    public IEnumerable<ToolGroupSpec> GetByGroupId(string groupId)
    {
        return _toolGroupExtensionSpecs
            .Where(spec => spec.GroupId?.ToLower() == groupId.ToLower())
            .Select(spec => spec.GetSpec<ToolGroupSpec>());
    }

    public IEnumerable<ToolGroupSpec> GetBySection(string section)
    {
        return _toolGroupExtensionSpecs
            .Where(spec => string.Equals(spec.Section, section, StringComparison.CurrentCultureIgnoreCase))
            .Select(spec => spec.GetSpec<ToolGroupSpec>());
    }
}