using Bindito.Core;
using Timberborn.Buildings;
using Timberborn.TemplateSystem;

namespace TimberbornAPI.EntityLinkerSystem
{
    public class EntityLinkerConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<EntityLinkSerializer>().AsSingleton();
            containerDefinition.MultiBind<TemplateModule>().ToProvider(ProvideTemplateModule).AsSingleton();
        }

        private static TemplateModule ProvideTemplateModule()
        {
            TemplateModule.Builder builder = new TemplateModule.Builder();
            builder.AddDecorator<Building, EntityLinker>();
            return builder.Build();
        }
    }
}
