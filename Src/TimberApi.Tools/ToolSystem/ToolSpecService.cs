using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;

namespace TimberApi.Tools.ToolSystem;

public class ToolSpecService(ISpecService specService) : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolSpec> _toolSpecifications = null!;

    public ImmutableArray<ToolSpec> ToolSpecifications =>
        _toolSpecifications.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolSpecifications = specService.GetSpecs<ToolSpec>()
            .Where(toolSpec => toolSpec.Scenes.Contains(ContextManager.CurrentContext))
            .ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public ToolSpec Get(string id)
    {
        if (!_toolSpecifications.TryGetValue(id.ToLower(), out var toolSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

        return toolSpecification;
    }

    public IEnumerable<ToolSpec> GetByGroupId(string groupId)
    {
        return _toolSpecifications
            .Where(pair => pair.Value.GroupId?.ToLower() == groupId.ToLower())
            .Select(pair => pair.Value);
    }

    public IEnumerable<ToolSpec> GetBySection(string section)
    {
        return _toolSpecifications
            .Where(pair => string.Equals(pair.Value.Section, section, StringComparison.CurrentCultureIgnoreCase))
            .Select(pair => pair.Value);
    }

    public IEnumerable<ToolSpec> GetByType(string type)
    {
        return _toolSpecifications
            .Where(pair => string.Equals(pair.Value.Type, type, StringComparison.CurrentCultureIgnoreCase))
            .Select(pair => pair.Value);
    }
}