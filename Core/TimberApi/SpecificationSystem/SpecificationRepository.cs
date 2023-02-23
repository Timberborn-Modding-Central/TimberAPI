using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TimberApi.SpecificationSystem
{
    internal class SpecificationRepository
    {
        private ImmutableDictionary<string, IEnumerable<ISpecification>> _specifications = null!;

        public void Initialize(IEnumerable<ISpecification> specifications)
        {
            _specifications = specifications.GroupBy(specification => specification.SpecificationName).ToImmutableDictionary(
                groupedSpecifications => groupedSpecifications.Key.ToLower(),
                groupedSpecifications => (IEnumerable<ISpecification>) groupedSpecifications
            );
        }

        public void AddRange(IEnumerable<ISpecification> specifications)
        {
            _specifications = _specifications.AddRange(specifications.GroupBy(specification => specification.SpecificationName).ToImmutableDictionary(
                groupedSpecifications => groupedSpecifications.Key.ToLower(),
                groupedSpecifications => (IEnumerable<ISpecification>) groupedSpecifications
            ));
        }

        public IEnumerable<ISpecification> GetBySpecification(string specificationName)
        {
            return _specifications.ContainsKey(specificationName) ? _specifications[specificationName] : Enumerable.Empty<ISpecification>();
        }
    }
}