using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupFactoryService
    {
        private readonly ImmutableDictionary<string, IToolGroupFactory> _toolGroupFactories;

        public ToolGroupFactoryService(IEnumerable<IToolGroupFactory> toolFactories)
        {
            _toolGroupFactories = toolFactories.ToImmutableDictionary(factory => factory.Id.ToLower());
        }

        public IToolGroupFactory Get(string factoryId)
        {
            if(! TryGet(factoryId, out var toolFactory))
            {
                throw new KeyNotFoundException($"ToolGroupFactory({factoryId.ToLower()}) was not found.");
            }

            return toolFactory;
        }

        public bool TryGet(string factoryId, [MaybeNullWhen(false)] out IToolGroupFactory toolFactory)
        {
            return _toolGroupFactories.TryGetValue(factoryId.ToLower(), out toolFactory);
        }
    }
}