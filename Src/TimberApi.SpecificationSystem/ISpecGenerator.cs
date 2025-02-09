using System.Collections.Generic;

namespace TimberApi.SpecificationSystem;

public interface ISpecGenerator
{
    IEnumerable<GeneratedSpec> Generate();
}