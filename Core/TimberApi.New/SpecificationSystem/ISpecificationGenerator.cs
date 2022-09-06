using System.Collections.Generic;

namespace TimberApi.New.SpecificationSystem
{
    public interface ISpecificationGenerator
    {
        IEnumerable<ISpecification> Generate();
    }
}