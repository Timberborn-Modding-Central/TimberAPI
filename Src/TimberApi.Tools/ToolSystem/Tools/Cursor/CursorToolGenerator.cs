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
            ToolSpec = new
            {
                Id = "Cursor",
                Type = "GenericTool",
                Layout = "GrouplessRed",
                Order = 0,
                NameLocKey = "Tool.FixedName",
                DescriptionLocKey = "Tool.FixedDescription",
                Icon = "Sprites/BottomBar/Cursor",
                DevMode = false,
                Hidden = false,
            },
            GenericToolSpec = new {
                ClassName = typeof(CursorTool).FullName
            },
            BottomBarSpec = new
            {
                Section = 0,
            },
        });

        yield return new GeneratedSpec("Tools", "Tool.Cursor", json);
    }
}