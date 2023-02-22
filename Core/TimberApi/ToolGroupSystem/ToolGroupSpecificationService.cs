using System.Collections.Generic;
using System.Linq;
using Timberborn.Persistence;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupSpecificationService
    {
        private readonly ISpecificationService _specificationService;

        public ToolGroupSpecificationService(ISpecificationService specificationService)
        {
            _specificationService = specificationService;
        }

        public IEnumerable<T> GetSection<T>(string section, IObjectSerializer<T> deserializer) where T : ToolGroupSpecification
        {
            var sectionLower = section.ToLower();

            return _specificationService.GetSpecifications(deserializer).Where(specification => specification.Section.ToLower().Equals(sectionLower));
        }
    }
}