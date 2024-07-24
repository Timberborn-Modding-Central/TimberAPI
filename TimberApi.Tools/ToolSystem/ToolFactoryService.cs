using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace TimberApi.Tools.ToolSystem;

public class ToolFactoryService
{
    private readonly ImmutableDictionary<string, IToolFactory> _toolFactories;

    public ToolFactoryService(IEnumerable<IToolFactory> toolFactories)
    {
        _toolFactories = toolFactories.ToImmutableDictionary(factory => factory.Id.ToLower());
    }

    public IToolFactory Get(string factoryId)
    {
        if (!TryGet(factoryId, out var toolFactory))
            throw new KeyNotFoundException($"ToolFactory({factoryId.ToLower()}) was not found.");

        return toolFactory;
    }

    public bool TryGet(string factoryId, [MaybeNullWhen(false)] out IToolFactory toolFactory)
    {
        return _toolFactories.TryGetValue(factoryId.ToLower(), out toolFactory);
    }
}