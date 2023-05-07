using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.ToolUISystem
{
    public class ToolButtonFactoryService
    {
        private static readonly string DefaultFactory = "Default";

        private readonly ImmutableDictionary<string, IToolButtonFactory> _toolButtonFactories;

        public ToolButtonFactoryService(IEnumerable<IToolButtonFactory> toolGroupButtonVisualisers)
        {
            _toolButtonFactories = toolGroupButtonVisualisers.ToImmutableDictionary(visualiser => visualiser.Id.ToLower());
        }

        public IToolButtonFactory Get(string factoryId)
        {
            if(! _toolButtonFactories.ContainsKey(factoryId.ToLower()))
            {
                TimberApi.ConsoleWriter.Log($"ToolButtonFactory({factoryId.ToLower()}) was not found, defaulting back to ({DefaultFactory}).", LogType.Error);
                return _toolButtonFactories[DefaultFactory];
            }

            return _toolButtonFactories[factoryId.ToLower()];
        }
    }
}