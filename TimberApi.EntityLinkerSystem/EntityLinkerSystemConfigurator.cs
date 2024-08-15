using Bindito.Core;
using Timberborn.Buildings;
using Timberborn.TemplateSystem;

namespace TimberApi.EntityLinkerSystem
{
    [Context("Game")]
    public class EntityLinkerSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityLinkObjectSerializer>().AsSingleton();
            containerDefinition.MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
        }

        private static TemplateModule ProvideTemplateModule()
        {
            var builder = new TemplateModule.Builder();
            builder.AddDecorator<Building, EntityLinker>();
            return builder.Build();
        }
    }
}