using System.Collections.Generic;

namespace TimberApi.Internal.SpecificationSystem
{
    public interface ISpecificationGenerator
    {
        IEnumerable<ISpecification> Generate();
    }
}