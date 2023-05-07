using System.Collections.Generic;

namespace TimberApi.SpecificationSystem
{
    public interface ISpecificationGenerator
    {
        IEnumerable<ISpecification> Generate();
    }
}