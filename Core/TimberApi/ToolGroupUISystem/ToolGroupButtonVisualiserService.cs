using System.Collections.Generic;
using System.Collections.Immutable;

namespace TimberApi.ToolGroupUISystem
{
    public class ToolGroupButtonVisualiserService
    {
        private readonly ImmutableDictionary<string, IToolGroupButtonVisualiser> _toolGroupButtonVisualisers;

        public ToolGroupButtonVisualiserService(IEnumerable<IToolGroupButtonVisualiser> toolGroupButtonVisualisers)
        {
            _toolGroupButtonVisualisers = toolGroupButtonVisualisers.ToImmutableDictionary(visualiser => visualiser.Id.ToLower(), visualiser => visualiser);
        }

        public IToolGroupButtonVisualiser Get(string visualiser)
        {
            if (! _toolGroupButtonVisualisers.ContainsKey(visualiser.ToLower()))
            {
                throw new KeyNotFoundException($"Visualiser ({visualiser.ToLower()}) was not found.");
            }

            return _toolGroupButtonVisualisers[visualiser.ToLower()];
        }
    }
}