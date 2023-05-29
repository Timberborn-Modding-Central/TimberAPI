using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TimberApi.SpecificationSystem
{
    public class ObjectSpecificationCacheService
    {
        private readonly Dictionary<string, ISpecification> _cachedSpecifications = new();
        
        public void Add(ISpecification specification)
        {
            _cachedSpecifications.TryAdd(specification.FullName, specification);
        }
        
        public bool TryGet(ISpecification specification, [MaybeNullWhen(false)] out ISpecification cachedSpecification)
        {
            return _cachedSpecifications.TryGetValue(specification.FullName, out cachedSpecification);
        }
    }
}