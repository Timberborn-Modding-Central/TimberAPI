using TimberApi.Common.Extensions;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;

namespace TimberApi.ToolSystem
{
    public class ToolSpecificationDeserializer : IObjectSerializer<ToolSpecification>
    {
        public void Serialize(ToolSpecification value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<ToolSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return new ToolSpecification(
                objectLoader.Get(new PropertyKey<string>("Id")),
                objectLoader.Get(new PropertyKey<string>("Type")),
                objectLoader.Get(new PropertyKey<string>("Layout")),
                objectLoader.Get(new PropertyKey<int>("Order")),
                objectLoader.Get(new PropertyKey<string>("Icon")),
                objectLoader.Get(new PropertyKey<string>("NameLocKey")),
                objectLoader.Get(new PropertyKey<string>("DescriptionLocKey")),
                objectLoader.Get(new PropertyKey<bool>("DevTool")),
                GetToolInformationObjectSave(objectLoader)
            );
        }

        private static ObjectSave? GetToolInformationObjectSave(IObjectLoader objectLoader)
        {
            if (! objectLoader.Has(new PropertyKey<ObjectSave>("ToolInformation")))
            {
                return null;
            }

            return objectLoader.GetPrivateInstanceFieldValue<ObjectSave>("_objectSave").Get<ObjectSave>("ToolInformation");
        }
    }
}