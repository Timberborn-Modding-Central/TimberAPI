using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

public class CursorToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "Cursor",
            Type = "CursorTool",
            Layout = "GrouplessRed",
            Order = 0,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/Cursor",
            DevMode = false,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0
            }
        });

        yield return new GeneratedSpecification("Tools", "ToolSpecification.Cursor", json);
    }
}