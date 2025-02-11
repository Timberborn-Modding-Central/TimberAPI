using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.CursorToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

public class CursorToolGenerator : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        var json = JsonConvert.SerializeObject(new
        {
            Id = "Cursor",
            Type = "GenericTool",
            Layout = "GrouplessRed",
            Order = 0,
            NameLocKey = "Cursor",
            DescriptionLocKey = "Cursor",
            Icon = "Sprites/BottomBar/Cursor",
            DevMode = false,
            Hidden = false,
            ToolInformation = new
            {
                BottomBarSection = 0,
                ClassName = typeof(CursorTool).FullName,
            }
        });

        yield return new GeneratedSpec("Tools", "ToolSpecification.Cursor", json);
    }
}