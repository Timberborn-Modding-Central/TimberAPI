using Timberborn.WorldSerialization;

namespace TimberApi.ToolSystem
{
    public class ToolSpecification : ToolSpecification<ObjectSave>
    {
        public ToolSpecification(string id, string type, string layout, int order, string icon, string nameLocKey, string descriptionLocKey, bool devTool, ObjectSave? toolInformation)
            : base(id, type, layout, order, icon, nameLocKey, descriptionLocKey, devTool, toolInformation)
        {
        }
    }

    public class ToolSpecification<T>
    {
        public string Id { get; }

        public string Type { get; }

        public string Layout { get; }

        public int Order { get; }

        public string Icon { get; }

        public string NameLocKey { get; }

        public string DescriptionLocKey { get; }

        public bool DevTool { get; }

        public T? ToolInformation { get; }

        public ToolSpecification(string id, string type, string layout, int order, string icon, string nameLocKey, string descriptionLocKey, bool devTool, T? toolInformation)
        {
            Id = id;
            Type = type;
            Layout = layout;
            Order = order;
            Icon = icon;
            NameLocKey = nameLocKey;
            DescriptionLocKey = descriptionLocKey;
            DevTool = devTool;
            ToolInformation = toolInformation;
        }
    }
}