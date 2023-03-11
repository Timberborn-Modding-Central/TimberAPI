using TimberApi.Common.Extensions;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.WorldSerialization;
using UnityEngine;

namespace TimberApi.ToolGroupSystem
{
    public abstract class ToolGroupSpecificationDeserializer<TSpecification, TGroupInformation> : IObjectSerializer<TSpecification> where TGroupInformation : new() where TSpecification : ToolGroupSpecification
    {
        private readonly IResourceAssetLoader _resourceAssetLoader;

        protected ToolGroupSpecificationDeserializer(IResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        public virtual void Serialize(TSpecification value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<TSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return typeof(TSpecification).CreateInstance<TSpecification>(new object[] { DeserializeToolGroupSpecification(objectLoader) });
        }

        private ToolGroupSpecification<TGroupInformation> DeserializeToolGroupSpecification(IObjectLoader objectLoader)
        {
            return new ToolGroupSpecification<TGroupInformation>(
                objectLoader.Get(new PropertyKey<string>("Id")),
                objectLoader.GetValueOrNull(new PropertyKey<string>("GroupId")),
                objectLoader.GetValueOrDefault(new PropertyKey<string>("Layout"), "Blue"),
                objectLoader.Get(new PropertyKey<int>("Order")),
                objectLoader.Get(new PropertyKey<string>("NameLocKey")),
                _resourceAssetLoader.Load<Sprite>(objectLoader.Get(new PropertyKey<string>("Icon"))),
                objectLoader.GetValueOrDefault(new PropertyKey<string>("Section"), "BottomBar"),
                objectLoader.GetValueOrDefault(new PropertyKey<bool>("DevModeToolGroup"), false),
                objectLoader.GetValueOrDefault(new PropertyKey<bool>("Hidden"), false),
                objectLoader.GetValueOrDefault(new PropertyKey<bool>("FallbackGroup"), false),
                GetGroupInformation(objectLoader)
            );
        }

        private TGroupInformation GetGroupInformation(IObjectLoader objectLoader)
        {
            if(! objectLoader.Has(new PropertyKey<ObjectSave>("GroupInformation")))
            {
                return DefaultGroupInformation();
            }

            var groupInformationObjectSave = objectLoader.GetPrivateInstanceFieldValue<ObjectSave>("_objectSave").Get<ObjectSave>("GroupInformation");

            var groupInformationObjectLoader = ObjectLoader.CreateBasicLoader(groupInformationObjectSave);

            return DeserializeGroupInformation(groupInformationObjectLoader);
        }

        protected abstract TGroupInformation DeserializeGroupInformation(IObjectLoader objectLoader);

        protected virtual TGroupInformation DefaultGroupInformation()
        {
            return new TGroupInformation();
        }
    }
}