using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TimberApi.Internal.SpecificationSystem
{
    public class SpecificationRepository
    {
        private bool _isInitialized;

        private ImmutableArray<ISpecification> _specifications;

        public void Initialize(IEnumerable<ISpecification> specifications)
        {
            if (_isInitialized)
            {
                throw new ArgumentException("Specification repository is already initialized");
            }

            _specifications = specifications.ToImmutableArray();
            _isInitialized = true;
        }

        public ImmutableArray<ISpecification> GetAll()
        {
            return _specifications;
        }

        public IEnumerable<ISpecification> GetBySpecification(string specificationName)
        {
            return _specifications.Where(specification => specificationName.ToLower().Equals(specification.SpecificationName));
        }
    }
}