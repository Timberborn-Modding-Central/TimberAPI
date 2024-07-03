using System.Collections.Generic;
using Timberborn.PrefabGroupSystem;
using Timberborn.PrefabSystem;

namespace TimberApi.SpecificationSystem;

public interface IObjectSpecificationGenerator
{
    IEnumerable<GeneratedObjectSpecification> Generate(PrefabGroupService prefabGroupService);
}