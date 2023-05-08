using System;
using TimberApi.Common.Extensions;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;

namespace TimberApi.ToolSystem
{
    public class ToolSpecificationDeserializer : IObjectSerializer<ToolSpecification>
    {
        private readonly ToolIconService _toolIconService;

        public ToolSpecificationDeserializer(ToolIconService toolIconService)
        {
            _toolIconService = toolIconService;
        }

        public void Serialize(ToolSpecification value, IObjectSaver objectSaver)
        {
            throw new NotImplementedException();
        }

        public Obsoletable<ToolSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return new ToolSpecification(
                objectLoader.Get(new PropertyKey<string>("Id")),
                objectLoader.GetValueOrNull(new PropertyKey<string>("GroupId")),
                objectLoader.GetValueOrDefault(new PropertyKey<string>("Section"), "BottomBar"),
                objectLoader.Get(new PropertyKey<string>("Type")),
                objectLoader.GetValueOrDefault(new PropertyKey<string>("Layout"), "Default"),
                objectLoader.Get(new PropertyKey<int>("Order")),
                _toolIconService.GetIcon(objectLoader.Get(new PropertyKey<string>("Icon"))),
                objectLoader.Get(new PropertyKey<string>("NameLocKey")),
                objectLoader.Get(new PropertyKey<string>("DescriptionLocKey")),
                objectLoader.GetValueOrDefault(new PropertyKey<bool>("Hidden"), false),
                objectLoader.GetValueOrDefault(new PropertyKey<bool>("DevMode"), false),
                GetToolInformationObjectSave(objectLoader)
            );
        }

        private static ObjectSave? GetToolInformationObjectSave(IObjectLoader objectLoader)
        {
            if(! objectLoader.Has(new PropertyKey<ObjectSave>("ToolInformation")))
            {
                return null;
            }
            
            return ((ObjectLoader)objectLoader)._objectSave.Get<ObjectSave>("ToolInformation");
        }
    }
}