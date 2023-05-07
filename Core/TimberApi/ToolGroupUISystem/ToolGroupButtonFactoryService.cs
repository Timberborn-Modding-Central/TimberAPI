using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.ToolGroupUISystem
{
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
                TimberApi.ConsoleWriter.Log($"ToolGroupButtonFactory({factoryId.ToLower()}) was not found, defaulting back to ({DefaultFactory}).", LogType.Error);
                return _toolGroupButtonFactories[DefaultFactory];
            }

            return _toolGroupButtonFactories[factoryId.ToLower()];
        }
    }
}