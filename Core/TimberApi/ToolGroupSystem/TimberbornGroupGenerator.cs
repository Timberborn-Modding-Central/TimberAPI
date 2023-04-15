using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace TimberApi.ToolGroupSystem
{
    public class TimberbornGroupGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            yield return MapEditorGroupDevelopment();
            yield return RuinsGroupDevelopment();
            yield return OtherGroupHidden();
        }
        
        private static ISpecification MapEditorGroupDevelopment()
        {
            var json = JsonConvert.SerializeObject(new
            {
                DevMode = true
            });
            
            return new GeneratedSpecification(json, "MapEditor", "ToolGroupSpecification", false);
        }
        
        private static ISpecification RuinsGroupDevelopment()
        {
            var json = JsonConvert.SerializeObject(new
            {
                DevMode = true
            });
            
            return new GeneratedSpecification(json, "Ruins", "ToolGroupSpecification", false);
        }
        
        private static ISpecification OtherGroupHidden()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Hidden = true
            });
            
            return new GeneratedSpecification(json, "Other", "ToolGroupSpecification", false);
        }
    }
}