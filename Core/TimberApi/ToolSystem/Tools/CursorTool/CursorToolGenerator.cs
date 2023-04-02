using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.AssetSystem;
using Timberborn.PrefabSystem;
using UnityEngine;

namespace TimberApi.ToolSystem.Tools.CursorTool
{
    public class CursorToolGenerator : IObjectSpecificationGenerator
    {
        private readonly ToolIconService _toolIconService;

        private readonly Timberborn.CursorToolSystem.CursorTool _cursorTool;

        private readonly IResourceAssetLoader _resourceAssetLoader;

        public CursorToolGenerator(ToolIconService toolIconService, Timberborn.CursorToolSystem.CursorTool cursorTool, IResourceAssetLoader resourceAssetLoader)
        {
            _toolIconService = toolIconService;
            _cursorTool = cursorTool;
            _resourceAssetLoader = resourceAssetLoader;
        }

        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
        {
            var toolSpecification = new ToolSpecification(
                "Cursor",
                null,
                "CursorTool",
                "brown",
                0,
                "Sprites/BottomBar/Cursor",
                "Test",
                "Test",
                false,
                false,
                null);


            yield return new GeneratedSpecification(
                "{\"Id\":\"Cursor\",\"GroupId\":\"Fields\",\"Type\":\"CursorTool\",\"Layout\":\"brown\",\"Order\":0,\"Icon\":\"Sprites/BottomBar/Cursor\",\"NameLocKey\":\"Test\",\"DescriptionLocKey\":\"Test\",\"Hidden\":false,\"DevModeTool\":false}",
                "Cursor", "ToolSpecification");

            Debug.LogError(JsonConvert.SerializeObject(toolSpecification));
        }
    }
}