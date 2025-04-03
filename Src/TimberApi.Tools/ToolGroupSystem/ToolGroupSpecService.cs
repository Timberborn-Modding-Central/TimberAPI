using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;
using Timberborn.ToolSystem;
using Timberborn.WaterBuildingsUI;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecService(ISpecService specService) : ILoadableSingleton
{
    private ImmutableDictionary<string, TimberApiToolGroupSpec> _toolGroupSpec;

    public ImmutableArray<TimberApiToolGroupSpec> ToolGroupSpecs => _toolGroupSpec.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolGroupSpec = specService.GetSpecs<TimberApiToolGroupSpec>().ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public ToolGroupSpec Get(string id)
    {
        if (!_toolGroupSpec.TryGetValue(id.ToLower(), out var toolGroupSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolGroupSpecification;
    }

    public IEnumerable<TimberApiToolGroupSpec> GetByGroupId(string groupId)
    {
        return _toolGroupSpec
            .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }

    public IEnumerable<TimberApiToolGroupSpec> GetBySection(string section)
    {
        return _toolGroupSpec
            .Where(pair => section.ToLower().Equals(pair.Value.Section.ToLower()))
            .Select(pair => pair.Value);
    }
}