using Newtonsoft.Json;
using Timberborn.WorldSerialization;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class ToolSpecification : ToolSpecification<ObjectSave>
    {
        public ToolSpecification(string id, string? groupId, string type, string layout, int order, Sprite icon, string nameLocKey, string descriptionLocKey, bool devModeTool, ObjectSave? toolInformation)
            : base(id, groupId, type, layout, order, icon, nameLocKey, descriptionLocKey, devModeTool, toolInformation)
        {
        }
    }

    public class ToolSpecification<T>
    {
        public string Id { get; }

        public string? GroupId { get; }

        public string Type { get; }

        public string Layout { get; }

        public int Order { get; }

        [JsonProperty("Icon")] protected string? IconPath { get; set; }

        [JsonIgnore] public Sprite Icon { get; }

        public string NameLocKey { get; }

        public string DescriptionLocKey { get; }

        public bool DevModeTool { get; }

        public T? ToolInformation { get; }

        public ToolSpecification(string id, string? groupId, string type, string layout, int order, Sprite icon, string nameLocKey, string descriptionLocKey, bool devModeTool, T? toolInformation)
        {
            Id = id;
            GroupId = groupId;
            Type = type;
            Layout = layout;
            Order = order;
            Icon = icon;
            NameLocKey = nameLocKey;
            DescriptionLocKey = descriptionLocKey;
            DevModeTool = devModeTool;
            ToolInformation = toolInformation;
        }

        public ToolSpecification(string id, string? groupId, string type, string layout, int order, string icon, string nameLocKey, string descriptionLocKey, bool devModeTool, T? toolInformation)
        {
            Id = id;
            GroupId = groupId;
            Type = type;
            Layout = layout;
            Order = order;
            IconPath = icon;
            Icon = default!;
            NameLocKey = nameLocKey;
            DescriptionLocKey = descriptionLocKey;
            DevModeTool = devModeTool;
            ToolInformation = toolInformation;
        }
    }
}