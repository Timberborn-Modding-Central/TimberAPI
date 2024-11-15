using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.CursorToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Cursor;

public class CursorToolGenerator : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
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

        yield return new GeneratedSpecification("Tools", "ToolSpecification.Cursor", json);
    }
}