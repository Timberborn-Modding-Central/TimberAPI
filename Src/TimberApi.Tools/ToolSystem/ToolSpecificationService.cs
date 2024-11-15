using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.Persistence;
using Timberborn.SingletonSystem;

namespace TimberApi.Tools.ToolSystem;

public class ToolSpecificationService(
    ISpecificationService specificationService,
    ToolSpecificationDeserializer toolSpecificationDeserializer)
    : ILoadableSingleton
{
    private ImmutableDictionary<string, ToolSpecification> _toolSpecifications = null!;

    public ImmutableArray<ToolSpecification> ToolSpecifications =>
        _toolSpecifications.Select(pair => pair.Value).ToImmutableArray();

    public void Load()
    {
        _toolSpecifications = specificationService.GetSpecifications(toolSpecificationDeserializer)
            .Where(specification => specification.Scenes.Contains(SceneManager.CurrentScene.ToString()))
            .ToImmutableDictionary(specification => specification.Id.ToLower());
    }

    public ToolSpecification Get(string id)
    {
        if (!_toolSpecifications.TryGetValue(id.ToLower(), out var toolSpecification))
            throw new KeyNotFoundException($"The given ToolId ({id.ToLower()}) cannot be found.");

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