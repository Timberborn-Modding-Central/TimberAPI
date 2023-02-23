using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonVisualiserService
    {
        private static readonly string DefaultVisualiser = "blue";

        private readonly ImmutableDictionary<string, IToolGroupButtonVisualiser> _toolGroupButtonVisualisers;

        public ToolGroupButtonVisualiserService(IEnumerable<IToolGroupButtonVisualiser> toolGroupButtonVisualisers)
        {
            _toolGroupButtonVisualisers = toolGroupButtonVisualisers.ToImmutableDictionary(visualiser => visualiser.Id.ToLower());
        }

        public IToolGroupButtonVisualiser Get(string visualiser)
        {
            if (! _toolGroupButtonVisualisers.ContainsKey(visualiser.ToLower()))
            {
                TimberApi.ConsoleWriter.Log($"Visualiser ({visualiser.ToLower()}) was not found, defaulting back to ({DefaultVisualiser}).", LogType.Error);
                return _toolGroupButtonVisualisers[DefaultVisualiser];
            }

            return _toolGroupButtonVisualisers[visualiser.ToLower()];
        }
    }
}