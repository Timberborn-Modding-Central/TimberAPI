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
            // ToolGroupExtensionSpec = new
            // {
            //     DevMode = true,
            // },
            ToolGroupExtensionSpec = new
            {
                Type = "ConstructionModeToolGroup",
                Layout = "Green",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
        });

        return new GeneratedSpec("toolgroups", "ToolGroup.MapEditor", json);
    }

    private static GeneratedSpec RuinsGroupDevelopment()
    {
        var json = JsonConvert.SerializeObject(new
        {
            // ToolGroupExtensionSpec = new
            // {
            //     DevMode = true,
            // }
            ToolGroupExtensionSpec = new
            {
                Type = "ConstructionModeToolGroup",
                Layout = "Green",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
        });

        return new GeneratedSpec("ToolGroups", "ToolGroup.Ruins", json);
    }

    private static GeneratedSpec OtherGroupHidden()
    {
        var json = JsonConvert.SerializeObject(new
        {
            // ToolGroupExtensionSpec = new
            // {
            //     Hidden = true,
            // }
            ToolGroupExtensionSpec = new
            {
                Type = "ConstructionModeToolGroup",
                Layout = "Green",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
        });

        return new GeneratedSpec("ToolGroups", "ToolGroup.Other", json);
    }
}