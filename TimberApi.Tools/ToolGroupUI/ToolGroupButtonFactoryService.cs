using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupUI;

public class ToolGroupButtonFactoryService
{
    private static readonly string DefaultFactory = "green";

    private readonly ImmutableDictionary<string, IToolGroupButtonFactory> _toolGroupButtonFactories;

    public ToolGroupButtonFactoryService(IEnumerable<IToolGroupButtonFactory> toolGroupButtonVisualisers)
    {
        _toolGroupButtonFactories = toolGroupButtonVisualisers.ToImmutableDictionary(visualiser => visualiser.Id.ToLower());
    }

    public IToolGroupButtonFactory Get(string factoryId)
    {
        if(! _toolGroupButtonFactories.ContainsKey(factoryId.ToLower()))
        {
            Debug.LogError($"ToolGroupButtonFactory({factoryId.ToLower()}) was not found, defaulting back to ({DefaultFactory}).");
            return _toolGroupButtonFactories[DefaultFactory];
        }

        return _toolGroupButtonFactories[factoryId.ToLower()];
    }
}