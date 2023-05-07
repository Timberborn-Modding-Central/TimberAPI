using System.Collections.Generic;
using Timberborn.PrefabSystem;

namespace TimberApi.SpecificationSystem
{
    public interface ISpecificationGenerator
    {
        IEnumerable<ISpecification> Generate();
    }
}