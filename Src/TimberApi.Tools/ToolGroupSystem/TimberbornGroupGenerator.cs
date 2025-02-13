using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class TimberbornGroupGenerator(ISpecService specService) : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        yield return MapEditorGroupDevelopment();
        yield return RuinsGroupDevelopment();
        yield return OtherGroupHidden();
    }
    
    private static GeneratedSpec MapEditorGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                DevMode = true,
            }
        });

        return new GeneratedSpec(json, "MapEditor", "ToolGroupSpecification");
    }

    private static GeneratedSpec RuinsGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            DevMode = true
        });

        return new GeneratedSpec(json, "Ruins", "ToolGroupSpecification");
    }

    private static GeneratedSpec OtherGroupHidden()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Hidden = true
        });

        return new GeneratedSpec(json, "Other", "ToolGroupSpecification");
    }
}