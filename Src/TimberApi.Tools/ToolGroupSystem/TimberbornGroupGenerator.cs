using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlueprintSystem;
namespace TimberApi.Tools.ToolGroupSystem;

public class TimberbornGroupGenerator(ISpecService specService) : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        // TODO: Double generated spec is not possible, it should be possible if it's not a object spec.
        // yield return MapEditorGroupDevelopment();
        // yield return RuinsGroupDevelopment();
        // yield return OtherGroupHidden();
        yield break;
    }
    
    private static GeneratedSpec MapEditorGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                DevMode = true,
            },
        });
        
        return new GeneratedSpec("ToolGroups", "TimberApiToolGroup.MapEditor", json);
    }

    private static GeneratedSpec RuinsGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                DevMode = false,
            }
        });

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroup.Ruins", json);
    }

    private static GeneratedSpec OtherGroupHidden()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Hidden = true,
            }
        });

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroup.Other", json);
    }
}