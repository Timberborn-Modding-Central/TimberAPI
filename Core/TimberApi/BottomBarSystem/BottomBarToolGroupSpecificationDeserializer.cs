using TimberApi.Common.Extensions;
using TimberApi.ToolGroupSystem;
using Timberborn.AssetSystem;
using Timberborn.Persistence;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolGroupSpecificationDeserializer : ToolGroupSpecificationDeserializer<ToolGroupSpecification, BottomBarGroupInformation>
    {
        public BottomBarToolGroupSpecificationDeserializer(IResourceAssetLoader resourceAssetLoader) : base(resourceAssetLoader)
        {
        }

        protected override BottomBarGroupInformation DeserializeGroupInformation(IObjectLoader objectLoader)
        {
            return new BottomBarGroupInformation(objectLoader.GetValueOrDefault(new PropertyKey<int>("BottomBarSection"), 1));
        }
    }
}