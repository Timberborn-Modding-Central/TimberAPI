using System.Collections.Generic;
using System.Linq;
using TimberApi.SpecificationSystem;
using Timberborn.Persistence;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupSpecificationService
    {
        private static readonly string SpecificationName = "ToolGroupSpecification";

        private readonly IApiSpecificationService _apiSpecificationService;

        public ToolGroupSpecificationService(IApiSpecificationService apiAPISpecificationService)
        {
            _apiSpecificationService = apiAPISpecificationService;
        }

        public IEnumerable<T> GetSection<T>(string section, IObjectSerializer<T> deserializer) where T : ToolGroupSpecification
        {
            var sectionLower = section.ToLower();

            return _apiSpecificationService.GetSpecifications(SpecificationName, deserializer).Where(specification => specification.Section.ToLower().Equals(sectionLower));
        }
    }
}