using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolGroupSystem;

public class TimberbornGroupGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        yield return MapEditorGroupDevelopment();
        yield return RuinsGroupDevelopment();
        yield return OtherGroupHidden();
    }

    private static GeneratedSpecification MapEditorGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            DevMode = true
        });

        return new GeneratedSpecification(json, "MapEditor", "ToolGroupSpecification", false);
    }

    private static GeneratedSpecification RuinsGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            DevMode = true
        });

        return new GeneratedSpecification(json, "Ruins", "ToolGroupSpecification", false);
    }

    private static GeneratedSpecification OtherGroupHidden()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Hidden = true
        });

        return new GeneratedSpecification(json, "Other", "ToolGroupSpecification", false);
    }
}